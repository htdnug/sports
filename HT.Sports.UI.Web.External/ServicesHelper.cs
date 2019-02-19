using HT.Sports.Data;
using HT.Sports.Data.EF;
using Microsoft.Extensions.DependencyInjection;

namespace HT.Sports.UI.Web.External
{
    internal class ServicesHelper
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();

        private static ServicesHelper instance;

        private ServicesHelper()
        {
        }

        public static ServicesHelper Instance
        {
            get 
            { 
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new ServicesHelper();
                    }
                }

                return instance; 
            }
        }

        #endregion

        public void RegisterServices(IServiceCollection services)
        {
            // setup custom services here
            services.AddScoped<ITripRepo, TripRepo>();
            services.AddScoped<IUserProfileRepo, UserProfileRepo>();
        }
    }
}
