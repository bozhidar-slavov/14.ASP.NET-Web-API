using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

using CinemaAPI.Models;

namespace CinemaAPI.Data.EF.ModelConfigurations
{
    internal sealed class ReservationModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Reservation> reservationModel = modelBuilder.Entity<Reservation>();

            reservationModel.HasKey(model => model.Id);
            reservationModel.Property(model => model.ProjectionId).IsRequired();
            reservationModel.Property(model => model.UniqueNumberGuid).IsRequired();
            reservationModel.Property(model => model.ProjectionStartDate).IsRequired();
            reservationModel.Property(model => model.MovieName).IsRequired();
            reservationModel.Property(model => model.CinemaName).IsRequired();
            reservationModel.Property(model => model.RoomNumber).IsRequired();
            reservationModel.Property(model => model.Row).IsRequired();
            reservationModel.Property(model => model.Column).IsRequired();
            reservationModel.Property(model => model.IsActive).IsRequired();
        }
    }
}
