﻿using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeebTrashInventoryManager
{
    public static class CsvInteractor
    {

        //All functions need to be generic 
        // Read 

        public static List<T> ReadFromCSV<T>(string path)
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
            }

            return list;
        }

        //Write functions
        //CreateNewFileWrite 

        public static void WriteToNewCSV<T>(string path, List<T> list)
        {

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }

        //Append 

        public static void AppendToCSV<T>(string path, List<T> list)
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
    }
}
