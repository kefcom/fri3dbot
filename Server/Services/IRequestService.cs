using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public interface IRequestService
    {
        Task AddAsync(FaceRequest faceRequest);
        Task<FaceRequest> GetLatestRequestAsync();
    }
}