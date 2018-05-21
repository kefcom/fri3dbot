using System;
using Assets.scripts;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/scenes")]
    public class SceneController : Controller
    {
        

        [HttpGet]
        [Route("random")]
        public int GetScenes()
        {
            var rng = new Random();
            var randomPos = rng.Next(Shared.Faces.Count);
            return randomPos;
        }
    }
}