namespace HT.Sports.Data.EF
{
    public class UserProfileRepo : RepoBase, IUserProfileRepo
    {
        public UserProfileRepo(SportsContext db) 
            : base(db)
        {
        }
    }
}
