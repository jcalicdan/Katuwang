using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class R401
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }
        
        [DisplayName("Masterlist ID")]
        public int masterlistid { get; set; }

        [ForeignKey("masterlistid")]
        public virtual Masterlist Masterlist { get; set; }

        [DisplayName("Kalagayan")]
        [Column(TypeName = "varchar(100)")]
        public string status { get; set; }

        [DisplayName("Taon")]
        [Column(TypeName = "int")]
        public int year { get; set; }

        [DisplayName("Buwan")]
        [Column(TypeName = "varchar(20)")]
        public string month { get; set; }

        [DisplayName("Destinado")]
        [Column(TypeName = "int")]
        public int destinadoid { get; set; }

        [DisplayName("Code")]
        [Column(TypeName = "varchar(5)")]
        public string code { get; set; }

        [DisplayName("May Kaso")]
        [Column(TypeName = "int")]
        public int ismk { get; set; }

        [DisplayName("Petsa Nadagdag")]
        [Column(TypeName = "datetime")]
        public DateTime entrydate { get; set; }

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
