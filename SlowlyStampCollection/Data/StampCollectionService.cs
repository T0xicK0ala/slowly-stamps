using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.IO;
using System.Net;
using System.Text;

namespace SlowlyStampCollection.Data
{
    public class StampCollectionService
    {
        private static readonly string uri = @"https://api.getslowly.com/slowly";
        private static async Task GenerateData(string ver, string json)
        {
            string url = string.Format(@"Slowly\json{0}.json", ver);
            try
            {
                if (!File.Exists(url))
                {
                    await File.WriteAllTextAsync(url, json);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static SlowlyData DeserielizeSlowlyData()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                using WebClient client = new WebClient();
                var jsonStr = client.DownloadString(uri);
                var deserielizedJson = JsonSerializer.Deserialize<SlowlyData>(jsonStr, options);
                var jsonVersion = deserielizedJson.Ver.ToString();
                _ = GenerateData(jsonVersion, jsonStr);
                return deserielizedJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Item[]> GetStampAsync()
        {
            return Task.FromResult(DeserielizeSlowlyData().Items.Where(i => i.Item_group != "placeholder").OrderByDescending(i => i.Id).ToArray());
        }

        public Task<Lang[]> GetLanguageAsync()
        {
            return Task.FromResult(DeserielizeSlowlyData().Lang.OrderByDescending(l => l.Count).ToArray());
        }

        public async Task SaveFeedback(Feedback feedback)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string file = string.Format(@"Feedback\feedback_{0}.txt", timestamp);
            string content = FeedbackContentBuilder(timestamp, feedback);
            try
            {
                if (!File.Exists(file))
                {
                    await File.WriteAllTextAsync(file, content);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string FeedbackContentBuilder(string timestamp, Feedback feedback)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Feedback received at ");
            sb.Append(timestamp);
            sb.AppendLine();
            sb.AppendLine();
            sb.Append(feedback.Content);
            sb.AppendLine();
            sb.AppendLine();
            sb.Append("Name: ");
            sb.Append(feedback.Name);
            sb.AppendLine();
            sb.Append("---EOF---");
            return sb.ToString();
        }
    }
}
