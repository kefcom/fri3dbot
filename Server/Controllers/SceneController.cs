using System;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/scenes")]
    public class SceneController : Controller
    {
        private static string[] Scenes = new[]
        {
            "bend-r-init", "eeve-init", "gearHead_init",
        };

        [HttpGet]
        [Route("random")]
        public string GetScenes()
        {
            var rng = new Random();
            var randomPos = rng.Next(Scenes.Length);
            return  Scenes[randomPos];
        }
    }
}