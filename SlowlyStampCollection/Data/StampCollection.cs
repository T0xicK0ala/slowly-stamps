
namespace SlowlyStampCollection.Data
{
    public class Stamp
    {
        private static readonly string[] Colors = new[]
        {
            "gray", 
            "black", 
            "green", 
            "blue", 
            "purple", 
            "red"
        };

        private static readonly string[] Difficulties = new[]
        {
            "Very Easy",  //0
            "Easy",  //1
            "Normal",  //2
            "Hard",  //3
            "Very Hard",  //4 
            "Impossible"  //5
        };

        private static readonly string[] Categories = new[]
        {
            "Other",  //0
            "Single Stamp",  //1
            "Stamp Set",  //2
            "Location Exclusive",  //3
            "Achievements",  //4
            "Time Machine"  //5
        };
        public string Slug { get; set; }
        public string Url { get { return @"https://cdn.getslowly.com/assets/images/stamp-sm/" + Slug + @".png"; } }
        public string StampName { get { return Slug + @".png"; } }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Availability { get; set; }
        public string Region { get; set; }
        public int Category { get; set; }
        public string CategoryName { get { return Categories[Category]; } }
        public int Difficulty { get; set; }
        public string DifficultyCode { get { return Colors[Difficulty]; } }
        public string DifficultyName { get { return Difficulties[Difficulty]; } }
        public int Price { get; set; }
    }
}
