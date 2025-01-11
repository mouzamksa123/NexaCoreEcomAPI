using System;
using System.Collections.Generic;

namespace TestDb;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public int? BrandImageId { get; set; }

    public int BrandBannerId { get; set; }

    public int BrandMetaImageId { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaDescription { get; set; }

    public bool Status { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Attachment BrandBanner { get; set; } = null!;

    public virtual Attachment? BrandImage { get; set; }

    public virtual Attachment BrandMetaImage { get; set; } = null!;
}
