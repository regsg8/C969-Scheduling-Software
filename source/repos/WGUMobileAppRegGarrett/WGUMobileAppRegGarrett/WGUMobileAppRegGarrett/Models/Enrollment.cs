using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace WGUMobileAppRegGarrett.Models
{
    [Table("Enrollments")]
    class Enrollment
    {
        [PrimaryKey, AutoIncrement]
        public int EnrollmentId { get; set; }
        public int TermId { get; set; }
        public int CourseId { get; set; }
    }
}
