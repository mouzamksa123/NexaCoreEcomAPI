using System;
using System.Collections.Generic;

namespace TestDb;

public partial class Attachment
{
    public int Id { get; set; }

    public string? CollectionName { get; set; }

    public string? Name { get; set; }

    public string? FileName { get; set; }

    public string? MimeType { get; set; }

    public string? Disk { get; set; }

    public string? ConversionsDisk { get; set; }

    public string? Size { get; set; }

    public string? OriginalUrl { get; set; }

    public string? AssetUrl { get; set; }

    public int CreatedById { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Brand> BrandBrandBanners { get; set; } = new List<Brand>();

    public virtual ICollection<Brand> BrandBrandImages { get; set; } = new List<Brand>();

    public virtual ICollection<Brand> BrandBrandMetaImages { get; set; } = new List<Brand>();

    public virtual ICollection<Category> CategoryCategoryIcons { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryCategoryImages { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryCategoryMetaImages { get; set; } = new List<Category>();
}
