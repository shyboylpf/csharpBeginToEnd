using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearchQuery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var uris = new[]
            {
                new Uri("http://localhost:9200"),
                new Uri("http://localhost:9201"),
                new Uri("http://localhost:9202"),
            };

            var connectionPool = new SniffingConnectionPool(uris);
            var settings = new ConnectionSettings(connectionPool)
                .DefaultIndex("sampletypeexdata");

            var client = new ElasticClient(settings);

            var searchResponse = client.Search<AP_SP_SampleTypeExDatum>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.txtField35)
                        .Query("阴")
                     )
                )
                .Query(q => q
                     .Match(m => m
                        .Field(f => f.txtField34)
                        .Query("有")
                     )
                )
            //.Sort(q => q
            //    .Ascending(m => m.dateField2)
            //)
            );

            var models = searchResponse.Documents;
            List<int> ids = new List<int>();
            foreach (var item in models)
            {
                ids.Add(item.id);
            }
            Console.WriteLine(string.Join(",", ids));
        }
    }
}