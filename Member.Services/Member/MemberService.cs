using Member.Data;
using Member.Data.Management;
using Member.Models.InputModels;
using Member.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<Member.Models.DbModels.Member> repoMember;
        public MemberService(IRepository<Member.Models.DbModels.Member> repoMember)
        {
            this.repoMember = repoMember;
        }

        public IQueryable<MemberVM> GetAll()
        {
            return (from m in repoMember.GetAll()
                    where m.IsDeleted == false
                    select new MemberVM
                    {
                        Id = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Email = m.Email,
                        Phone = m.Phone
                    }).AsQueryable();
        }

        public MemberIM GetById(Guid memberId)
        {
            return (from m in repoMember.GetAll()
                    where m.Id == memberId
                    select new MemberIM
                    {
                        Id = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Email = m.Email,
                        Phone = m.Phone
                    }).FirstOrDefault();
        }

        public async Task<bool> Add(MemberIM dto)
        {
            bool result = false;
            var member = new Member.Models.DbModels.Member
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                IsDeleted = false
            };
            await repoMember.AddAsync(member);
            result = true;
            return result;
        }

        public async Task<bool> Edit(MemberIM dto)
        {
            bool result = false;
            if (dto.Id != Guid.Empty)
            {
                var member = await repoMember.FindAsync(m => m.Id == dto.Id);
                if (member != null)
                {
                    member.FirstName = dto.FirstName;
                    member.LastName = dto.LastName;
                    member.Email = dto.Email;
                    member.Phone = dto.Phone;
                    member.LastUpdateDate = DateTime.Now;
                    await repoMember.UpdateAsync(member);
                    result = true;

                }
            }
            return result;
        }

        public async Task<bool> Delete(Guid memberId)
        {
            bool result = false;
            if (memberId != Guid.Empty)
            {
                var member = await repoMember.FindAsync(m => m.Id == memberId);
                if (member != null)
                {
                    member.IsDeleted = true;
                    member.LastUpdateDate = DateTime.Now;
                    await repoMember.UpdateAsync(member);
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> DeleteMember(Guid memberId)
        {
            bool result = false;
            if (memberId != Guid.Empty)
            {
                var member = await repoMember.FindAsync(m => m.Id == memberId);
                if (member != null)
                {
                    await repoMember.DeleteAsync(member);
                    result = true;
                }
            }
            return result;
        }

    }
}
