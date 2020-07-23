
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork
    {
        private ArmyTechTaskEntities Context;
        public GenaricReposoitories<Student> StudentRepo { get; set; }
        public GenaricReposoitories<Field> FieldRepo { get; set; }
        public GenaricReposoitories<Governorate> GovernorateRepo { get; set; }
        public GenaricReposoitories<Neighborhood> NeighborhoodRepo { get; set; }
        public UnitOfWork(
            ArmyTechTaskEntities context,
            GenaricReposoitories<Student> studentRepo,
            GenaricReposoitories<Field> fieldRepo,
            GenaricReposoitories<Governorate> governorateRepo,
            GenaricReposoitories<Neighborhood> neighborhoodRepo
            )
        {
            Context = context;
            StudentRepo = studentRepo;
            StudentRepo.Context =Context;
            FieldRepo = fieldRepo;
            FieldRepo.Context = Context;
            GovernorateRepo = governorateRepo;
            GovernorateRepo.Context = Context;
            NeighborhoodRepo = neighborhoodRepo;
            neighborhoodRepo.Context = Context;    
        }

        public int commit()
        {
            return Context.SaveChanges();
        }

    }
}
