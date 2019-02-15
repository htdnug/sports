namespace HT.Sports.Data.EF
{
    public abstract class RepoBase
    {
        protected readonly SportsContext Db;

        public RepoBase(SportsContext db)
        {
            this.Db = db;
        }

        public SportsContext Context => this.Db;
    }
}
