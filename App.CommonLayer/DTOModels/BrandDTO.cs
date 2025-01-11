using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CategoryDTO
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Slug { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public int? ParentId { get; set; }
            public AttachmentDTO CategoryImage { get; set; }
            public int? CategoryImageId { get; set; }
            public AttachmentDTO CategoryIcon { get; set; }
            public int? CategoryIconId { get; set; }
            public double? CommissionRate { get; set; }
            public List<CategoryDTO> Subcategories { get; set; }
            public int CategoryMetaImageId { get; set; }
            public AttachmentDTO CategoryMetaImage { get; set; }
            public string MetaTitle { get; set; }
            public string MetaDescription { get; set; }
            public bool Status { get; set; }
            public int? CreatedById { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }
            public string DeletedAt { get; set; }
        
    }
    

    public class BrandDTO
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

}
