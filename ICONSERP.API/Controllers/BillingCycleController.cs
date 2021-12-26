using AutoMapper;
using ICONSERP.Localization.Resources;
using ICONSERP.Services;
using ICONSERP.ViewModels.Lookups.BillingCycle;
using ICONSERP.ViewModels.Shared;
using Microsoft.AspNetCore.Mvc;


namespace ICONSERP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillingCycleController : BaseController
    {
        private ResultViewModel _resultViewModel;
        private readonly IBillingCycleService _service;
        protected IMapper _mapper;
        public BillingCycleController(IBillingCycleService service, IMapper mapper)
        {
            _service = service;
            _resultViewModel = new ResultViewModel();
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Get")]
        public ResultViewModel Get(string name = "", string orderBy = "ID", bool isAscending = false, int pageIndex = 1, int pageSize = 20)
        {
            try
            {
                _resultViewModel.Data = _service.Get(name, orderBy, isAscending, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;

        }

        [HttpGet]
        [Route("GetList")]
        public ResultViewModel GetList()
        {

            try
            {
                _resultViewModel.Data = _service.GetList();
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }


        [HttpGet]
        [Route("GetByID/{id}")]
        public ResultViewModel GetByID(Guid id)
        {
            try
            {
                _resultViewModel.Data = _service.GetByID(id);
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpGet]
        [Route("GetEditableByID/{id}")]
        public ResultViewModel GetEditableByID(Guid id)
        {

            try
            {
                _resultViewModel.Data = _service.GetEditableByID(id);
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpPost]
        [Route("Post")]
        public ResultViewModel Post([FromBody] BillingCycleEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, SharedResource.SuccessfullyCreated, _service.Add(viewModel));
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpPut]
        [Route("Put")]
        public ResultViewModel Put([FromBody] BillingCycleEditViewModel viewModel)
        {
            try
            {
                _resultViewModel = _resultViewModel.Create(true, SharedResource.SuccessfullyUpdated, _service.Edit(viewModel));
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResultViewModel Delete(Guid id)
        {

            try
            {
                _service.Remove(id);
                _resultViewModel.Message = SharedResource.SuccessfullyDeleted;
            }
            catch (Exception ex)
            {
                _resultViewModel = _resultViewModel.Create(false, ex.Message);
            }
            return _resultViewModel;
        }
    }
}
