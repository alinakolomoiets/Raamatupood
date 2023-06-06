using Raamatupood.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raamatupood.Models
{
    public class RaamatuRepository
    {
        SQLiteConnection database;
        public RaamatuRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Raamat>();

        }
        public List<string> GetDistinctKategooriad()
        {
            return database.Table<Raamat>().Select(raamat => raamat.RaamatuKategooria).Distinct().ToList();
        }

        public List<Raamat> GetItemsByKategooria(string kategooria)
        {
            return database.Table<Raamat>().Where(raamat => raamat.RaamatuKategooria == kategooria).ToList();
        }
        public List<Raamat> GetItems()
        {
            return database.Table<Raamat>().ToList();
        }
        public Raamat GetItem(int id)
        {
            return database.Get<Raamat>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Raamat>(id);
        }
        public int SaveItem(Raamat item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
