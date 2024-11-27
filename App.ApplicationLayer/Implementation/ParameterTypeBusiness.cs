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
    public class ParameterTypeBusiness : IParameterTypeBusiness
    {
        private readonly IGenericRepository<ParameterType> _ParameterTypeRepository;
        private readonly IMapper _mapper;

        public ParameterTypeBusiness(IGenericRepository<ParameterType> ParameterTypeRepository, IMapper mapper)
        {
            _ParameterTypeRepository = ParameterTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParameterTypeModel>> GetAllParameterTypesAsync()
        {
            var ParameterTypes = await _ParameterTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ParameterTypeModel>>(ParameterTypes);
        }

        public async Task<ParameterTypeModel> GetParameterTypeByIdAsync(int id)
        {
            var ParameterType = await _ParameterTypeRepository.GetByIdAsync(id);
            return _mapper.Map<ParameterTypeModel>(ParameterType);
        }

        public async Task<ParameterTypeModel> CreateParameterTypeAsync(ParameterTypeModel ParameterTypeDto)
        {
            var ParameterType = _mapper.Map<ParameterType>(ParameterTypeDto);
            ParameterType.CreateOn = DateTime.Now;            
            var savedParameterType = await _ParameterTypeRepository.AddAsync(ParameterType);
            return _mapper.Map<ParameterTypeModel>(savedParameterType);
        }

        public async Task<ParameterTypeModel> UpdateParameterTypeAsync(ParameterTypeModel ParameterTypeDto)
        {
            var ParameterType = _mapper.Map<ParameterType>(ParameterTypeDto);
            var res = await _ParameterTypeRepository.UpdateAsync(ParameterType);
            return _mapper.Map<ParameterTypeModel>(res);
        }

        public async Task<bool> DeleteParameterTypeAsync(int id)
        {
            await _ParameterTypeRepository.DeleteAsync(id);
            return true;
        }

    }
}
