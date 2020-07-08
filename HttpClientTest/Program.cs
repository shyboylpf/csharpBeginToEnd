using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientTest
{
    internal class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private static readonly HttpClient client = new HttpClient();

        static Program()
        {
            client.BaseAddress = new Uri("http://localhost:60830");
        }

        private static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                //HttpResponseMessage response = await client.GetAsync("");
                //HttpResponseMessage response = await client.PostAsync("/api/token/GenTokenByUser?userNo=admin&pwd=111222&tokenType=Service", null);
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhZG1pbiIsIm5hbWVpZCI6ImFkbWluIiwiUm9sZSI6IiIsIlByb2plY3QiOiIiLCJUb2tlblR5cGUiOiJTZXJ2aWNlIiwiaWF0IjoiMjAyMC83LzcgMTA6NDk6NTAiLCJleHAiOjE1OTkzMDI5OTAsImlzcyI6IndsaW1zIiwiYXVkIjoiYXBwIn0._Pc1NalMleUP9-sjhoVmfdlEFqXel7ieBnp3URYx5bQ");
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhZG1pbiIsIm5hbWVpZCI6ImFkbWluIiwiUm9sZSI6IiIsIlByb2plY3QiOiIiLCJUb2tlblR5cGUiOiJTZXJ2aWNlIiwiaWF0IjoiMjAyMC83LzcgMTA6NDk6NTAiLCJleHAiOjE1OTkzMDI5OTAsImlzcyI6IndsaW1zIiwiYXVkIjoiYXBwIn0._Pc1NalMleUP9-sjhoVmfdlEFqXel7ieBnp3URYx5bQ");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");

                //HttpResponseMessage response = await client.PostAsync("/api/DeviceCollect/addDataCollectData_Collector", null);
                CollectorJSON collectorJSON = new CollectorJSON()
                {
                    collectorNo = "10000000",
                    warningMalfunctionCode = "1,2",
                    collectDt = DateTime.Now,
                    collectUpDatas = new List<CollectData>()
                    {
                        new CollectData()
                        {
                            collectorTunnelTag="InTmp818",
                            collectVal1=2,
                             warningMinCollectVal1 =40,
                             warningMaxCollectVal1 =100,
                            collectDt=DateTime.Now,
                        }
                    }
                };
                var response = await client.PostAsJsonAsync("/api/DeviceCollect/addDataCollectData_Collector", collectorJSON);
                //response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode)
                {
                    await GenTokenByUser();
                    response = await client.PostAsJsonAsync("/api/DeviceCollect/addDataCollectData_Collector", collectorJSON);
                }
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public static async Task GenTokenByUser()
        {
            client.DefaultRequestHeaders.Authorization = null;
            HttpResponseMessage response = await client.PostAsync("/api/token/GenTokenByUser?userNo=admin&pwd=111222&tokenType=Service", null);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                client.DefaultRequestHeaders.Add("Authorization", JsonConvert.DeserializeObject<Reponse>(responseBody.ToString()).data);
                //Console.WriteLine(client.DefaultRequestHeaders.Authorization);
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", JsonConvert.DeserializeObject<Reponse>(responseBody.ToString()).data.Split(' ')[1]); ;
            }
        }
    }

    public class Reponse
    {
        public int code { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }

    public class CollectorJSON
    {
        public string collectorNo { get; set; }

        //设备故障编码
        public string warningMalfunctionCode { get; set; }

        //设备故障描述
        public string warningMalfunctionDesc { get; set; }

        //上传时间
        public DateTime collectDt { get; set; }

        public List<CollectData> collectUpDatas { get; set; }
    }

    public class CollectData
    {
        public string collectorTunnelTag { get; set; }
        public double collectVal1 { get; set; }
        public double collectVal2 { get; set; }
        public double? warningMinCollectVal1 { get; set; } //没有时传null
        public double? warningMaxCollectVal1 { get; set; } //没有时传null
        public DateTime collectDt { get; set; }
    }
}