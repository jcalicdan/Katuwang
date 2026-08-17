using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katuwang.Models
{
    public class SystemParameter
    {
        [DisplayName("ID")]
        [Key]
        public int entryid { get; set; }

        [DisplayName("Parameter Name")]
        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }

        [DisplayName("Parameter Code")]
        [Column(TypeName = "varchar(100)")]
        public string code { get; set; }

        [DisplayName("Parameter Description")]
        [Column(TypeName = "varchar(100)")]
        public string description { get; set; }

        [DisplayName("Parameter Value")]
        [Column(TypeName = "varchar(100)")]
        public string value { get; set; }

        [DisplayName("Parameter Group")]
        [Column(TypeName = "varchar(100)")]
        public string group { get; set; }

        [DisplayName("Parameter Level")]
        [Column(TypeName = "varchar(100)")]
        public string level { get; set; }

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
