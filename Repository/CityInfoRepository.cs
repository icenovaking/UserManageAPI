using UserManageAPI.Models;

namespace UserManageAPI.Repository
{
    public class CityInfoRepository:Repository<CityInfo>, ICityInfoRepository
    {
        private readonly UserManageContext _db;
        public CityInfoRepository(UserManageContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
