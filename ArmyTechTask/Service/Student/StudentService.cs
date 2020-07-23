using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class StudentService
    {
        public UnitOfWork UnitOfWork { get; set; }
        private GenaricReposoitories<Student> StudentRepo;
        public StudentService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            StudentRepo = UnitOfWork.StudentRepo;
        }

        public StudentEditViewModel GetByID(int ID)
        {
            return StudentRepo.GetByID(ID).ToEditViewModel();
        }
        public IEnumerable<StudentViewModel> GetAll()
        {
            return StudentRepo?.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        public StudentEditViewModel GetFilter(int id)
        {
            return StudentRepo?.Get(i => i.ID == id).Select(i => i.ToEditViewModel()).FirstOrDefault();
        }
        public StudentEditViewModel Add(StudentEditViewModel e)
        {
            StudentRepo.Add(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public StudentEditViewModel Update(StudentEditViewModel e)
        {
            StudentRepo.Update(e.ToModel());
            UnitOfWork.commit();
            return e;
        }
        public void Remove(StudentEditViewModel e)
        {
            StudentRepo.Remove(e.ToModel());
            UnitOfWork.commit();

        }
    }
}




