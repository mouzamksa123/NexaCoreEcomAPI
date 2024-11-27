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
    public class ParameterBusiness:IParameterBusiness
    {
        private readonly IGenericRepository<Parameter> _ParameterRepository;
        private readonly IMapper _mapper;

        public ParameterBusiness(IGenericRepository<Parameter> ParameterRepository, IMapper mapper)
        {
            _ParameterRepository = ParameterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParameterModel>> GetAllParametersAsync()
        {
            var Parameters = await _ParameterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ParameterModel>>(Parameters);
        }

        public async Task<ParameterModel> GetParameterByIdAsync(int id)
        {
            var Parameter = await _ParameterRepository.GetByIdAsync(id);
            return _mapper.Map<ParameterModel>(Parameter);
        }

        public async Task<ParameterModel> CreateParameterAsync(ParameterModel ParameterDto)
        {
            var Parameter = _mapper.Map<Parameter>(ParameterDto);
            Parameter.CreatedOn = DateTime.Now;
            var savedParameter = await _ParameterRepository.AddAsync(Parameter);
            return _mapper.Map<ParameterModel>(savedParameter);
        }

        public async Task<ParameterModel> UpdateParameterAsync(ParameterModel ParameterDto)
        {
            var Parameter = _mapper.Map<Parameter>(ParameterDto);
            var res = await _ParameterRepository.UpdateAsync(Parameter);
            return _mapper.Map<ParameterModel>(res);
        }

        public async Task<bool> DeleteParameterAsync(int id)
        {
            await _ParameterRepository.DeleteAsync(id);
            return true;
        }

    }
}
