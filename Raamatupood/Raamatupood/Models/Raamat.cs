using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raamatupood.Models
{
    [Table("Raamat")]
    public class Raamat
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string RaamatuPealkiri { get; set; }
        public string RaamatuAutor { get; set; }
        public string RaamatuKirjeldus { get; set; }
        public string RaamatuKategooria { get; set; }
        public string RaamatuPilt { get; set; }
        public string RaamatuHind { get; set; }
    }
}
