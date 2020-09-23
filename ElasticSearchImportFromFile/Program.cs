using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace ElasticSearchImportFromFile
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

            int counter = 0;
            string line;

            List<AP_SP_SampleTypeExDatum> models = new List<AP_SP_SampleTypeExDatum>();

            // Read the file and display it line by line.
            StreamReader file = new StreamReader(@"data172138395.txt");
            while ((line = file.ReadLine()) != null)
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<AP_SP_SampleTypeExDatum>(line);
                models.Add(model);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            foreach (var item in models)
            {
                var indexResponse = client.IndexDocument(item);
            }
            Console.WriteLine("end.");

            //var asyncIndexResponse = await client.IndexDocumentAsync(person);

            //using (Database db = new Database("default"))
            //{
            //    foreach (AP_SP_SampleTypeExDatum item in db.Query<AP_SP_SampleTypeExDatum>(""))
            //    {
            //        models.Add(item);
            //        if (models.Count == 4000)
            //        {
            //            //var indexResponse = client.IndexDocument(item);
            //            var indexResponse = client.BulkAll(models, default);
            //            models.Clear();
            //            Console.WriteLine(item.id);
            //        }
            //    }
            //}
        }
    }
}