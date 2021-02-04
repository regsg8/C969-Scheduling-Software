using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGUMobileAppRegGarrett.Models
{
    [Table("Courses")]
    class Course
    {
        [PrimaryKey, AutoIncrement]
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        //Storing Dates as ISO8601 strings ("YYYY-MM-DD HH:MM:SS.SSS")
        public string Start { get; set; }
        public string End { get; set; }
        //SQLite stores bool as int, 0 = false, 1 = true
        public int StartNotification { get; set; }
        public int EndNotification { get; set; }     
    }
}
