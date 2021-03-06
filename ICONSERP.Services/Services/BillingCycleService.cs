using AutoMapper;
using ICONSERP.Data;
using ICONSERP.Data.Extensions;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Models;
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.ViewModels.Shared;

namespace ICONSERP.Services
{
    public class BillingCycleService : GenericService<BillingCycle, BillingCycleEditViewModel, BillingCycleViewModel>, IBillingCycleService
    {

        protected IMapper _mapper;
        protected IRepository<BillingCycle> _repository;
        public BillingCycleService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public PagingViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var list = _unitOfWork.BillingCycleRepository.GetAll().Where(x => name == "" || x.NameArabic == name || x.NameEnglish == name);
            int records = list.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            IEnumerable<BillingCycleViewModel> result = new List<BillingCycleViewModel>();
            var items = list.OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize);
            result = items.ToList().Select(x => _mapper.Map<BillingCycleViewModel>(x)).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }
        public override BillingCycleViewModel GetByID(Guid id)
        {
            var xx = _unitOfWork.BillingCycleRepository.GetAll();
            var item = _unitOfWork.BillingCycleRepository.GetAll().Where(i => i.ID == id)
               //  .Include(i => i.RoleModuleResourcePermissions)
               // .ThenInclude(i => i.ModuleResource)
               //  .Include(i => i.RoleModuleResourcePermissions)
               // .ThenInclude(i => i.Permission)
               .FirstOrDefault();
            if (item == null) return null;
            return _mapper.Map<BillingCycleViewModel>(item);
        }
        public bool IsExist(Guid id, string nameArabic, string nameEnglish, int DisplayOrder)
        {
            var query = _unitOfWork.BillingCycleRepository.GetAll();
            if (int.Parse(id.ToString()) > 0)
                query = query.Where(i => i.ID != id);
            return query.Any(x => x.NameArabic == nameArabic || x.NameEnglish == nameEnglish );
        }
        public override BillingCycleEditViewModel Add(BillingCycleEditViewModel model)
        {
            var obj = _mapper.Map<BillingCycle>(model);
            var attachedObj = _unitOfWork.BillingCycleRepository.Add(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;

            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i)));
            _unitOfWork.Commit();
            return _mapper.Map<BillingCycleEditViewModel>(attachedObj);
        }
        public override BillingCycleEditViewModel Edit(BillingCycleEditViewModel model)
        {
            var obj = _mapper.Map<BillingCycle>(model);
            var attachedObj = _unitOfWork.BillingCycleRepository.Edit(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;
            //var list = model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i));
            //Guid[] ids = list.Select(i => i.ID).ToArray();z
            //_unitOfWork.RoleModuleResourcePermissionRepository.RemoveRange(_unitOfWork.RoleModuleResourcePermissionRepository.Find(i => i.RoleID == obj.ID && !ids.Contains(i.ID)).Select(i => i.ID));
            //_unitOfWork.RoleModuleResourcePermissionRepository.EditRange(list.Where(i => int.Parse(i.ID.ToString()) != 0));
            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(list.Where(i => int.Parse(i.ID.ToString()) == 0));
            _unitOfWork.Commit();
            return _mapper.Map<BillingCycleEditViewModel>(attachedObj);
        }
    }
}