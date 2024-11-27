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
    public class BrandBusiness:IBrandBusiness
    {
        private readonly IGenericRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public BrandBusiness(IGenericRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrandsAsync()
        {
            var Brands = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandModel>>(Brands);
        }

        public async Task<BrandModel> GetBrandByIdAsync(int id)
        {
            var Brand = await _brandRepository.GetByIdAsync(id);
            return _mapper.Map<BrandModel>(Brand);
        }

        public async Task<BrandModel> CreateBrandAsync(BrandModel BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            var savedBrand = await _brandRepository.AddAsync(Brand);
            return _mapper.Map<BrandModel>(savedBrand);
        }

        public async Task<BrandModel> UpdateBrandAsync(BrandModel BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            var res = await _brandRepository.UpdateAsync(Brand);
            return _mapper.Map<BrandModel>(res);
        }

        public async Task<bool> DeleteBrandAsync(int id)
        {
            await _brandRepository.DeleteAsync(id);
            return true;
        }
    }
}
