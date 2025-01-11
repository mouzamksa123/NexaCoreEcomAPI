using System;
using System.Collections.Generic;

namespace TestDb;

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
