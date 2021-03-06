﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleTextWebApiClient.Models.APIDTOs;

namespace TeleTextWebApiClient.Controllers
{
    public class TeleTextController : Controller
    {
        public ActionResult SendTeleText()
        {
            return View();
        }

        public ActionResult GetServerResults(string tbTeleText)
        {
            List<MessageEntity> messageResponse = getResponseFromTeleTextApi(tbTeleText);

            return View(messageResponse);
        }

        private List<MessageEntity> getResponseFromTeleTextApi(string inputText)
        {
            try
            {
                //string SAMPLE_TEXT =
                //"Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 " +
                //"characters. The program should try to break on complete sentences or punctuation marks if possible.  " +
                //"If a comma or sentence break occurs within 5 characters of the max line length, the line should be broken early.  " +
                //"The exception to this rule is when the next line will only contain 5 characters.  Redundant whitespace should " +
                //"not be counted between lines, and any duplicate   spaces should be removed.  " +
                //"Does this make sense? If not please ask for further clarification, an array containing " +
                //"the desired outcome has been provided below. Any text beyond this point is not part of the instructions, " +
                //"it's only here to ensure test converge. Finish line. Aaa asdf asdfjk las, asa.";
                
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var data = "=" + inputText;
                    var result1 = client.UploadString("http://localhost:58592/api/teletext", "POST", data);

                    List<MessageEntity> messageResponse = JsonConvert.DeserializeObject<List<MessageEntity>>(result1);
                    return messageResponse;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}