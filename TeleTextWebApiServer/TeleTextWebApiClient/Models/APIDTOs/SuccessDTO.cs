using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTextWebApiServer.Models
{
    public class SuccessDTO
    {
        public int success { get; set; }
        public string[] message { get; set; }
    }
}