using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeebTrashInventoryManager
{
    internal class ScannedInventoryItem
    {
        [Name("BARCODE SCAN")]
        public string BarcodeScan { get; set; }
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



        public WhatNotItem ConvertScannedToWhatnot()
        {
            WhatNotItem newItem = new WhatNotItem()
            {
                Category = Category,
                SubCategory = SubCategory,
                Title = Title,
                Description = Description,
                Quantity = Quantity,
                WhatNotType = WhatNotType,
                Price = Price,
                ShippingProfile = ShippingProfile,
                Gradable = Gradable,
                ImageURL1 = ImageURL1,
                ImageURL2 = ImageURL2,
                ImageURL3 = ImageURL3,
                ImageURL4 = ImageURL4,
                ImageURL5 = ImageURL5,
                ImageURL6 = ImageURL6,
                ImageURL7 = ImageURL7,
                ImageURL8 = ImageURL8,
            };


            return newItem;

        }

        public override string ToString()
        {
            return $"Scanned Item: {Title} {Description} {Category} {SubCategory} {Price} {ShippingProfile} ";
        }
    }
}
