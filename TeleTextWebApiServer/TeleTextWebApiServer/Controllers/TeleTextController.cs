using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeleTextWebApiServer.Models.DTO;


namespace TeleTextWebApiServer.Controllers
{
    public class TeleTextController : ApiController
    {
        [HttpGet]
        public string StartServer()
        {
            return "Teletext Server started successfully. Please start the client App";
        }

        // GET: api/TeleText
        public IEnumerable<string> Get()
        {
            return new string[] { "TeleText1", "TeleText2" };
        }

        // GET: api/TeleText/5
        public string Get(int id)
        {
            return "TeleText" + id;
        }

        // POST: api/TeleText
        public HttpResponseMessage Post([FromBody]string value)
        {
            //var response = Request.CreateResponse(HttpStatusCode.Created, value);

            //return response;
            var sampleText = value;
            int maxLengthOfLine = 25;
            try
            {
                //string[] a = new string[100];
                //int index = 0;
                List<MessageEntity> messageList = new List<MessageEntity>();

                for (int i = 0; i < sampleText.Length; i += maxLengthOfLine)
                {
                    maxLengthOfLine = 25;
                    if ((i + maxLengthOfLine) < sampleText.Length)
                    {
                        var line = sampleText.Substring(i, maxLengthOfLine);
                        // remove double spaces if any
                        while (line.Contains("  ")) line = line.Replace("  ", " ");

                        int lastWordStart = line.LastIndexOf(" ") + 1;

                        // Do not truncate the last word
                        if (lastWordStart < maxLengthOfLine)
                        {
                            int lastWordLen = line.Length - lastWordStart;
                            maxLengthOfLine = maxLengthOfLine - lastWordLen;
                            line = sampleText.Substring(i, maxLengthOfLine).Trim();
                        }

                        // If Comma occurs then break early
                        var indexOfComma = line.LastIndexOf(",");
                        if (indexOfComma != -1 && (line.Length - 1 - indexOfComma) <= 5)
                        {
                            maxLengthOfLine = indexOfComma + 1;
                            line = sampleText.Substring(i, indexOfComma).Trim();
                        }
                        // If sentence break occurs then break early
                        var indexOfFullStop = line.LastIndexOf(".");
                        if (indexOfFullStop != -1 && (line.Length - 1 - indexOfFullStop) <= 5)
                        {
                            maxLengthOfLine = indexOfFullStop + 1;
                            line = sampleText.Substring(i, indexOfFullStop + 1).Trim();
                        }
                        messageList.Add(new MessageEntity() { Success = true, MessageLine = line });
                    }
                    else
                    {
                        messageList.Add(new MessageEntity() { Success = true, MessageLine = sampleText.Substring(i) });
                    }
                }
                var message = Request.CreateResponse(HttpStatusCode.OK, messageList);
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
    }
}
