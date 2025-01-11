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
        Task<IEnumerable<CategoryDTO>> GetAllCategorysAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO CategoryDto);
        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO CategoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
