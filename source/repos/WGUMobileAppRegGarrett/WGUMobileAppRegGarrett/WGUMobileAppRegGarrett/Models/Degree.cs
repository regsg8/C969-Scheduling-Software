using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGUMobileAppRegGarrett.Models
{
    [Table("Degrees")]
    class Degree
    {
        [PrimaryKey, AutoIncrement]
        public int DegreeId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        //SQLite stores bool as int, 0 = false, 1 = true
        public int Active { get; set; }
        
    }
}
