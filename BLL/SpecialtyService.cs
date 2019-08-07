using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Abstract;
using CommonType.Classes;
using eSektorEntities;
using CommonType.Enums;
using Core.DataAccess;

namespace BLL
{
    public class SpecialtyService : ISpecialtyService
    {
        IUnitOfWork _uow;
        public SpecialtyService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ServiceResult<List<Speciality>> GetSpecialties()
        {
            List<Speciality> specialities = _uow.GetRepository<Speciality>().GetList();

            return new ServiceResult<List<Speciality>>("Okuma Başarılı", ResultState.Success, specialities);
        }
    }
}
