using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Neighborhood
{
    public class NeighborhoodService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenaricReposoitories<Repositories.Neighborhood> NeighborhoodRepo;
        public NeighborhoodService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            NeighborhoodRepo = UnitOfWork.NeighborhoodRepo;
        }

        public NeighborhoodEditViewModel GetByID(int ID)
        {
            return NeighborhoodRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<NeighborhoodViewModel> GetAll()
        {
            return NeighborhoodRepo?.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        public IEnumerable<NeighborhoodViewModel> GetFilter(int id)
        {
            return NeighborhoodRepo?.Get(i => i.GovernorateId == id).Select(i => i.ToViewModel()).ToList();
        }
        
        public NeighborhoodEditViewModel Add(NeighborhoodEditViewModel e)
        {
            NeighborhoodRepo.Add(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public NeighborhoodEditViewModel Update(NeighborhoodEditViewModel e)
        {
            NeighborhoodRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(NeighborhoodEditViewModel e)
        {
            NeighborhoodRepo.Remove(e.ToModel());
            UnitOfWork.commit();

        }
    }
}

