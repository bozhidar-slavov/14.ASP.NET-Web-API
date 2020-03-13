using System.Data.Entity;

namespace CinemaAPI.Data.EF
{
    public interface IModelConfiguration
    {
        void Configure(DbModelBuilder modelBuilder);
    }
}
