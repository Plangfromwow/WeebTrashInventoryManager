using CsvHelper;
using CsvHelper.Configuration.Attributes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WeebTrashInventoryManager;

namespace WeebTrashInventoryManager
{
    public class WhatNotItem
    {
        [Name("Category")]
        public string Category { get; set; }
        [Name("Sub Category")]
        public string SubCategory { get; set; }
        [Name("Title")]
        public string Title { get; set; }
        [Name("Description")]
        public string Description { get; set; }
        [Name("Quantity")]
        public string Quantity { get; set; }
        [Name("Type")]
        public string WhatNotType { get; set; }
        [Name("Price")]
        public string Price { get; set; }
        [Name("Shipping Profile")]
        public string ShippingProfile { get; set; }
        [Name("Gradable")]
        public string Gradable { get; set; } = "False";
        [Name("Offerable")]
        public string Offerable { get; } = "False";
        [Name("Hazmat")]
        public string Hazmat { get; } = "Not Hazmat";
        [Name("Image URL 1")]
        public string ImageURL1 { get; set; }
        [Name("Image URL 2")]
        public string ImageURL2 { get; set; }
        [Name("Image URL 3")]
        public string ImageURL3 { get; set; }
        [Name("Image URL 4")]
        public string ImageURL4 { get; set; }
        [Name("Image URL 5")]
        public string ImageURL5 { get; set; }
        [Name("Image URL 6")]
        public string ImageURL6 { get; set; }
        [Name("Image URL 7")]
        public string ImageURL7 { get; set; }
        [Name("Image URL 8")]
        public string ImageURL8 { get; set; }

        public WhatNotItem ConvertScannedToWhatnot(ScannedInventoryItem scannedItem)
        {
            WhatNotItem newItem = new WhatNotItem()
            {
                Category = scannedItem.Category,
                SubCategory = scannedItem.SubCategory,
                Title = scannedItem.Title,
                Description = scannedItem.Description,
                Quantity = scannedItem.Quantity,
                WhatNotType = scannedItem.WhatNotType,
                Price = scannedItem.Price,
                ShippingProfile = scannedItem.ShippingProfile,
                Gradable = scannedItem.Gradable,
                ImageURL1 = scannedItem.ImageURL1,
                ImageURL2 = scannedItem.ImageURL2,
                ImageURL3 = scannedItem.ImageURL3,
                ImageURL4 = scannedItem.ImageURL4,
                ImageURL5 = scannedItem.ImageURL5,
                ImageURL6 = scannedItem.ImageURL6,
                ImageURL7 = scannedItem.ImageURL7,
                ImageURL8 = scannedItem.ImageURL8,
            };


            return newItem;

        }

        public override string ToString()
        {
            return $"Whatnot Item: {Title} {Description} {Category} {SubCategory} {Price} {ShippingProfile} ";
        }
    }
}

public class DBWhatnotItem
{
    [Key]
    [Name("ID")]
    public long Id { get; set; }
    [Name("Category")]
    public string Category { get; set; }
    [Name("Sub Category")]
    public string SubCategory { get; set; }
    [Name("Title")]
    public string Title { get; set; }
    [Name("Description")]
    public string Description { get; set; }
    [Name("Quantity")]
    public string Quantity { get; set; }
    [Name("Type")]
    public string WhatNotType { get; set; }
    [Name("Price")]
    public string Price { get; set; }
    [Name("Shipping Profile")]
    public string ShippingProfile { get; set; }
    [Name("Gradable")]
    public string Gradable { get; set; } = "False";
    [Name("Offerable")]
    public string Offerable { get; } = "False";
    [Name("Hazmat")]
    public string Hazmat { get; } = "Not Hazmat";
    [Name("Image URL 1")]
    public string ImageURL1 { get; set; }
    [Name("Image URL 2")]
    public string ImageURL2 { get; set; }
    [Name("Image URL 3")]
    public string ImageURL3 { get; set; }
    [Name("Image URL 4")]
    public string ImageURL4 { get; set; }
    [Name("Image URL 5")]
    public string ImageURL5 { get; set; }
    [Name("Image URL 6")]
    public string ImageURL6 { get; set; }
    [Name("Image URL 7")]
    public string ImageURL7 { get; set; }
    [Name("Image URL 8")]
    public string ImageURL8 { get; set; }

    public DBWhatnotItem ConvertScannedToDBWhatnot(ScannedInventoryItem scannedItem)
    {
        DBWhatnotItem newItem = new DBWhatnotItem()
        {
            Id = 0,
            Category = scannedItem.Category,
            SubCategory = scannedItem.SubCategory,
            Title = scannedItem.Title,
            Description = scannedItem.Description,
            Quantity = scannedItem.Quantity,
            WhatNotType = scannedItem.WhatNotType,
            Price = scannedItem.Price,
            ShippingProfile = scannedItem.ShippingProfile,
            Gradable = scannedItem.Gradable,
            ImageURL1 = scannedItem.ImageURL1,
            ImageURL2 = scannedItem.ImageURL2,
            ImageURL3 = scannedItem.ImageURL3,
            ImageURL4 = scannedItem.ImageURL4,
            ImageURL5 = scannedItem.ImageURL5,
            ImageURL6 = scannedItem.ImageURL6,
            ImageURL7 = scannedItem.ImageURL7,
            ImageURL8 = scannedItem.ImageURL8,
        };


        return newItem;

    }

    public override string ToString()
    {
        return $"DB Whatnot Item: {Title} {Description} {Category} {SubCategory} {Price} {ShippingProfile} ";
    }
}
