﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<ScannedInventoryItem> GetItems()
        {
            Console.WriteLine("GetItems Controller hit");
            return itemsToAdd;
        }

        // Get all data short for Drop Down list for searching 
        [HttpGet("GetDataShort")]
        public object GetDataShort()
        {
           var data =   ShortData.GetShortData(MetaData);

           return new JsonResponseModel { Message = "Success", ResponseObject = data, StatusCode = "200" };

        }

        [HttpGet("AddItem")]
        public object AddItem(string id)
        {
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
                    return new JsonResponseModel { Message="Success", ResponseObject = itemsToAdd, StatusCode= "200" };
                    
                }
            }

            return new JsonResponseModel { Message = "Item not found", ResponseObject = itemsToAdd, StatusCode = "404"};
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