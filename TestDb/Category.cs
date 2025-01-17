using System;
using System.Collections.Generic;

namespace TestDb;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Description { get; set; }

    public string? Type { get; set; }

    public int? ParentId { get; set; }

    public int? CategoryImageId { get; set; }

    public int? CategoryIconId { get; set; }

    public decimal? CommissionRate { get; set; }

    public int? CategoryMetaImageId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public bool Status { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Attachment? CategoryIcon { get; set; }

    public virtual Attachment? CategoryImage { get; set; }

    public virtual Attachment CategoryMetaImage { get; set; } = null!;
}
