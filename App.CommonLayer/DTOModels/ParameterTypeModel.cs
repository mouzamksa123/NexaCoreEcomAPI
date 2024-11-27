using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
    public class ParameterTypeModel
    {
        public int ParameterTypeId { get; set; }

        public string ParameterTypeName { get; set; } = null!;

        public string? ParameterTypeNameN { get; set; }

        public bool? IsActive { get; set; }


    }
}
