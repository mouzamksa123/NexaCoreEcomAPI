using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Entities
{
    public class Parameter
    {
        public int ParameterId { get; set; }

        public string? ParameterName { get; set; }

        public string? ParameterNameN { get; set; }

        public int ParameterTypeId { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedOn { get; set; }

        public int? EditedBy { get; set; }

        public virtual ParameterType ParameterType { get; set; } = null!;
    }
}
