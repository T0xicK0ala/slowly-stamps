
namespace SlowlyStampCollection.Data
{
    public class Stamp
    {
        private static readonly string BaseUrl = @"https://cdn.getslowly.com/assets/images/stamp-sm/";
        private static readonly string FileExtension = @".png";

        private static readonly string[] Categories = new[]
        {
            "Time Machine",      //0
            "World Explorer",    //1
            "Region Exclusive",  //2
            "Single Stamp",      //3
            "Stamp Set",         //4
            "Other"              //5
        };

        private static readonly string[,] Difficulties = new string[6,2]
        {
            { "Very Easy", "gray" },    //0
            { "Easy","black" },         //1
            { "Normal", "green" },      //2
            { "Hard", "blue" },         //3
            { "Very Hard", "purple" },  //4 
            { "Impossible", "red" }     //5
        };

        public string Slug { get; set; }
        public string Url { get { return string.Format("{0}{1}{2}", BaseUrl, Slug, FileExtension); } }
        public string StampName { get { return string.Format("{0}{1}", Slug, FileExtension); } }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Availability { get; set; }
        public int Category { get; set; }
        public string CategoryName { get { return Categories[Category]; } }
        public int Difficulty { get; set; }
        public string DifficultyColor { get { return Difficulties[Difficulty, 1]; } }
        public string DifficultyName { get { return Difficulties[Difficulty, 0]; } }
        public int Price { get; set; }
        public string Region { get; set; }
    }
}
