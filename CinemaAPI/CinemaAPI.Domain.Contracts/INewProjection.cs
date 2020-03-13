using CinemaAPI.Domain.Contracts.Models;
using CinemaAPI.Models.Contracts.Projection;

namespace CinemaAPI.Domain.Contracts
{
    public interface INewProjection
    {
        NewProjectionSummary New(IProjectionCreation projection);
    }
}