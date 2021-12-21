using ICONSERP.ViewModels.Identity;

namespace ICONSERP.Services
{
    public interface IBaseService<TEditViewModel, TViewModel>
    {        
        TEditViewModel Add(TEditViewModel model);
        TEditViewModel Edit(TEditViewModel model);
        TViewModel GetByID(Guid id);
        TEditViewModel GetEditableByID(Guid id);
        IEnumerable<TViewModel> GetList();
        void Remove(Guid id);
    }
}