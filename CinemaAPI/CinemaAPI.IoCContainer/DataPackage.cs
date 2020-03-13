using CinemaAPI.Data;
using CinemaAPI.Data.EF;
using CinemaAPI.Data.Implementation;

using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemaAPI.IoCContainer
{
    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICinemaRepository, CinemaRepository>(Lifestyle.Scoped);
            container.Register<IRoomRepository, RoomRepository>(Lifestyle.Scoped);
            container.Register<IMovieRepository, MovieRepository>(Lifestyle.Scoped);
            container.Register<IProjectionRepository, ProjectionRepository>(Lifestyle.Scoped);
            container.Register<IReservationRepository, ReservationRepository>(Lifestyle.Scoped);
            container.Register<ITicketRepository, TicketRepository>(Lifestyle.Scoped);

            container.Register<CinemaDbContext>(Lifestyle.Scoped);
        }
    }
}