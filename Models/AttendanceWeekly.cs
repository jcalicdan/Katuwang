using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class AttendanceWeekly
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }

        [DisplayName("Taon")]
        [Column(TypeName = "int")]
        public int year { get; set; }

        [DisplayName("Week Num.")]
        [Column(TypeName = "int")]
        public int weeknum { get; set; }

        [DisplayName("Purok")]
        [Column(TypeName = "int")]
        public int purok { get; set; }

        [DisplayName("Grupo")]
        [Column(TypeName = "int")]
        public int grupo { get; set; }

        [DisplayName("Destinado")]
        [Column(TypeName = "int")]
        public int destinadoid { get; set; }

        [DisplayName("Serial Number")]
        [Column(TypeName = "int")]
        public int serialnumber { get; set; }

        [DisplayName("Porsyento")]
        [Column(TypeName = "decimal")]
        public int porsyento { get; set; }

        [DisplayName("Created Date")]
        [Column(TypeName = "datetime")]
        public DateTime createdate { get; set; }

        [DisplayName("Created By")]
        [Column(TypeName = "varchar(100)")]
        public string createby { get; set; }

        [DisplayName("Modified Date")]
        [Column(TypeName = "date")]
        public DateTime modifieddate { get; set; }

        [DisplayName("Modified By")]
        [Column(TypeName = "varchar(100)")]
        public string modifiedby { get; set; }

        [DisplayName("Is Deleted")]
        [Column(TypeName = "int")]
        public int isdeleted { get; set; }
    }
}
