using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.scripts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/faces")]
    public class FaceController : Controller
    {
        private readonly IReadOnlyList<int> _newestList  = new List<int>();
        private readonly FaceRequestContext _context;

        public FaceController()
        {
            _context = new FaceRequestContext();
        }

        [HttpGet]
        [Route("random")]
        public int GetRandomFace()
        {
            var rng = new Random();
            var randomPos = rng.Next(Shared.Faces.Count);
            return randomPos;
        }

        [HttpGet]
        [Route("newest")]
        public async Task<Shared.RequestDTO> GetNewestFace()
        {
            var newestItems = await _context.FaceRequests.Where(x => !x.IsCompleted).ToListAsync();
            if (newestItems.Any())
            {
                var newestItem = newestItems.First();
                newestItem.IsCompleted = true;
                await _context.SaveChangesAsync();
                var p = new Shared.RequestDTO()
                {
                    RequestedFaceId = newestItem.RequestedFaceId,
                    AuthorizationCode = newestItem.AuthorizationCode
                };
                return p;
            }

            return null;
        }

        [HttpPost]
        [Route("add")]
        public async Task AddNewFaceAsync([FromBody]FaceRequestDTO faceRequestDTO)
        {
            var faceRequest = new FaceRequest()
            {
                RequestedFaceId = faceRequestDTO.FaceId,
                AuthorizationCode = faceRequestDTO.AuthorizationCode,
                CreationDateTime = DateTime.UtcNow
            };
            _context.FaceRequests.Add(faceRequest);
            await _context.SaveChangesAsync();
        }
    }

    public class FaceRequestDTO
    {
        public int FaceId { get; set; }
        public int AuthorizationCode { get; set; }
    }
}