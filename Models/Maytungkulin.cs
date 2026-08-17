using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class Maytungkulin
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }

        [DisplayName("Masterlist ID")]
        public int masterlistid { get; set; }

        [ForeignKey("masterlistid")]
        public virtual Masterlist Masterlist { get; set; }

        [DisplayName("Tungkulin")]
        [Column(TypeName = "varchar(100)")]
        public string duty { get; set; }

        [DisplayName("Section")]
        [Column(TypeName = "varchar(100)")]
        public string section { get; set; }

        [DisplayName("Gampanin")]
        [Column(TypeName = "varchar(100)")]
        public string task { get; set; }

        [DisplayName("Level")]
        [Column(TypeName = "varchar(100)")]
        public string level { get; set; }

        [DisplayName("Petsa Nanumpa")]
        [Column(TypeName = "datetime")]
        public DateTime entrydate { get; set; }

        [DisplayName("Petsa Huminto")]
        [Column(TypeName = "datetime")]
        public DateTime enddate { get; set; }

        [DisplayName("Is Active")]
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
