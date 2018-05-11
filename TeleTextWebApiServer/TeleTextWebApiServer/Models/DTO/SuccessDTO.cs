using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeleTextWebApiServer.Models.DTO
{
    public class MessageEntity
    {
        public bool Success { get; set; }
        public string MessageLine { get; set; }
    }
}