using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            annualSalary = annualSalary ?? 0;
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            user.SetMonthlySalary(annualSalary.Value / 12);
            user.SetTags(tags);
        }
    }
}