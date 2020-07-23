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
    public class GovernorateService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenaricReposoitories<Governorate> GovernorateRepo;
        public GovernorateService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            GovernorateRepo = UnitOfWork.GovernorateRepo;
        }

        public GovernorateEditViewModel GetByID(int ID)
        {
            return GovernorateRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<GovernorateViewModel> GetAll()
        {
            return GovernorateRepo?.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        
        public GovernorateEditViewModel Add(GovernorateEditViewModel e)
        {
            GovernorateRepo.Add(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public GovernorateEditViewModel Update(GovernorateEditViewModel e)
        {
            GovernorateRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(GovernorateEditViewModel e)
        {
            GovernorateRepo.Remove(e.ToModel());
            UnitOfWork.commit();

        }
    }
}

