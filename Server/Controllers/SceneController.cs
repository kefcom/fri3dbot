using System;
using System.Collections.Generic;
using System.Linq;
using Assets.scripts;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/scenes")]
    public class SceneController : Controller
    {
        private readonly IReadOnlyList<int> _newestList  = new List<int>();


        [HttpGet]
        [Route("random")]
        public int GetRandomScene()
        {
            var rng = new Random();
            var randomPos = rng.Next(Shared.Faces.Count);
            return randomPos;
        }

        [HttpGet]
        [Route("newest")]
        public int GetNewestScene()
        {
            if (_newestList.Any())
            {
                return _newestList.First();
            }

            return -1;
        }
    }
}