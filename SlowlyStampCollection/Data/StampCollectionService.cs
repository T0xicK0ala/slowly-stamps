using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;

namespace SlowlyStampCollection.Data
{
    public class StampCollectionService
    {
        public Task<Stamp[]> GetStampAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return Task.FromResult(JsonSerializer.Deserialize<Stamp[]>(File.ReadAllText(@"Data\stamps.json"), options).ToArray());
        }
        public Task<Item[]> GetSlowlyDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };


            using WebClient wc = new WebClient();

            var json = wc.DownloadString("https://api.getslowly.com/slowly");

            var abc = Task.FromResult(JsonSerializer.Deserialize<SlowlyData>(json, options).Items.ToArray());
            

            
            return abc;
            //return Task.FromResult(JsonSerializer.Deserialize<SlowlyData[]>(, options).ToArray());
        }
    }
}
