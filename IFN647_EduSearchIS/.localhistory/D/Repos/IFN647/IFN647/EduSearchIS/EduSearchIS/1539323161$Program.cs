﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syn.WordNet;

namespace EduSearchIS
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
//            LuceneAdvancedSearchApplication myLuceneApp = new LuceneAdvancedSearchApplication();
//
//            // source collection
//            string path =
//                //Stephen
//                @"D:\Google Drive\QUT\Sem4\IFN647 Advanced Information Storage and Retrieval\Assessment2\collection\crandocs";
//           // Soam
////                  @"C:\Users\svege\Dropbox\Master sem 4\IR\Assignment\crandocs";
//            //Aaron
//            //@"D:\Google Drive\QUT\Sem4\IFN647 Advanced Information Storage and Retrieval\Assessment2\collection\crandocs";
//
//            List<string> fileList = WalkDirectoryTree(path);
//
//
//            // Index code
//            string indexPath =
//                //Stephen
//                @"D:\Google Drive\QUT\Sem4\IFN647 Advanced Information Storage and Retrieval\Assessment2\assessment2Index";
//            //Soam
////                @"C:\Users\svege\Dropbox\Master sem 4\IR\Assignment";
//            //Aaron
//            //@"D:\Google Drive\QUT\Sem4\IFN647 Advanced Information Storage and Retrieval\Assessment2\assessment2Index";
//
//            DateTime startIndexTime = System.DateTime.Now;
//
//            myLuceneApp.CreateIndex(indexPath);
//
//            System.Console.WriteLine("Adding Documents to Index");
//            int docID = 0;
//            foreach (string s in fileList)
//            {
//               // System.Console.WriteLine("Adding doc " + docID + "to Index");
//                myLuceneApp.IndexText(s);
//                docID++;
//            }
//
//            //Time for indexing
//            DateTime endIndexTime = System.DateTime.Now;
//            System.Console.WriteLine("All documents added, indexing time: {0}", endIndexTime - startIndexTime);
//
//            myLuceneApp.CleanUpIndexer();
//
//            // Searching Code
//            DateTime startSearchTime = System.DateTime.Now;
//            myLuceneApp.CreateSearcher();
//            var query =
//                "what \"similarity laws\" must be obeyed when constructing aeroelastic models of heated high speed aircraft";
//            myLuceneApp.SearchText(query);
//            // Time for searching
//            DateTime endSearchTime = System.DateTime.Now;
//            Console.WriteLine("Searching time: {0}", endSearchTime - startSearchTime);
//            myLuceneApp.CleanUpSearcher();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());

            WordNetEngine wordNet = WordNet.GetWordNetEngineInstance();

            while (true)
            {
                Console.WriteLine("\nType first word");
                var word = Console.ReadLine();
                var synSetList = wordNet.GetSynSets(word);

                if (synSetList.Count == 0) Console.WriteLine($"No SynSet found for '{word}'");

                foreach (var synSet in synSetList)
                {
                    var words = string.Join(", ", synSet.Words);

                    Console.WriteLine($"\nWords: {words}");
                    Console.WriteLine($"POS: {synSet.PartOfSpeech}");
                    Console.WriteLine($"Gloss: {synSet.Gloss}");
                }
            }


            Console.ReadLine();
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