using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities
{
   public partial class ParameterType
    {
        public int ParameterTypeId { get; set; }

        public string ParameterTypeName { get; set; } = null!;

        public string? ParameterTypeNameN { get; set; }

        public bool? IsAcitve { get; set; }

        public DateTime? CreateOn { get; set; }

        public int? CreatedBy { get; set; }

        public virtual ICollection<Parameter> Parameters { get; set; } = new List<Parameter>();
    }
}
