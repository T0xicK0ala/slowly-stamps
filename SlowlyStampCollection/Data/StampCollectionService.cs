using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;
using System.Collections.Generic;

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
    }
}
