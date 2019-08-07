using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType.Classes;
using eSektorEntities;

namespace BLL.Abstract
{
    public interface ISpecialtyService
    {
        ServiceResult<List<Speciality>> GetSpecialties();
    }
}
