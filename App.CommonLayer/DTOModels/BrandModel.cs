using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
   public class BrandModel
    {
        public int BrandId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string LogoUrl { get; set; } = null!;

    }
}
