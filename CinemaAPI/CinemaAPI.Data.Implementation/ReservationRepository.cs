using System.Linq;
using System.Collections.Generic;

using CinemaAPI.Models.Contracts.Reservation;
using CinemaAPI.Models;
using CinemaAPI.Data.EF;
using CinemaAPI.Models.DTOs;

namespace CinemaAPI.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaDbContext db;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public void CancelReservation()
        {
            // TODO: 
        }

        public IEnumerable<IReservation> GetRowsAndColsById(long id)
        {
            return db.Reservations
                .Where(r => r.ProjectionId == id)
                .SelectMany(x => new List<ReservationDto>() {
                    new ReservationDto
                    {
                        Row = x.Row,
                        Column = x.Column
                    }})
                .ToList();
        }

        public IReservation GetInfo(long id)
        {
            return db.Projections
                .Where(p => p.Id == id)
                .Select(s => new ReservationDto
                {
                    ProjectionStartDate = s.StartDate,
                    MovieName = s.Movie.Name,
                    RoomNumber = s.Room.Number,
                    CinemaName = s.Room.Cinema.Name
                })
                .Single();
        }

        public IReservation Insert(IReservationCreation reservation)
        {
            Reservation newReservation = new Reservation(
                   reservation.ProjectionId,
                   reservation.UniqueNumberGuid,
                   reservation.ProjectionStartDate,
                   reservation.MovieName,
                   reservation.CinemaName,
                   reservation.RoomNumber,
                   reservation.Row,
                   reservation.Column,
                   reservation.IsActive);

            db.Reservations.Add(newReservation);

            db.Projections
                .Where(p => p.Id == reservation.ProjectionId)
                .ToList()
                .ForEach(x => x.AvailableSeatsCount--);

            db.SaveChanges();

            return newReservation;
        }

        public IReservation GetReservationByUniqueNumber(string uniqueNumberGuid)
        {
            Reservation reservation = db.Reservations
               .Where(r => r.UniqueNumberGuid == uniqueNumberGuid)
               .FirstOrDefault();

            db.Reservations
                .Where(r => r.UniqueNumberGuid == uniqueNumberGuid)
                .ToList()
                .ForEach(x => x.IsActive = false);

            db.SaveChanges();

            return reservation;
        }
    }
}
