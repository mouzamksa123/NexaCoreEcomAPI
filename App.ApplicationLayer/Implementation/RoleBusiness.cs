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
    public class RoleBusiness: IRoleBusiness
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IMapper _mapper;

        public RoleBusiness(IGenericRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            var Roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleModel>>(Roles);
        }

        public async Task<RoleModel> GetRoleByIdAsync(int id)
        {
            var Role = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleModel>(Role);
        }

        public async Task<RoleModel> CreateRoleAsync(RoleModel RoleDto)
        {
            var Role = _mapper.Map<Role>(RoleDto);
            var savedRole = await _roleRepository.AddAsync(Role);
            return _mapper.Map<RoleModel>(savedRole);
        }

        public async Task<RoleModel> UpdateRoleAsync(RoleModel RoleDto)
        {
            var Role = _mapper.Map<Role>(RoleDto);
            var res = await _roleRepository.UpdateAsync(Role);
            return _mapper.Map<RoleModel>(res);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteAsync(id);
            return true;
        }
    }
}
