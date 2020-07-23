using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
   public  class FieldService
    {

        public UnitOfWork UnitOfWork { get; set; }
        private GenaricReposoitories<Field> FieldRepo;
        public FieldService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            FieldRepo = UnitOfWork.FieldRepo;
        }

        public FieldEditViewModel GetByID(int ID)
        {
            return FieldRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<FieldViewModel> GetAll()
        {
            return FieldRepo?.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        //public IEnumerable<FieldViewModel> GetFilter(int id)
        //{
        //    return FieldRepo?.Get(i => i.DepartmentID == id).Select(i => i.ToViewModel()).ToList();
        //}
        public FieldEditViewModel Add(FieldEditViewModel e)
        {
            FieldRepo.Add(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public FieldEditViewModel Update(FieldEditViewModel e)
        {
            FieldRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(FieldEditViewModel e)
        {
            FieldRepo.Remove(e.ToModel());
            UnitOfWork.commit();

        }
    }
}
