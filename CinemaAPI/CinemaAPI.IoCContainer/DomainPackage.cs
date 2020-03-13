using CinemaAPI.Domain;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.NewProjection;
using CinemaAPI.Domain.NewReservation;
using CinemaAPI.Domain.NewTicket;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemaAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();

            container.Register<INewReservation, NewReservationCreation>();
            container.RegisterDecorator<INewReservation, NewReservationSeatsValidation>();
            container.RegisterDecorator<INewReservation, NewReservationRoomValidation>();
            container.RegisterDecorator<INewReservation, NewReservationProjectionValidation>();

            container.Register<INewTicket, NewTicketCreation>();
            container.RegisterDecorator<INewTicket, NewTicketProjectionValidation>();
            container.RegisterDecorator<INewTicket, NewTicketReservationValidation>();
            container.RegisterDecorator<INewTicket, NewTicketSeatsValidation>();
        }
    }
}