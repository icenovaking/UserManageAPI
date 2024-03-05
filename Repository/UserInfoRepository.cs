using UserManageAPI.Models;

namespace UserManageAPI.Repository
{
    public class UserInfoRepository : Repository<UserInfo>, IUserInfoRepository
    {
        private readonly UserManageContext _db;
        public UserInfoRepository(UserManageContext db) : base(db)
        {
            _db = db;
        }
    }
}
