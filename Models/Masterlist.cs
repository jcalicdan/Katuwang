using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Katuwang.Data;
using System.Linq;

namespace Katuwang.Models
{
    public class Masterlist
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

        [DisplayName("Pangalan sa Asawa")]
        [Column(TypeName = "varchar(100)")]
        public string spousename { get; set; }

        [DisplayName("Suffix")]
        [Column(TypeName = "varchar(10)")]
        public string suffix { get; set; }

        [DisplayName("Tauhin")]
        [Column(TypeName = "varchar(1)")]
        public string gender { get; set; }

        [DisplayName("Kapanganakan")]
        [Column(TypeName = "datetime")]
        public DateTime birthdate { get; set; }

        [DisplayName("Kalgayang Sibil")]
        [Column(TypeName = "varchar(1)")]
        public string civilstatus { get; set; }

        [DisplayName("Pangalan ng Asawa")]
        [Column(TypeName = "varchar(100)")]
        public string spouse { get; set; }

        [DisplayName("Kasal")]
        [Column(TypeName = "datetime")]
        public DateTime weddingdate { get; set; }

        [DisplayName("Contact Number")]
        [Column(TypeName = "varchar(20)")]
        public string contactnum { get; set; }

        [DisplayName("Kumpletong Address")]
        [Column(TypeName = "varchar(200)")]
        public string address { get; set; }

        [DisplayName("Baranggay")]
        [Column(TypeName = "varchar(50)")]
        public string barangay { get; set; }

        [DisplayName("Purok")]
        [Column(TypeName = "int")]
        public int purok { get; set; }

        [DisplayName("Grupo")]
        [Column(TypeName = "int")]
        public int grupo { get; set; }

        [DisplayName("N-P")]
        [Column(TypeName = "int")]
        public int newpurok { get; set; }

        [DisplayName("N-G")]
        [Column(TypeName = "int")]
        public int newgrupo { get; set; }

        [DisplayName("Kapisanan")]
        [Column(TypeName = "varchar(6)")]
        public string organization { get; set; }

        [DisplayName("Bautismo")]
        [Column(TypeName = "date")]
        public DateTime baptismdate { get; set; }

        [DisplayName("Unang Lokal")]
        [Column(TypeName = "varchar(100)")]
        public string firstlokal { get; set; }

        [DisplayName("Unang Distrito")]
        [Column(TypeName = "varchar(100)")]
        public string firstdistrito { get; set; }

        [DisplayName("Nagdoktrina")]
        [Column(TypeName = "varchar(100)")]
        public string minister { get; set; }

        [DisplayName("Entry Number")]
        [Column(TypeName = "varchar(20)")]
        public string entrynum { get; set; }

        [DisplayName("ID Number")]
        [StringLength(50, ErrorMessage = "ID Number Must only be 13 characters")]
        [Column(TypeName = "varchar(20)")]
        public string idnum { get; set; }

        [DisplayName("Registry Number")]
        [StringLength(13, ErrorMessage = "Registry Number Must only be 13 characters")]
        [Column(TypeName = "varchar(20)")]
        public string registrynum { get; set; }

        [DisplayName("Sambahayan")]
        [Column(TypeName = "int")]
        public int sambahayan { get; set; }

        [DisplayName("Relasyon sa Pangulo")]
        [Column(TypeName = "varchar(20)")]
        public string relasyon { get; set; }

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

        [DisplayName("Is Updated")]
        [Column(TypeName = "int")]
        public int isupdated { get; set; }

    }
}
