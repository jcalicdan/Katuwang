using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Katuwang.Models.StoredProcedure
{
    public partial class Dashboard
    {
        [Key]
        public long entryid { get; set; } 
        public string name { get; set; }
        public string value { get; set; }
    }
}
