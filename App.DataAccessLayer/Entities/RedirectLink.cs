using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities
{
    public partial class RedirectLink
    {
        public int Link { get; set; }

        public string? Linktype { get; set; }
    }
}
