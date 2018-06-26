using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.scripts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/faces")]
    public class FaceController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IReadOnlyList<int> _newestList  = new List<int>();
        private readonly FaceRequestContext _context;

        public FaceController(IRequestService requestService)
        {
            _requestService = requestService;
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
            var request = await _requestService.GetLatestRequestAsync();
            if (request != null)
            {
                var p = new Shared.RequestDTO()
                {
                    RequestedFaceId = request.RequestedFaceId,
                    AuthorizationCode = request.AuthorizationCode
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
            await _requestService.AddAsync(faceRequest);
        }
    }

    public class FaceRequestDTO
    {
        public int FaceId { get; set; }
        public int AuthorizationCode { get; set; }
    }
}