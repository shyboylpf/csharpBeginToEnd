using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using HS;
using Nest;
using PetaPoco;

namespace ElasticSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var uris = new[]
            {
                new Uri("http://localhost:9202"),
                new Uri("http://localhost:9200"),
                new Uri("http://localhost:9201"),
            };

            var connectionPool = new SniffingConnectionPool(uris);
            var settings = new ConnectionSettings(connectionPool)
                .DefaultIndex("sampletypeexdata");

            var client = new ElasticClient(settings);
            //client.BulkAll(new List<AP_SP_SampleTypeExDatum>(), default);

            //var person = new Person
            //{
            //    Id = 1,
            //    FirstName = "Martijn",
            //    LastName = "Laarman"
            //};

            //var indexResponse = client.IndexDocument(person);

            //var asyncIndexResponse = await client.IndexDocumentAsync(person);

            //using (Database db = new Database("default"))
            //{
            //    foreach (AP_SP_SampleTypeExDatum item in db.Query<AP_SP_SampleTypeExDatum>(""))
            //    {
            //        var _ = client.IndexDocumentAsync(item);
            //        Console.WriteLine(item.id);
            //    }
            //}

            List<AP_SP_SampleTypeExDatum> models = new List<AP_SP_SampleTypeExDatum>();
            using (Database db = new Database("default"))
            {
                foreach (AP_SP_SampleTypeExDatum item in db.Query<AP_SP_SampleTypeExDatum>(""))
                {
                    models.Add(item);
                    if (models.Count == 4000)
                    {
                        client.IndexManyAsync(models);
                        models.Clear();
                        Console.WriteLine(item.id);
                    }
                }
                var _ = client.IndexManyAsync(models);
            }
        }

        private void Insert(ElasticClient client, AP_SP_SampleTypeExDatum model)
        {
            client.Index<AP_SP_SampleTypeExDatum>((IIndexRequest<AP_SP_SampleTypeExDatum>)model);
        }

        private void bulkInser(ElasticClient client, List<AP_SP_SampleTypeExDatum> models)
        {
            var indexResponse = client.BulkAll(models, default);
        }
    }
}