using CinemaAPI.Data;
using CinemaAPI.Domain.Contracts;
using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Projection;
using CinemaAPI.Models.Contracts.Room;

namespace CinemaAPI.Domain.NewProjection
{
    public class NewProjectionRoomValidation : INewProjection
    {
        private readonly IRoomRepository roomRepo;
        private readonly INewProjection newProj;

        public NewProjectionRoomValidation(IRoomRepository roomRepo, INewProjection newProj)
        {
            this.roomRepo = roomRepo;
            this.newProj = newProj;
        }

        public NewProjectionSummary New(IProjectionCreation proj)
        {
            IRoom room = roomRepo.GetById(proj.RoomId);

            if (room == null)
            {
                return new NewProjectionSummary(false, $"Room with id {proj.RoomId} does not exist");
            }

            return newProj.New(proj);
        }
    }
}