namespace WeebTrashInventoryManager.Server.Models
{
    public class ShortData
    {
        public string BarcodeScan { get; set; }
        public string Name { get; set; }


        public static List<ShortData> GetShortData(List<ScannedInventoryItem> metaData)
        {
            List<ShortData> shortData = new List<ShortData>();

            foreach (var item in metaData) 
            {
                shortData.Add(new ShortData(){ Name = item.Title, BarcodeScan = item.BarcodeScan });
            }

            return shortData;
        }

    }
}
