using Member.Models.InputModels;
using Member.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Services
{
    public interface IMemberService
    {
        IQueryable<MemberVM> GetAll();
        MemberIM GetById(Guid memberId);
        Task<bool> Add(MemberIM dto);
        Task<bool> Edit(MemberIM dto);
        Task<bool> Delete(Guid memberId);
        Task<bool> DeleteMember(Guid memberId);
    }
}
