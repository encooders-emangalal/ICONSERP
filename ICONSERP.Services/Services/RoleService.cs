using AutoMapper;
using ICONSERP.Data;
using ICONSERP.Data.Extensions;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Models.Identity;
using ICONSERP.Services;
using ICONSERP.ViewModels.Identity;
using ICONSERP.ViewModels.Shared;
using Microsoft.EntityFrameworkCore;

namespace ICONSERP.Services
{
    public class RoleService : GenericService<Role, RoleEditViewModel, RoleViewModel>, IRoleService
    {
      
        protected IMapper _mapper;       
        public RoleService(UnitOfWork unitOfWork): base(unitOfWork)
        {
            _unitOfWork = new UnitOfWork();
        }        
        public PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var list = _unitOfWork.RoleRepository.GetAll().Where(x => name == "" || x.NameArabic == name || x.NameEnglish == name);
            int records = list.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            IEnumerable<RoleViewModel> result = new List<RoleViewModel>();
            var items = list.OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize);
            result = items.ToList().Select(x => _mapper.Map<RoleViewModel>(x)).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }
        public override RoleViewModel GetByID(Guid id)
        {           
            var xx =  _unitOfWork.RoleRepository.GetAll();
            var item = _unitOfWork.RoleRepository.GetAll().Where(i => i.ID == id)
               .Include(i => i.RoleModuleResourcePermissions)
               .ThenInclude(i => i.ModuleResource)
               .Include(i => i.RoleModuleResourcePermissions)
               .ThenInclude(i => i.Permission)
               .FirstOrDefault();
            if (item == null) return null;
            return _mapper.Map<RoleViewModel>(item);
        }
        public bool IsExist(Guid id, string nameArabic, string nameEnglish)
        {
            var query = _unitOfWork.RoleRepository.GetAll();
            if (int.Parse(id.ToString()) > 0)
                query = query.Where(i => i.ID != id);
            return query.Any(x => x.NameArabic == nameArabic || x.NameEnglish == nameEnglish);
        }
        public override RoleEditViewModel Add(RoleEditViewModel model)
        {
            var obj = _mapper.Map<Role>(model);
            var attachedObj = _unitOfWork.RoleRepository.Add(obj);
            foreach (var item in model.RoleModuleResourcePermissions)
                item.RoleID = obj.ID;

            _unitOfWork.RoleModuleResourcePermissionRepository.AddRange(model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i)));
            _unitOfWork.Commit();
            return _mapper.Map<RoleEditViewModel>(attachedObj);
        }
        public override RoleEditViewModel Edit(RoleEditViewModel model)
        {
            var obj = _mapper.Map<Role>(model);
            var attachedObj = _unitOfWork.RoleRepository.Edit(obj);
            foreach (var item in model.RoleModuleResourcePermissions)
                item.RoleID = obj.ID;
            var list = model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i));
            Guid[] ids = list.Select(i => i.ID).ToArray();
            _unitOfWork.RoleModuleResourcePermissionRepository.RemoveRange(_unitOfWork.RoleModuleResourcePermissionRepository.Find(i => i.RoleID == obj.ID && !ids.Contains(i.ID)).Select(i => i.ID));
            _unitOfWork.RoleModuleResourcePermissionRepository.EditRange(list.Where(i => int.Parse(i.ID.ToString()) != 0));
            _unitOfWork.RoleModuleResourcePermissionRepository.AddRange(list.Where(i => int.Parse(i.ID.ToString()) == 0));
            _unitOfWork.Commit();
            return _mapper.Map<RoleEditViewModel>(attachedObj);
        }
    }
}