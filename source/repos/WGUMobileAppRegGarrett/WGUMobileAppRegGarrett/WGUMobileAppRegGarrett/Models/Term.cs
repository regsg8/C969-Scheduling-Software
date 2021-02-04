using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGUMobileAppRegGarrett.Models
{
    [Table("Terms")]
    class Term
    {
        [PrimaryKey, AutoIncrement]
        public int TermId { get; set; }
        public int DegreeId { get; set; }
        public string Name { get; set; }
        //Storing Dates as ISO8601 strings ("YYYY-MM-DD HH:MM:SS.SSS")
        public string Start { get; set; }
        public string End { get; set; }
    }
}
