using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services
{
    public class InMemoryRequestService : IRequestService
    {
        private readonly List<FaceRequest> _requests;
        private int Id { get; set; }

        public InMemoryRequestService()
        {
            Id = 0;
            _requests = new List<FaceRequest>();
        }
        public async Task AddAsync(FaceRequest faceRequest)
        {
            faceRequest.Id = Id++;
            _requests.Add(faceRequest);
        }

        public async Task<FaceRequest> GetLatestRequestAsync()
        {
            var newestItems = _requests
                .Where(x => !x.IsCompleted)
                .OrderBy(x => x.Id).ToList();
            if (newestItems.Any())
            {
                var newestItem = newestItems.First();
                newestItems.ForEach(x => x.IsCompleted = true);
                return newestItem;
            }
            return null;
        }
    }
}
