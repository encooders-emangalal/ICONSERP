using AutoMapper;
using ICONSERP.Data;
using ICONSERP.Data.Extensions;
using ICONSERP.Data.Repository;
using ICONSERP.Models.Models;
using ICONSERP.ViewModels.Lookups;
using ICONSERP.ViewModels.Shared;

namespace ICONSERP.Services.Services
{
    public class CountryService : GenericService<Country, CountryEditViewModel, CountryViewModel>, ICountryService
    {

        protected IMapper _mapper;
        protected IRepository<Country> _repository;
        public CountryService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public PagingViewModel Get(string name = "", string Code = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            var list = _unitOfWork.CountryRepository.GetAll().Where(x => name == "" || x.NameArabic == name || x.NameEnglish == name || x.Code == Code);
            int records = list.Count();
            if (records <= pageSize || pageIndex <= 0) pageIndex = 1;
            int pages = (int)Math.Ceiling((double)records / pageSize);
            int excludedRows = (pageIndex - 1) * pageSize;
            IEnumerable<CountryViewModel> result = new List<CountryViewModel>();
            var items = list.OrderByPropertyName(orderBy, isAscending).Skip(excludedRows).Take(pageSize);
            result = items.ToList().Select(x => _mapper.Map<CountryViewModel>(x)).ToList();
            return new PagingViewModel() { PageIndex = pageIndex, PageSize = pageSize, Result = result, Records = records, Pages = pages };
        }
        public override CountryViewModel GetByID(Guid ID)
        {
            var xx = _unitOfWork.BillingCycleRepository.GetAll();
            var item = _unitOfWork.BillingCycleRepository.GetAll().Where(i => i.ID == ID)
               //  .Include(i => i.RoleModuleResourcePermissions)
               // .ThenInclude(i => i.ModuleResource)
               //  .Include(i => i.RoleModuleResourcePermissions)
               // .ThenInclude(i => i.Permission)
               .FirstOrDefault();
            if (item == null) return null;
            return _mapper.Map<CountryViewModel>(item);
        }
        public bool IsExist(Guid ID, string Code, string nameArabic, string nameEnglish)
        {
            var query = _unitOfWork.CountryRepository.GetAll();
            if (int.Parse(ID.ToString()) > 0)
                query = query.Where(i => i.ID != ID);
            return query.Any(x => x.NameArabic == nameArabic || x.NameEnglish == nameEnglish || x.Code == Code);
        }
        public override CountryEditViewModel Add(CountryEditViewModel model)
        {
            var obj = _mapper.Map<Country>(model);
            var attachedObj = _unitOfWork.CountryRepository.Add(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;

            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i)));
            _unitOfWork.Commit();
            return _mapper.Map<CountryEditViewModel>(attachedObj);
        }
        public override CountryEditViewModel Edit(CountryEditViewModel model)
        {
            var obj = _mapper.Map<Country>(model);
            var attachedObj = _unitOfWork.CountryRepository.Edit(obj);
            //foreach (var item in model.RoleModuleResourcePermissions)
            //    item.RoleID = obj.ID;
            //var list = model.RoleModuleResourcePermissions.Select(i => _mapper.Map<RoleModuleResourcePermission>(i));
            //Guid[] ids = list.Select(i => i.ID).ToArray();z
            //_unitOfWork.RoleModuleResourcePermissionRepository.RemoveRange(_unitOfWork.RoleModuleResourcePermissionRepository.Find(i => i.RoleID == obj.ID && !ids.Contains(i.ID)).Select(i => i.ID));
            //_unitOfWork.RoleModuleResourcePermissionRepository.EditRange(list.Where(i => int.Parse(i.ID.ToString()) != 0));
            //_unitOfWork.RoleModuleResourcePermissionRepository.AddRange(list.Where(i => int.Parse(i.ID.ToString()) == 0));
            _unitOfWork.Commit();
            return _mapper.Map<CountryEditViewModel>(attachedObj);
        }
    }
}
