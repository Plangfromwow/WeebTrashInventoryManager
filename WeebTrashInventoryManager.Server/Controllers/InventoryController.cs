using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeebTrashInventoryManager.Server.Controllers
{
    [ApiController]
    [Route("Inventory")]
    public class InventoryController : Controller
    {
        public CsvInteractor csvInteractor { get; } = new CsvInteractor();

        [HttpGet("AllItems")]
        public List<ScannedInventoryItem> GetItems()
        {
            List<ScannedInventoryItem> items = new List<ScannedInventoryItem>();
            string path = ".\\CsvMetaDataSave\\WeebMetaData.csv";

            items = csvInteractor.ReadFromCSV<ScannedInventoryItem>(path);
            Console.WriteLine("GetItems Controller hit");
            return items;

        }

        [HttpPost]
        public object AddItemsToMetaData([FromBody] List<ScannedInventoryItem> items)
        {
            try
            {
                string path = ".\\CsvMetaDataSave\\WeebMetaData.csv";
                csvInteractor.AppendToCSV<ScannedInventoryItem>(path, items);

                return new JsonResponseModel { Message = "Success", StatusCode = "200" };
            }
            catch (Exception ex) 
            { 
                return new JsonResponseModel { Message = $"Failed: {ex.Message}",StatusCode = "500" };
            }




        }
    }
}