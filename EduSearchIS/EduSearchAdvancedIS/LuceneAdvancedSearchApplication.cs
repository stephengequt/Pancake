﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Support;
using Lucene.Net.Util;
//using SpellChecker.Net.Search.Spell;
using Syn.WordNet;

namespace EduSearchAdvancedIS
{
    class LuceneAdvancedSearchApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        IndexSearcher searcher;
        QueryParser parser;
        Similarity customizedSimilarity;

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        const string TEXT_FN = "Full text";

//        const string ID_FN = "ID";
//        const string FILEPATH_FN = "Filepath";
        const string TITLE_FN = "Title";
        const string AUTHOR_FN = "Author";
        private const string BIB_FN = "Bib";
        private const string ABS_FN = "Abs";
        public bool PreProcessOpt { get; set; } = true;
        public bool QueryExpansionOpt { get; set; }
        public WordNetEngine wordNet { get; set; }


        public LuceneAdvancedSearchApplication()
        {
            luceneIndexDirectory = null;
            writer = null;
//            analyzer = new Lucene.Net.Analysis.WhitespaceAnalyzer();
//            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer(); // Activity 5
//            analyzer = new Lucene.Net.Analysis.StopAnalyzer(Lucene.Net.Util.Version.LUCENE_30); // Activity 5
//            analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30); // Activity 5
            analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30,
                "English"); // Activity 7


            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, TEXT_FN, analyzer);
            customizedSimilarity = new CustomizedSimilarity();
            //newSimilarity = new NewSimilarity(); // Activity 9
        }

//        public void TestSpellChecker(string query)
//        {
//            RAMDirectory dir = new RAMDirectory();
//            IndexWriter iw = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), IndexWriter.MaxFieldLength.UNLIMITED);

//            Document d = new Document();
//            Field textField = new Field("text", "", Field.Store.YES, Field.Index.ANALYZED);
//            d.Add(textField);
//            Field idField = new Field("id", "", Field.Store.YES, Field.Index.NOT_ANALYZED);
//            d.Add(idField);

//            textField.SetValue("this is a document with a some words");
//            idField.SetValue("42");
//            iw.AddDocument(d);
//            ////////////////////////////////////////
////            writer.Commit();
//            IndexReader reader = writer.GetReader();

//            SpellChecker.Net.Search.Spell.SpellChecker speller = new SpellChecker.Net.Search.Spell.SpellChecker(new RAMDirectory());
//            speller.IndexDictionary(new LuceneDictionary(reader, TEXT_FN));
//            string[] suggestions = speller.SuggestSimilar(query, 5);


//            IndexSearcher searcher = new IndexSearcher(reader);
//            foreach (string suggestion in suggestions)
//            {
//                TopDocs docs = searcher.Search(new TermQuery(new Term("text", suggestion)), null, Int32.MaxValue);
//                foreach (var doc in docs.ScoreDocs)
//                {
//                    Console.WriteLine(searcher.Doc(doc.Doc).Get("id"));
//                }
//            }

//            reader.Dispose();
//            iw.Dispose();
//        }

        /// <summary>
        /// Creates the index at a given path
        /// </summary>
        /// <param name="indexPath">The pathname to create the index</param>
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            writer.SetSimilarity(customizedSimilarity); // Activity 9
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
            // Add field Author
            Lucene.Net.Documents.Field docAuthorField = new Field(AUTHOR_FN, docInfo.Author, Field.Store.YES,
                Field.Index.ANALYZED, Field.TermVector.YES);
            // Add field Title
            Lucene.Net.Documents.Field docTitleField = new Field(TITLE_FN, docInfo.Title, Field.Store.YES,
                Field.Index.ANALYZED, Field.TermVector.YES);
            //Add field Bibliography
            Lucene.Net.Documents.Field docBibliographyField = new Field(BIB_FN, docInfo.Bibliography, Field.Store.YES,
                Field.Index.ANALYZED, Field.TermVector.YES);
            //Add field Abstract
            Lucene.Net.Documents.Field docAbstractField = new Field(ABS_FN, docInfo.Abstract, Field.Store.YES,
                Field.Index.ANALYZED, Field.TermVector.YES);

            Lucene.Net.Documents.Document doc = new Document();
//            doc.Add(field);
            doc.Add(docAuthorField);
            doc.Add(docTitleField);
            doc.Add(docBibliographyField);
            doc.Add(docAbstractField);
            doc.Add(field);
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
        public void CreateSearcher(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);

            searcher = new IndexSearcher(luceneIndexDirectory) {Similarity = customizedSimilarity};
        }

        /// <summary>
        /// Searches the index for the querytext
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public SearchResult SearchText(string querytext, string searchField, bool ifTitleBoost, bool ifAuthorBoost,
            decimal titleBoostNum, decimal authorBoostNum)
        {
//            SpellChecker.Net.Search.Spell.SpellChecker spellChecker = new SpellChecker.Net.Search.Spell.SpellChecker(new RAMDirectory());

            System.Console.WriteLine("Searching for " + querytext);
            querytext = querytext.ToLower();
            if (!PreProcessOpt)
            {
                querytext = "\"" + querytext + "\"";
            }

            searchField = TEXT_FN;
            //            QueryParser queryParser = new QueryParser(VERSION, searchField, this.analyzer);
            //            Query query = queryParser.Parse(querytext);
            // TODO: multified needs to be fixed
            Query query = null;
            if (ifAuthorBoost || ifTitleBoost)
            {
                string[] fields = {TITLE_FN, AUTHOR_FN, BIB_FN, ABS_FN};

                HashMap<string, float> boosts = new HashMap<string, float>();
                //
                if (ifTitleBoost)
                {
                    boosts.Add(TITLE_FN, Convert.ToSingle(titleBoostNum));
                }

                if (ifAuthorBoost)
                {
                    boosts.Add(AUTHOR_FN, Convert.ToSingle(authorBoostNum));
                }

                MultiFieldQueryParser queryParser = new MultiFieldQueryParser(VERSION, fields, analyzer, boosts);
                query = queryParser.Parse(querytext);
            }
            else
            {
                query = parser.Parse(querytext);
            }


            // TODO: multiple an

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
                Sentence = firstLine.Trim(),
                Abstract = sections[5].Trim()
            };

            return docInfo;
        }


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
                // filter the file
                files = root.GetFiles("*.txt");
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

        public static DataGridView ViewCurrenPage(DataGridView dataGridView, DocInfo[] docList, int pageNum)
        {
            var pageIndex = pageNum - 1;
//            table.Columns.Add("Rank", typeof(int));
//            table.Columns.Add("Title", typeof(string));
//            table.Columns.Add("Author", typeof(string));
//            table.Columns.Add("Bibliography", typeof(string));
//            table.Columns.Add("1st sentence of the abstract", typeof(string));
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Visible = false;
            }


            for (int i = 0 + pageIndex * 10; i < 10 + pageIndex * 10; i++)
            {
                dataGridView.Rows[i].Visible = true;
            }

            //            for (int i = 0 + pageIndex * 10; i < 10 + pageIndex * 10; i++)
            //            {
            //                DocInfo docInfo = docList[i];
            //                //                DocInfo docInfo = LuceneAdvancedSearchApplication.OutputSections(doc);
            //                dataGridView.Rows.Add(i + 1, docInfo.Title, docInfo.Author, docInfo.Bibliography, docInfo.Sentence);
            //            }

            return dataGridView;
        }

        public static DataGridView ViewLastPage(DataGridView dataGridView, DocInfo[] docList, int pageNum)
        {
            var pageIndex = pageNum - 1;
//            table.Columns.Add("Rank", typeof(int));
//            table.Columns.Add("Title", typeof(string));
//            table.Columns.Add("Author", typeof(string));
//            table.Columns.Add("Bibliography", typeof(string));
//            table.Columns.Add("1st sentence of the abstract", typeof(string));
//            for (int i = pageIndex * 10; i < docList.Length; i++)
//            {
//                DocInfo docInfo = docList[i];
////                DocInfo docInfo = LuceneAdvancedSearchApplication.OutputSections(doc);
//                table.Rows.Add(i + 1, docInfo.Title, docInfo.Author, docInfo.Bibliography, docInfo.Sentence);
//            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Visible = false;
            }


            for (int i = 0 + pageIndex * 10; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Visible = true;
            }

            return dataGridView;
        }

        public static DocInfo ViewSelectedDocInfo(DocInfo[] docList, int selectedDocIndex)
        {
            DocInfo selectedDoc = docList[selectedDocIndex];

            return selectedDoc;
        }

        public string QueryExpansionByNetWord(string word, WordNetEngine wordNet)
        {
            var synSetList = wordNet.GetSynSets(word);

            if (synSetList.Count == 0)
            {
                return " ";
            }

            string wordExpansionWithoutOriginalWord = null;

            foreach (var synSet in synSetList)
            {
                List<string> synSetWordWithoutOriginalWord = new List<string>();
                foreach (var synSetWord in synSet.Words)
                {
                    if (synSetWord != word || !synSetWordWithoutOriginalWord.Contains(synSetWord.ToLower()))
                    {
                        synSetWordWithoutOriginalWord.Add(synSetWord);
                    }
                }

                wordExpansionWithoutOriginalWord += " " + string.Join(" ", synSetWordWithoutOriginalWord);
            }
//
//            string[] array = thesaurus[queryTerm];
//            foreach (string a in array)
//            {
//                expandedQuery += " " + a;
//            }

            return wordExpansionWithoutOriginalWord;
        }
    }
}