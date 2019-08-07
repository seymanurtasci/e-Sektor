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
    public class MemberService : IMemberService
    {
        IUnitOfWork _uow;
        public MemberService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public ServiceResult<Members> GetMember(Guid id)
        {

            var member = _uow.GetRepository<Members>().Get(m=>m.MemberId==id);

            return new ServiceResult<Members>("Okuma Başarılı", ResultState.Success, member);
        }

        public ServiceResult<Members> GetMemberByUsername(string userName)
        {
            var member = _uow.GetRepository<Members>().Get(m => m.CompanyName == userName);

            return new ServiceResult<Members>("Okuma Başarılı", ResultState.Success, member);
        }
    }
}
