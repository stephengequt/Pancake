﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EduSearchIS;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;

namespace EduSearchAdvancedIS
{
    class LuceneAdvancedSearchApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        IndexSearcher searcher;
        QueryParser parser;
        Similarity newSimilarity;

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text";
        const string ID_FN = "ID";
        const string FILEPATH_FN = "Filepath";
        const string TITLE_FN = "Title";
        public bool PreProcessOpt { get; set; }

        public LuceneAdvancedSearchApplication()
        {
            luceneIndexDirectory = null;
            writer = null;
//            analyzer = new Lucene.Net.Analysis.WhitespaceAnalyzer();
            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer(); // Activity 5
            //analyzer = new Lucene.Net.Analysis.StopAnalyzer(); // Activity 5
            //analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30); // Activity 5
            //analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30, "English"); // Activity 7


            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, TEXT_FN, analyzer);
            //newSimilarity = new NewSimilarity(); // Activity 9
        }

        /// <summary>
        /// Creates the index at a given path
        /// </summary>
        /// <param name="indexPath">The pathname to create the index</param>
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            //writer.SetSimilarity(newSimilarity); // Activity 9
        }


        /// <summary>
        /// Indexes a given string into the index
        /// </summary>
        /// <param name="text">The text to index</param>
        public void IndexText(string text)
        {
            DocInfo docInfo = OutputSections(text);
            Lucene.Net.Documents.Field field = new Field(TEXT_FN, text, Field.Store.YES, Field.Index.ANALYZED,
                Field.TermVector.YES);
            Lucene.Net.Documents.Field docIdfield = new Field(ID_FN, docInfo.DocID, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
            Lucene.Net.Documents.Field docTitlefield = new Field(TITLE_FN, docInfo.DocID, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(field);
            doc.Add(docIdfield);
            doc.Add(docTitlefield);
            writer.AddDocument(doc);
        }


        /// <summary>
        /// Flushes the buffer and closes the index
        /// </summary>
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }


        /// <summary>
        /// Creates the searcher object
        /// </summary>
        public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
            //searcher.Similarity = newSimilarity; // Activity 9
        }

        /// <summary>
        /// Searches the index for the querytext
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public SearchResult SearchText(string querytext)
        {
            System.Console.WriteLine("Searching for " + querytext);
            querytext = querytext.ToLower();
            if (!PreProcessOpt)
            {
                querytext = "\"" + querytext + "\"";
            }

            Query query = parser.Parse(querytext);

            TopDocs results = searcher.Search(query, 100);

            int rank = 0;
            List<DocInfo> scoreDocList = new List<DocInfo>();
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                var docContent = searcher.Doc(scoreDoc.Doc);

                var field_value = docContent.Get(TEXT_FN).ToString();
                DocInfo docInfo = new DocInfo();

                docInfo = OutputSections(field_value);

                docInfo.Rank = rank;

//                docinfo.Title = docContent
                docInfo.DocScore = scoreDoc.Score;
                scoreDocList.Add(docInfo);
//
                //                //Explanation e = searcher.Explain(query, scoreDoc.Doc); // Activity 8
                //                //System.Console.WriteLine(e.ToString());
            }

            SearchResult searchResult = new SearchResult
            {
                NumOfResult = results.TotalHits,
                DocInfoList = scoreDocList,
                finalQuery = query.ToString()
            };
            return searchResult;


//            Console.WriteLine(DisplayFinialQuery(query)); //Test display final query

            //var continueVal = false;
            //var pageIndex = 0;
            //do
            //{
            //    var operation = Console.ReadLine();
            //    if (operation != "end")
            //    {
            //        switch (operation)
            //        {
            //            case "next": 
            //                pageIndex++;
            //                ResultBrowser(results.ScoreDocs, pageIndex);
            //                Console.WriteLine();
            //                break;
            //            case "previous":
            //                pageIndex--;
            //                ResultBrowser(results.ScoreDocs, pageIndex);
            //                Console.WriteLine();
            //                break;
            //            default:
            //                ResultBrowser(results.ScoreDocs, pageIndex);
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        continueVal = true;
            //    }

            //} while (continueVal == false);
        }

        /// <summary>
        /// Closes the index after searching
        /// </summary>
        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }

        public static string[] SeparateDocString(string text)
        {
//            string[] sections = {" ", " ", " ", " ", " "};    
            string[] sections = text.Split(new string[] {".I", ".T", ".A", ".B", ".W"}, StringSplitOptions.None);
            //foreach (var word in words)
            //Console.WriteLine(word);
            return sections;
        }

        public static string[] SeparateQueryString(string text)
        {
            string[] sections = text.Split(new string[] {".I ", ".D"}, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var word in words)
            //Console.WriteLine(word);
            return sections;
        }

        public static QueryInfo[] GetQueryInfo(string[] sections)
        {
            List<QueryInfo> queryInfos = new List<QueryInfo>();
            for (int i = 0; i < sections.Length / 2 - 1; i++)
            {
                QueryInfo queryInfo = new QueryInfo()
                {
                    QueryID = sections[2 * i],
                    QueryContent = sections[2 * i + 1]
                };
                queryInfos.Add(queryInfo);
            }

            return queryInfos.ToArray();
        }

        public static DocInfo OutputSections(string docContent)
        {
            string[] sections = SeparateDocString(docContent);

            //remove the title from the chunk of text
            if (!string.IsNullOrEmpty(sections[2]))
            {
                sections[5] = sections[5].Replace(sections[2], null);
            }

            //obtain the first line of text as the abstract
            var firstLine = sections[5].Split('.')[0];

            DocInfo docInfo = new DocInfo
            {
                DocID = sections[1],
                Title = sections[2],
                Author = sections[3],
                Bibliography = sections[4],
                Sentence = firstLine,
                Abstract = sections[5]
            };

            return docInfo;
        }

        public TopDocs DTSearchText(string querytext, Label message)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            querytext = querytext.ToLower();
            Query query = parser.Parse(querytext);
            TopDocs results = searcher.Search(query, 6000);
            watch.Stop();
            var queryTime = watch.ElapsedMilliseconds;
            int totalHits = results.TotalHits;
            message.ForeColor = Color.Green;
            message.Text = "Found " + totalHits + " documents (" + queryTime + "ms)";
            return results;
        }

        //public DataTable DTResults(TopDocs results, Form form, DataTable dt)
        //{
        //    int rank = 1;
        //    int totalHits = results.TotalHits;
        //    dt.Clear();

        //    foreach (ScoreDoc scoreDoc in results.ScoreDocs)
        //    {
        //        DataRow dr = dt.NewRow();

        //        Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
        //        string idValue = doc.Get(ID_FN).ToString();
        //        string textValue = doc.Get(TEXT_FN).ToString();
        //        string filepathValue = doc.Get(FILEPATH_FN).ToString();

        //        int middleOftext = (int)(textValue.Length / 2);

        //        dr[0] = idValue;
        //        dr[1] = rank;
        //        dr[2] = textValue.Trim().Substring(0, 10);
        //        dr[3] = scoreDoc.Score;
        //        dr[4] = filepathValue;
        //        dt.Rows.Add(dr);
        //        rank++;
        //    }
        //    return dt;
        //}

        public void ResultBrowser(ScoreDoc[] docList, int pageIndex)
        {
            var totalNumOfDocs = docList.Length;
            for (int i = 0 + 10 * pageIndex; i < 10 + 10 * pageIndex; i++)
            {
                Console.WriteLine("Rank{0}: {1}", i + 1, docList[i]);
            }
        }

        public static string OutputFileContent(string name)
        {
            char[] delims = {' ', '\n'};
            System.IO.StreamReader reader = new System.IO.StreamReader(name);
            string text = "";
            string line = "";
//            int numWords = 0;
            while ((line = reader.ReadLine()) != null)
            {
                text += line;
            }

            reader.Close();

//            Console.WriteLine("Fileame " + name + " Word Count " + numWords);
            return text;
        }


        public static List<string> WalkDirectoryTree(String path)
        {
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }

            catch (UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            List<string> fileList = new List<string>();

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    string name = fi.FullName;
                    fileList.Add(OutputFileContent(name));
                }

//                // Now find all the subdirectories under this directory.
//                subDirs = root.GetDirectories();
//
//                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
//                {
//                    // Resursive call for each subdirectory.
//                    string name = dirInfo.FullName;
//                    WalkDirectoryTree(name);
//                }
            }

            return fileList;
        }

        public static DataTable ViewCurrenPage(DataTable table, DocInfo[] docList, int pageNum)
        {
            var pageIndex = pageNum - 1;
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("Bibliography", typeof(string));
            table.Columns.Add("1st sentence of the abstract", typeof(string));
            for (int i = 0 + pageIndex * 10; i < 10 + pageIndex * 10; i++)
            {
                DocInfo docInfo = docList[i];
//                DocInfo docInfo = LuceneAdvancedSearchApplication.OutputSections(doc);
                table.Rows.Add(i + 1, docInfo.Title, docInfo.Author, docInfo.Bibliography, docInfo.Sentence);
            }

            return table;
        }

        public static DataTable ViewLastPage(DataTable table, DocInfo[] docList, int pageNum)
        {
            var pageIndex = pageNum - 1;
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("Bibliography", typeof(string));
            table.Columns.Add("1st sentence of the abstract", typeof(string));
            for (int i = pageIndex * 10; i < docList.Length; i++)
            {
                DocInfo docInfo = docList[i];
//                DocInfo docInfo = LuceneAdvancedSearchApplication.OutputSections(doc);
                table.Rows.Add(i + 1, docInfo.Title, docInfo.Author, docInfo.Bibliography, docInfo.Sentence);
            }

            return table;
        }

        public static DocInfo ViewSelectedDocInfo(DocInfo[] docList, int selectedDocIndex)
        {
            DocInfo selectedDoc = docList[selectedDocIndex];

            return selectedDoc;
        }
    }
}