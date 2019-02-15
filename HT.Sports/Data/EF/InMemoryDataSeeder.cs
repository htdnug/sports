using HT.Sports.Entities;

namespace HT.Sports.Data.EF
{
    public class InMemoryDataSeeder 
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();

        private static InMemoryDataSeeder instance;

        private InMemoryDataSeeder()
        {
        }

        public static InMemoryDataSeeder Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new InMemoryDataSeeder();
                    }
                }

                return instance;
            }
        }

        #endregion

        public void Seed(SportsContext context)
        {
            context.UserProfiles.AddRange(this.BuildUserProfileData());
            context.SaveChanges();
        }

        private UserProfile[] BuildUserProfileData()
        {
            return new UserProfile[]
            {
                new UserProfile { Id = 1, DisplayName = "Admin" },
                new UserProfile { Id = 2, DisplayName = "User" }
            };
        }
    }
}
