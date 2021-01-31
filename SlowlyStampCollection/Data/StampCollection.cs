
using System;
using System.Collections.Generic;

namespace SlowlyStampCollection.Data
{
    public class SlowlyData
    {
        public int Ver { get; set; }
        public List<Lang> Lang { get; set; }
        public List<Item> Items { get; set; }
        public List<Tag> Tags { get; set; }
        public int Sharequota { get; set; }
        public int Sharequotareset { get; set; }
    }

    public class Lang
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Native { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }
    }

    public class Item
    {
        public int PriceCal()
        {
            if (Convert.ToInt32(Price) == -1)
                return 0;
            if (Convert.ToInt32(Price) == 2)
                return 50;
            else
                return 100;
        }


        private static readonly string BaseUrl = @"https://cdn.getslowly.com/assets/images/stamp-sm/";
        private static readonly string FileExtension = @".png";
        public string Url { get { return string.Format("{0}{1}{2}", BaseUrl, Slug, FileExtension); } }
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Credit { get; set; }
        public string Type { get; set; }
        // item_set_id
        // item_group
        public string Rarity { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }

        public string Country { get; set; }
        public ItemSet Item_set { get; set; }
    }
    public class ItemSet
    {
        public int? id { get; set; }
        public string updated_at { get; set; }

    }

    public class Tag
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Suggest { get; set; }
    }

    #region Retired class
    //public class Stamp
    //{
    //    private static readonly string BaseUrl = @"https://cdn.getslowly.com/assets/images/stamp-sm/";
    //    private static readonly string FileExtension = @".png";

    //    private static readonly string[] Categories = new[]
    //    {
    //        "Time Machine",      //0
    //        "World Explorer",    //1
    //        "Region Exclusive",  //2
    //        "Single Stamp",      //3
    //        "Stamp Set",         //4
    //        "Other"              //5
    //    };

    //    private static readonly string[,] Difficulties = new string[6,2]
    //    {
    //        { "Very Easy", "gray" },    //0
    //        { "Easy","black" },         //1
    //        { "Normal", "green" },      //2
    //        { "Hard", "blue" },         //3
    //        { "Very Hard", "purple" },  //4 
    //        { "Impossible", "red" }     //5
    //    };

    //    public string Slug { get; set; }
    //    public string Url { get { return string.Format("{0}{1}{2}", BaseUrl, Slug, FileExtension); } }
    //    public string StampName { get { return string.Format("{0}{1}", Slug, FileExtension); } }
    //    public string Title { get; set; }
    //    public string Desc { get; set; }
    //    public string Availability { get; set; }
    //    public int Category { get; set; }
    //    public string CategoryName { get { return Categories[Category]; } }
    //    public int Difficulty { get; set; }
    //    public string DifficultyColor { get { return Difficulties[Difficulty, 1]; } }
    //    public string DifficultyName { get { return Difficulties[Difficulty, 0]; } }
    //    public int Price { get; set; }
    //    public string Region { get; set; }
    //}
    #endregion
}
