using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class Destinado
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }

        [DisplayName("Unang Pangalan")]
        [Column(TypeName = "varchar(100)")]
        public string givenname { get; set; }

        [DisplayName("Pangalan sa Ina")]
        [Column(TypeName = "varchar(100)")]
        public string mothersname { get; set; }

        [DisplayName("Pangalan sa Ama")]
        [Column(TypeName = "varchar(100)")]
        public string fathersname { get; set; }

        [DisplayName("Suffix")]
        [Column(TypeName = "varchar(10)")]
        public string suffix { get; set; }

        [DisplayName("Uri")]
        [Column(TypeName = "varchar(20)")]
        public string type { get; set; }

        [DisplayName("Assigned Number")]
        [Column(TypeName = "varchar(10)")]
        public string assignednum { get; set; }

        [DisplayName("Umpisa")]
        [Column(TypeName = "datetime")]
        public DateTime entrydate { get; set; }

        [DisplayName("Natapos")]
        [Column(TypeName = "datetime")]
        public DateTime enddate { get; set; }

        [DisplayName("Purok")]
        [Column(TypeName = "int")]
        public int purok { get; set; }

        [DisplayName("Grupo Start")]
        [Column(TypeName = "int")]
        public int grupostart { get; set; }

        [DisplayName("Grupo End")]
        [Column(TypeName = "int")]
        public int grupoend { get; set; }

        [DisplayName("INOUT")]
        [Column(TypeName = "int")]
        public int isactive { get; set; }

        [DisplayName("Remarks1")]
        [Column(TypeName = "varchar(250)")]
        public string remarks1 { get; set; }

        [DisplayName("Remarks2")]
        [Column(TypeName = "varchar(250)")]
        public string remarks2 { get; set; }

        [DisplayName("Remarks3")]
        [Column(TypeName = "varchar(250)")]
        public string remarks3 { get; set; }

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
