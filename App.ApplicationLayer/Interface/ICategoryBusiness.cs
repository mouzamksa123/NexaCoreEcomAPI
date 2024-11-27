using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface ICategoryBusiness
    {
        Task<IEnumerable<CateogryModel>> GetAllCategorysAsync();
        Task<CateogryModel> GetCategoryByIdAsync(int id);
        Task<CateogryModel> CreateCategoryAsync(CateogryModel CategoryDto);
        Task<CateogryModel> UpdateCategoryAsync(CateogryModel CategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
