using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class FaceRequest
    {
        public int Id { get; set; }
        public int AuthorizationCode { get; set; }
        public int RequestedFaceId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
