using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CommonLayer.DTOModels
{
     
        public class AttachmentDTO
        {
            int Id { get; set; }
            string CollectionName { get; set; }
            string Name { get; set; }
            string FileName { get; set; }
            string MimeType { get; set; }
            string Disk { get; set; }
            string ConversionsDisk { get; set; }
            string Size { get; set; }
            string OriginalUrl { get; set; }
            string AssetUrl { get; set; }
            int CreatedById { get; set; }
            string CreatedAt { get; set; }
            string UpdatedAt { get; set; }
            string DeletedAt { get; set; } 
    }
}
