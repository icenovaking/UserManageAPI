using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using UserManageAPI.Models;
using UserManageAPI.Repository;

namespace UserManageAPI.Service
{
    public class UserManageService: IUserManageService
    {
        private IUserInfoRepository _userInfoRepository;
        private ICityInfoRepository _cityInfoRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogService"/> class.
        /// </summary>
        public UserManageService(IUserInfoRepository userInfoRepository, ICityInfoRepository cityInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
            _cityInfoRepository = cityInfoRepository;
        }

        public IEnumerable<CalculateResponse> Calculate()
        {
            var list = new List<CalculateResponse>();

            var test = _userInfoRepository.GetAll().GroupBy(x => new { x.Location, x.Sex }).Select(x => new CalculateResponse
            {
                Location = x.Key.Location,
                Sex = x.Key.Sex==1?"男":"女",
                Total = x.Count()
            }).ToList();

            list = test;

            return list;
        }

        public IEnumerable<GetUserResponse> GetUser(string? SearchName, double FromAge, double ToAge , int Sex )
        {
            var list = new List<GetUserResponse>();

            var test = _userInfoRepository.GetAll().Join(_cityInfoRepository.GetAll(),
            u => u.Location,
            c => c.CityName,
            (u, c) => new GetUserResponse
            {
                Name = u.Name,
                Age = (double)u.Age,
                Sex = (int)u.Sex,
                Province = c.Province,
                City = c.CityName,
            });

            if (!SearchName.IsNullOrEmpty())
                test = test.Where(x => x.Name.Contains(SearchName));

            if (FromAge != 0)
                test = test.Where(x => x.Age >= FromAge);

            if (ToAge != 0)
                test = test.Where(x => x.Age <= ToAge);
            if (Sex != 0)
                test = test.Where(x => x.Sex == Sex);

            list = test.ToList();
            return list;
        }

        public bool AddUser(AddUserRequest body)
        {
            if (body.Name.IsNullOrEmpty())
                return false;

            if (body.Mail.IsNullOrEmpty())
                return false;
            else
            {
                if (!ValidEmailDataAnnotations(body.Mail))
                    return false;
                var mailExist = _userInfoRepository.Get(x => x.Mail == body.Mail);
                if (mailExist != null)
                    return false;
            }


            if (body.Password.IsNullOrEmpty())
                return false;
            else
            {
                if (body.Password.Length < 6)
                    return false;
                var rule1 = body.Password.All(char.IsLetter);
                var rule2 = body.Password.All(char.IsNumber);
                if (rule1 || rule2)
                    return false;
            }

            _userInfoRepository.Add(new UserInfo {
                Name  = body.Name,
                Mail = body.Mail,
                Password = body.Password,
                Age = body.Age,
                Sex = body.Sex,
                Location = body.Location
            });

            _userInfoRepository.save();

            return true;
        }
        public static bool ValidEmailDataAnnotations(string mail)
        {
            return new EmailAddressAttribute().IsValid(mail);
        }


    }
}
