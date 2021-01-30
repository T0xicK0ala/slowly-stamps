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
        private readonly string uri = @"https://api.getslowly.com/slowly";

        public Task<Item[]> GetStampAsync()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            using WebClient client = new WebClient();
            var json = client.DownloadString(uri);
            var deserielizedJson = JsonSerializer.Deserialize<SlowlyData>(json, options);
            var jsonVersion = deserielizedJson.ver.ToString();
            _ = GenerateData(jsonVersion, json);
            return Task.FromResult(deserielizedJson.Items.OrderByDescending(i => i.id).ToArray());
        }

        private static async Task GenerateData(string ver, string json)
        {
            string url = string.Format(@"Slowly\json{0}.json", ver);
            try
            {
                await File.WriteAllTextAsync(url, json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
