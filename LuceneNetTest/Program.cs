using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System;

namespace LuceneNetTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Ensures index backwards compatibility
            var AppLuceneVersion = LuceneVersion.LUCENE_48;

            var indexLocation = @"C:\Index";
            var dir = FSDirectory.Open(indexLocation);

            //create an analyzer to process the text
            var analyzer = new StandardAnalyzer(AppLuceneVersion);

            //create an index writer
            var indexConfig = new IndexWriterConfig(AppLuceneVersion, analyzer);
            var writer = new IndexWriter(dir, indexConfig);

            var source = new
            {
                Name = "Kermit the Frog",
                FavoritePhrase = "The quick brown fox jumps over the lazy dog"
            };
            Document doc = new Document
            {
                // StringField indexes but doesn't tokenize
                new StringField("name",
                    source.Name,
                    Field.Store.YES),
                new TextField("favoritePhrase",
                    source.FavoritePhrase,
                    Field.Store.YES)
            };

            writer.AddDocument(doc);
            writer.Flush(triggerMerge: false, applyAllDeletes: false);

            // search with a phrase
            var phrase = new MultiPhraseQuery();
            phrase.Add(new Term("favoritePhrase", "brown"));
            phrase.Add(new Term("favoritePhrase", "fox"));

            // re-use the writer to get real-time updates
            var searcher = new IndexSearcher(writer.GetReader(applyAllDeletes: true));
            var hits = searcher.Search(phrase, 20 /* top 20 */).ScoreDocs;
            foreach (var hit in hits)
            {
                var foundDoc = searcher.Doc(hit.Doc);
                float score = hit.Score;
                Console.WriteLine("--结果 num {0}, 耗时 {1}", 1, score);
                Console.WriteLine("--ID: {0}", foundDoc.Get("name"));
                Console.WriteLine("--Text found: {0}" + Environment.NewLine, foundDoc.Get("favoritePhrase"));
                //hit.Score.Dump("Score");
                //foundDoc.Get("name").Dump("Name");
                //foundDoc.Get("favoritePhrase").Dump("Favorite Phrase");
            }
        }
    }
}