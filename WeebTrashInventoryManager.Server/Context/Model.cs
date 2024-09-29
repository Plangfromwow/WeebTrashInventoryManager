using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace WeebTrashInventoryManager
{
    public class InventoryContext : DbContext
    {
        public DbSet<WhatNotItem> WhatNotItems { get; set; }
        public DbSet<ScannedInventoryItem> scannedInventoryItems { get; set; }

        public string dbPath { get; set; }

        public InventoryContext()
        {
            dbPath = System.IO.Path.GetFullPath("./MetaDataSave/MetaDataInfo.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source = {dbPath}");

    }
}
