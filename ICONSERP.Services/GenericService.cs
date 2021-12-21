using AutoMapper;
using ICONSERP.Data;
using ICONSERP.Data.Repository;
using ICONSERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICONSERP.Services
{
    public  class GenericService<TModel, TEditViewModel, TViewModel> : IBaseService<TEditViewModel, TViewModel> where TModel : BaseModel
    {
        protected UnitOfWork _unitOfWork;
        protected IRepository<TModel> _repository;
        protected IMapper _mapper;
        public GenericService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<Repository<TModel>>();
          
        }
        public virtual TEditViewModel Add(TEditViewModel model)
        {
            var  obj = _mapper.Map<TModel>(model);
            var attachedObj = _repository.Add(obj);
            _unitOfWork.Commit();
            return _mapper.Map<TEditViewModel>(attachedObj);
        }
        public virtual TEditViewModel Edit(TEditViewModel model)
        {
            var obj = _mapper.Map<TModel>(model);
            var attachedObj = _repository.Edit(obj);
            _unitOfWork.Commit();
            return _mapper.Map<TEditViewModel>(attachedObj);
        }
        public virtual TViewModel GetByID(Guid id)
        {
            var model = _repository.First(x => x.ID == id);
            return _mapper.Map<TViewModel>(model);
        }
        public virtual TEditViewModel GetEditableByID(Guid id)
        {
            var city = _repository.First(x => x.ID == id);
            return _mapper.Map<TEditViewModel>(city);
        }
        public virtual IEnumerable<TViewModel> GetList()
        {
            return _repository.GetAll().ToList().Select(x => _mapper.Map<TViewModel>(x)).ToList();
        }
        public virtual void Remove(Guid id)
        {
            _repository.Remove(id);
            _unitOfWork.Commit();
        }
    }
}
