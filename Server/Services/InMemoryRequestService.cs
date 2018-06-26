using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public class InMemoryRequestService : IRequestService
    {
        private readonly List<FaceRequest> _requests;

        public InMemoryRequestService()
        {
            _requests = new List<FaceRequest>();
        }
        public async Task AddAsync(FaceRequest faceRequest)
        {
            _requests.Add(faceRequest);
        }
        
        public async Task<FaceRequest> GetLatestRequestAsync()
        {
            var newestItems = _requests.Where(x => !x.IsCompleted).ToList();
            if (newestItems.Any())
            {
                var newestItem = newestItems.First();
                newestItem.IsCompleted = true;
                return newestItem;
            }
            return null;
        }
    }
}
