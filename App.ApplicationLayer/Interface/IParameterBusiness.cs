using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IParameterBusiness
    {
        Task<IEnumerable<ParameterModel>> GetAllParametersAsync();
        Task<ParameterModel> GetParameterByIdAsync(int id);
        Task<ParameterModel> CreateParameterAsync(ParameterModel ParameterDto);
        Task<ParameterModel> UpdateParameterAsync(ParameterModel ParameterDto);
        Task<bool> DeleteParameterAsync(int id);
    }
}
