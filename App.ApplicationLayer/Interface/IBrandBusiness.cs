using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IBrandBusiness
    {
        Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
        Task<BrandDTO> GetBrandByIdAsync(int id);
        Task<BrandDTO> CreateBrandAsync(BrandDTO BrandDto);
        Task<BrandDTO> UpdateBrandAsync(BrandDTO BrandDto);
        Task<bool> DeleteBrandAsync(int id);
    }
}
