using App.CommonLayer.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationLayer.Interface
{
    public interface IRoleBusiness
    {
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task<RoleModel> GetRoleByIdAsync(int id);
        Task<RoleModel> CreateRoleAsync(RoleModel model);
        Task<RoleModel> UpdateRoleAsync(RoleModel model);
        Task<bool> DeleteRoleAsync(int id);
    }
}
