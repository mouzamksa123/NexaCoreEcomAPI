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
        Task<IEnumerable<BrandModel>> GetAllBrandsAsync();
        Task<BrandModel> GetBrandByIdAsync(int id);
        Task<BrandModel> CreateBrandAsync(BrandModel BrandDto);
        Task<BrandModel> UpdateBrandAsync(BrandModel BrandDto);
        Task<bool> DeleteBrandAsync(int id);
    }
}
