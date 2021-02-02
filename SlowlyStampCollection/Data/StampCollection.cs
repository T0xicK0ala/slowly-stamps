
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        #region Customised fields
        public string PriceCal()
        {
            if (Convert.ToInt32(Price) == -1) // free
                return "0";
            if (Convert.ToInt32(Price) == 0) // cannot buy
                return "n/a";
            if (Convert.ToInt32(Price) == 1) // set
                return "100";
            if (Convert.ToInt32(Price) == 2) { // other
                if (Item_set == null)
                    return "50";
                else
                    return Item_set.Price.ToString();
            }
            else
                return "";
        }

        public string RarityConvertion()
        {
            if (Convert.ToInt32(Rarity) == -1) 
                return "?";
            if (Convert.ToInt32(Rarity) == 1)
                return "normal";
            if (Convert.ToInt32(Rarity) == 2)
                return "rare";
            else
                return "";
        }

        private static readonly string BaseUrl = @"https://cdn.getslowly.com/assets/images/stamp-sm/";
        private static readonly string BaseUrlL = @"https://cdn.getslowly.com/assets/images/stamp/";
        private static readonly string FileExtension = @".png";
        public string Url { get { return string.Format("{0}{1}{2}", BaseUrl, Slug, FileExtension); } }
        public string UrlL { get { return string.Format("{0}{1}{2}", BaseUrlL, Slug, FileExtension); } }
        public string StampName { get { return string.Format("{0}{1}", Slug, FileExtension); } }
        #endregion
        #region Data fields
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Credit { get; set; }
        public string Type { get; set; }
        public int? Item_set_id { get; set; }
        public string Item_group { get; set; }    
        public string Rarity { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public string Img { get; set; }
        public double? Weight { get; set; }
        public string Country { get; set; }
        public Item_set Item_set { get; set; }
        #endregion
    }
    public class Item_set
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Single_bg { get; set; }
        public string Credit { get; set; }
        public string Collection_type { get; set; }
        public string Url { get; set; }
        public string Starttime { get; set; }
        public string Endtime { get; set; }
        public int Discount { get; set; }
        public int Items_count { get; set; }
        public int Price { get; set; }
        public int? Original_price { get; set; }
        public int Status { get; set; }
        public double? Weight { get; set; }
        public int Rank { get; set; }
        public string Updated_at { get; set; }
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public int Suggest { get; set; }
    }

    #region Other models
    public class Feedback
    {
        public string Content { get; set; }
        public string Name { get; set; }
    }
    #endregion

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
