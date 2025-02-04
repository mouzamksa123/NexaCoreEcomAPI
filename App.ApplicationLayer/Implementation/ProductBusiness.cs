﻿using App.ApplicationLayer.Interface;
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
    public class ProductBusiness:IProductBusiness
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductBusiness(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel productDto)
        {
            var product = _mapper.Map<Product>(productDto);
           var savedProduct= await _productRepository.AddAsync(product);
            return _mapper.Map<ProductModel>(savedProduct);
        }

        public async Task<ProductModel> UpdateProductAsync(ProductModel productDto)
        {
            var product = _mapper.Map<Product>(productDto);
           var res= await _productRepository.UpdateAsync(product);
            return _mapper.Map<ProductModel>(res);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}
