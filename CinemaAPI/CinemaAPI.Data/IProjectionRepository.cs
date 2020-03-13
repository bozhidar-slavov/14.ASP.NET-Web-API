using System;
using System.Collections.Generic;

using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Data
{
    public interface IProjectionRepository
    {
        IProjection Get(int movieId, int roomId, DateTime startDate);

        IProjection GetById(long id);

        void Insert(IProjectionCreation projection);

        IEnumerable<IProjection> GetActiveProjections(int roomId);
    }
}