using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class Transfer
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }

        [DisplayName("Masterlist ID")]
        public int masterlistid { get; set; }

        [ForeignKey("masterlistid")]
        public virtual Masterlist Masterlist { get; set; }

        [DisplayName("Taon")]
        [Column(TypeName = "int")]
        public int year { get; set; }

        [DisplayName("Week Num.")]
        [Column(TypeName = "int")]
        public int weeknum { get; set; }

        [DisplayName("Transfer Date")]
        [Column(TypeName = "datetime")]
        public DateTime transferdate { get; set; }

        [DisplayName("Transfer Code")]
        [Column(TypeName = "varchar(1)")]
        public string code { get; set; }

        [DisplayName("Lokal")]
        [Column(TypeName = "varchar(100)")]
        public string lokal { get; set; }

        [DisplayName("LCode")]
        [Column(TypeName = "varchar(20)")]
        public string lcode { get; set; }

        [DisplayName("Distrito")]
        [Column(TypeName = "varchar(100)")]
        public string distrito { get; set; }

        [DisplayName("DCode")]
        [Column(TypeName = "varchar(20)")]
        public string dcode { get; set; }

        [DisplayName("Address sa Lilipatan")]
        [Column(TypeName = "varchar(100)")]
        public string address { get; set; }

        [DisplayName("Thru R6-01")]
        [Column(TypeName = "int")]
        public int isletter { get; set; }

        [DisplayName("Kalihim sa Transfer")]
        [Column(TypeName = "int")]
        public int secretariatid { get; set; }

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
