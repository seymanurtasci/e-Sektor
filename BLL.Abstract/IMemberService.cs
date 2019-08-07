using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType.Classes;
using eSektorEntities;

namespace BLL.Abstract
{
    public interface IMemberService
    {
        ServiceResult<Members> GetMember(Guid id);

        ServiceResult<Members> GetMemberByUsername(string userName);
    }
}
