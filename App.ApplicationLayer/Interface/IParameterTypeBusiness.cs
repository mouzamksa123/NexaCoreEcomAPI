using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IParameterTypeBusiness
    {
        Task<IEnumerable<ParameterTypeModel>> GetAllParameterTypesAsync();
        Task<ParameterTypeModel> GetParameterTypeByIdAsync(int id);
        Task<ParameterTypeModel> CreateParameterTypeAsync(ParameterTypeModel ParameterTypeDto);
        Task<ParameterTypeModel> UpdateParameterTypeAsync(ParameterTypeModel ParameterTypeDto);
        Task<bool> DeleteParameterTypeAsync(int id);
    }
}
