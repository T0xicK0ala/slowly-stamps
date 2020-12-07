
namespace SlowlyStampCollection.Data
{
    public class Stamp
    {
        private static readonly string[] Colors = new[]
        {
            "gray", "black", "green", "blue", "purple", "red"
        };

        private static readonly string[] Difficulties = new[]
        {
            "Very Easy", "Easy", "Normal", "Hard", "Very Hard", "Impossible"
        };

        private static readonly string[] Categories = new[]
        {
            "Other", "Single Stamp", "Stamp Set", "Location Exclusive"
        };
        public string Slug { get; set; }
        public string Url { get { return @"https://cdn.getslowly.com/assets/images/stamp-sm/" + Slug + @".png"; } }
        public string StampName { get { return Slug + @".png"; } }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Method { get; set; }
        public int Category { get; set; }
        public string CategoryName { get { return Categories[Category]; } }
        public int Difficulty { get; set; }
        public string DifficultyCode { get { return Colors[Difficulty]; } }
        public string DifficultyName { get { return Difficulties[Difficulty]; } }
        public int Price { get; set; }
    }
}
