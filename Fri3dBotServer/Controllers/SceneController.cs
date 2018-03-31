using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fri3dBotServer.Controllers
{
    [Route("api/scenes")]
    public class SceneController : Controller
    {
        private static string[] Scenes = new[]
        {
            "bend-r-init", "eeve-init", "gearHead_init", 
        };

        [HttpGet]
        [Route("new")]
        public string GetScenes()
        {
            var rng = new Random();
            var randomPos =  rng.Next(Scenes.Length);
            return Scenes[randomPos];
        }
    }
}
