using AutoMapper;
using ICONSERP.Data;
using ICONSERP.Data.Extensions;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Models;
using ICONSERP.Services.Interfaces;
using ICONSERP.ViewModels.Identity;
using ICONSERP.ViewModels.Lookups.ApplicationModule;
using ICONSERP.ViewModels.Shared;
using Microsoft.EntityFrameworkCore;

namespace ICONSERP.Services.Services
{
    public class ApplicationModuleService : GenericService<ApplicationModule, ApplicationModuleEditViewModel, ApplicationModuleViewModel>, IApplicationModuleService
    {
        protected IMapper _mapper;
        protected IRepository<ApplicationModule> _repository;

        public ApplicationModuleService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var list = _unitOfWork.ApplicationModuleRepository.GetAll().Where(x => name == "" || x.NameArabic == name || x.NameEnglish == name);
            int records = list.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            IEnumerable<ApplicationModuleViewModel> result = new List<ApplicationModuleViewModel>();
            var items = list.OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize);
            result = items.ToList().Select(x => _mapper.Map<ApplicationModuleViewModel>(x)).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }

        public override ApplicationModuleViewModel GetByID(Guid id)
        {
            var xx = _unitOfWork.ApplicationModuleRepository.GetAll();
            var item = _unitOfWork.ApplicationModuleRepository.GetAll().Where(i => i.ID == id).FirstOrDefault();
            if (item == null) return null;
            return _mapper.Map<ApplicationModuleViewModel>(item);
        }
        public bool IsExist(Guid id, string nameArabic, string nameEnglish ,string Code)
        {
            var query = _unitOfWork.ApplicationModuleRepository.GetAll();
            if (int.Parse(id.ToString()) > 0)
                query = query.Where(i => i.ID != id);
            return query.Any(x => x.NameArabic == nameArabic || x.NameEnglish == nameEnglish);
        }

        public override ApplicationModuleEditViewModel Add(ApplicationModuleEditViewModel model)
        {
            var obj = _mapper.Map<ApplicationModule>(model);
            var attachedObj = _unitOfWork.ApplicationModuleRepository.Add(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;

            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i)));
            _unitOfWork.Commit();
            return _mapper.Map<ApplicationModuleEditViewModel>(attachedObj);
        }

        public override ApplicationModuleEditViewModel Edit(ApplicationModuleEditViewModel model)
        {
            var obj = _mapper.Map<ApplicationModule>(model);
            var attachedObj = _unitOfWork.ApplicationModuleRepository.Edit(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;
            //var list = model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i));
            //Guid[] ids = list.Select(i => i.ID).ToArray();
            //_unitOfWork.RoleModuleResourcePermissionRepository.RemoveRange(_unitOfWork.RoleModuleResourcePermissionRepository.Find(i => i.RoleID == obj.ID && !ids.Contains(i.ID)).Select(i => i.ID));
            //_unitOfWork.RoleModuleResourcePermissionRepository.EditRange(list.Where(i => int.Parse(i.ID.ToString()) != 0));
            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(list.Where(i => int.Parse(i.ID.ToString()) == 0));
            _unitOfWork.Commit();
            return _mapper.Map<ApplicationModuleEditViewModel>(attachedObj);
        }
    }
}