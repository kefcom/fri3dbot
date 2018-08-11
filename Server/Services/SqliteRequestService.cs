using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Services
{
    public class SqliteRequestService : IRequestService
    {
        private readonly FaceRequestContext _context;

        public SqliteRequestService()
        {
            _context = new FaceRequestContext();
        }
        public async Task AddAsync(FaceRequest faceRequest)
        {
            _context.FaceRequests.Add(faceRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<FaceRequest> GetLatestRequestAsync()
        {
            var newestItems = await _context.FaceRequests.Where(x => !x.IsCompleted).ToListAsync();
            if (newestItems.Any())
            {
                var newestItem = newestItems.First();
                newestItem.IsCompleted = true;
                await _context.SaveChangesAsync();
                return newestItem;
            }
            return null;
        }
    }
}
