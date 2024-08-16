using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using WeebTrashInventoryManager.Server.Models;

namespace WeebTrashInventoryManager.Server.Controllers
{
    [ApiController]
    [Route("Inventory")]
    public class InventoryController : Controller 
    { 
        public static List<ScannedInventoryItem> MetaData { get; set; }
        public CsvInteractor csvInteractor { get; set; }
        public static List<ScannedInventoryItem> itemsToAdd { get; set; }

        public InventoryController() 
        {
            if (csvInteractor == null)
            {
                csvInteractor = new CsvInteractor();
            }
            if (MetaData == null)
                MetaData = csvInteractor.GetMetaData();
            if(itemsToAdd == null)
                itemsToAdd = new List<ScannedInventoryItem>();
        }

        [HttpGet("AllItems")]
        public object GetItems()
        {
            Console.WriteLine("GetItems Controller hit");

            AllItemsResponseObject data = new AllItemsResponseObject()
                {
                    Total = itemsToAdd.Count, 
                    Items = itemsToAdd
                };

            return new JsonResponseModel { Message = "Success", ResponseObject = data, StatusCode = "200" };
        }

        // Get all data short for Drop Down list for searching 
        [HttpGet("AllDataShort")]
        public object AllDataShort()
        {
            Console.WriteLine("AllDataShortHit");

           var data =   ShortData.GetShortData(MetaData);

           return new JsonResponseModel { Message = "Success", ResponseObject = data, StatusCode = "200" };

        }

        [HttpGet("AddItem")]
        public object AddItem(string id)
        {
            AllItemsResponseObject data = new AllItemsResponseObject();
            Console.WriteLine("Get items controller hit.");
            bool exists = false;
            foreach (ScannedInventoryItem item in MetaData)
            {
                if (item.BarcodeScan == id)
                {
                    foreach(var j in itemsToAdd)
                    {
                        if (j.BarcodeScan == id)
                        {
                            exists = true;
                            int quantity = int.Parse(j.Quantity);
                            quantity += 1;
                            j.Quantity = quantity.ToString();
                            break;
                        }
                    }
                    if(exists == false)
                        itemsToAdd.Add(item);
                    data = GetResponseObject();
                    return new JsonResponseModel { Message="Success", ResponseObject = data, StatusCode= "200" };
                    
                }
            }
            data = GetResponseObject() ;
            return new JsonResponseModel { Message = "Item not found", ResponseObject = data, StatusCode = "404"};
        }

        public AllItemsResponseObject GetResponseObject()
        {
            var data = new AllItemsResponseObject() {Total = itemsToAdd.Count,Items = itemsToAdd };
            return data;
        }

        public class ScannedItemResponse
        {
            public string BarcodeScan { get; set; }
            public string Message { get; set; }


        }


        [HttpGet("CreateWhatNotCSV")]
        public object CreateWhatNotCSV()
        {

            List<WhatNotItem> whatNotItems = new List<WhatNotItem>();
            foreach (var item in itemsToAdd) 
            {
                whatNotItems.Add(item.ConvertScannedToWhatnot());
            }

            csvInteractor.CreateNewWhatNotCSV(whatNotItems);

            return new JsonResponseModel { Message = $"Item written to: CSVFolder", StatusCode = "200" };
        }


    }
}