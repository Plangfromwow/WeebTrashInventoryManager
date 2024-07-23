using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeebTrashInventoryManager
{
    public  class CsvInteractor
    {

        //All functions need to be generic 
        // Read 

        public  List<T> ReadFromCSV<T>(string path)
        {
            List<T> list = new List<T>();
            //Reading from a CSV 
            using (var reader = new StreamReader($"{path}"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                try
                {
                    var records = csv.GetRecords<T>();
                    list.AddRange(records);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                csv.Dispose();
                reader.Dispose();
            }

            return list;
        }

        //Write functions
        //CreateNewFileWrite 

        public  void WriteToNewCSV<T>(string path, List<T> list)
        {

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }

        //Append 

        public  void AppendToCSV<T>(string path, List<T> list)
        {
            var appendConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                //Don't write the headers again.
                HasHeaderRecord = false,
            };

            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, appendConfig))
            {
                csv.WriteRecords(list);
            }
        }

        //Create the WhatNotFile
        public void CreateNewWhatNotCSV(List<WhatNotItem> scannedItems)
        {
             string csvPath = ".\\CSVs";
             string newCsv = csvPath + $"\\testOutput{DateTime.Now.ToString("yy-dd-MM")}.csv";

            WriteToNewCSV(newCsv, scannedItems);
        }

        //GetMetaData
        public List<ScannedInventoryItem> GetMetaData()
        {

           string path = ".\\CsvMetaDataSave\\WeebMetaData.csv";

           return ReadFromCSV<ScannedInventoryItem>(path);

        }

        


    }
}
