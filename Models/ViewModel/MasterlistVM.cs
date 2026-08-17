using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Katuwang.Models.ViewModel
{
    public class MasterlistVM
    {
        public Masterlist Masterlist { get; set; }
        public IEnumerable<Masterlist> iMasterlist { get; set; }

        public Transfer Transfer { get; set; }
        public IEnumerable<Transfer> iTransfer { get; set; }

        public R401 R401 { get; set; }
        public IEnumerable<R401> iR401 { get; set; }

        public Maytungkulin Maytungkulin { get; set; }
        public IEnumerable<Maytungkulin> iMaytungkulin { get; set; }

        public Destinado Destinado { get; set; }
        public IEnumerable<Destinado> iDestinado { get; set; }

    }
}
