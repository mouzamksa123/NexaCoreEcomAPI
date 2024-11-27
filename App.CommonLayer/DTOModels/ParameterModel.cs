using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
    public class ParameterModel
    {
        public int ParameterId { get; set; }

        public string? ParameterName { get; set; }

        public string? ParameterNameN { get; set; }

        public int ParameterTypeId { get; set; }
    }
}
