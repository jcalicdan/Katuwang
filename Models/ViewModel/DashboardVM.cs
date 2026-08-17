using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Katuwang.Models.StoredProcedure;

namespace Katuwang.Models.ViewModel
{
    public class DashboardVM
    {
        public Masterlist Masterlist { get; set; }
        public IEnumerable<Masterlist> iMasterlist { get; set; }

        public AddressDirectory AddressDirectory { get; set; }
        public IEnumerable<AddressDirectory> iAddressDirectory { get; set; }
    }
}
