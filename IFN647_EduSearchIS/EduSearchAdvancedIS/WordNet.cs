﻿using System;
using System.IO;
using Syn.WordNet;

namespace EduSearchAdvancedIS
{
    class WordNet
    {
        protected const string WordNet_Dir = @"D:\Repos\IFN647\IFN647\EduSearchIS\WordNetDatabase";
        public static WordNetEngine GetWordNetEngineInstance()
        {
            WordNetEngine wordNet = new WordNetEngine();

            wordNet.AddDataSource(new StreamReader(Path.Combine(WordNet_Dir, "data.adj")), PartOfSpeech.Adjective);
            wordNet.AddDataSource(new StreamReader(Path.Combine(WordNet_Dir, "data.adv")), PartOfSpeech.Adverb);
            wordNet.AddDataSource(new StreamReader(Path.Combine(WordNet_Dir, "data.noun")), PartOfSpeech.Noun);
            wordNet.AddDataSource(new StreamReader(Path.Combine(WordNet_Dir, "data.verb")), PartOfSpeech.Verb);

            wordNet.AddIndexSource(new StreamReader(Path.Combine(WordNet_Dir, "index.adj")), PartOfSpeech.Adjective);
            wordNet.AddIndexSource(new StreamReader(Path.Combine(WordNet_Dir, "index.adv")), PartOfSpeech.Adverb);
            wordNet.AddIndexSource(new StreamReader(Path.Combine(WordNet_Dir, "index.noun")), PartOfSpeech.Noun);
            wordNet.AddIndexSource(new StreamReader(Path.Combine(WordNet_Dir, "index.verb")), PartOfSpeech.Verb);

            Console.WriteLine("Loading WordNet database....");
            wordNet.Load();
            Console.WriteLine("WordNet Loaded.");


            return wordNet;
        }
    }
}
