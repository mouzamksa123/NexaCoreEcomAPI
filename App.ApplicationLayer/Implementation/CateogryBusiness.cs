using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using App.DataAccessLayer.Entities;
using App.ServiceLayer.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Implementation
{
    public class CateogryBusiness:ICategoryBusiness
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CateogryBusiness(IGenericRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategorysAsync()
        {
            var Categorys = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(Categorys);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var Category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(Category);
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            var savedCategory = await _categoryRepository.AddAsync(Category);
            return _mapper.Map<CategoryDTO>(savedCategory);
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO CategoryDto)
        {
            var Category = _mapper.Map<Category>(CategoryDto);
            var res = await _categoryRepository.UpdateAsync(Category);
            return _mapper.Map<CategoryDTO>(res);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return true;
        }
    }
}
