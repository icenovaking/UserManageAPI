using Microsoft.AspNetCore.Mvc;
using UserManageAPI.Models;

namespace UserManageAPI.Service
{
    public interface IUserManageService
    {
        IEnumerable<CalculateResponse> Calculate();
        IEnumerable<GetUserResponse> GetUser(string? SearchName, double FromAge, double ToAge, int Sex);

        bool AddUser(AddUserRequest body);
    }
}
