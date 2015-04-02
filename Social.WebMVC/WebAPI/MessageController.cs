using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Crawlers;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services;
using Social.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;

namespace Social.WebMVC
{
    public class MessageController : ApiController
    {
        private MessageService service = (MessageService)UnityHelper.ServiceResolve<Message>();

        // GET api/<controller>
        public List<MessageTO> Get()
        {
            List<MessageTO> l = service.GetTOsByEntityIdFromTo(-1, null, -1).ToList();
            return l;
        }
        public List<MessageTO> Get(int id, string mode)
        {
            List<MessageTO> l = null;
            if (mode == "after") { 
                l = service.GetTOsByEntityIdFromTo(-1, null, -1, afterId:id).ToList();
            }
            else if (mode == "before")
            {
                l = service.GetTOsByEntityIdFromTo(-1, null, -1, beforeId:id).Reverse().ToList();
            }
            else if (mode == "like")
            {
                service.Like(id, -1);
            }
            return l;
        }

        public List<CommentTO> Get(int parentId, int id, string mode)
        {
            List<CommentTO> l = null;
            if (mode == "after")
            {
                l = service.GetCommentTOsByParentId(parentId, -1, afterId: id).ToList();
            }
            else if (mode == "before")
            {
                l = service.GetCommentTOsByParentId(parentId, -1, beforeId: id).Reverse().ToList();
            }
            else if (mode == "like")
            {
                service.Like(id, -1);
            }
            return l;
        }
        // GET api/<controller>/5
        public MessageTO Get(int id)
        {
            return service.GetTOById(id, -1);
        }

        public CommentTO Get(int parentId, int id)
        {
            return service.GetCommentTOById(id, -1);
        }

        // POST api/<controller>
        public void Post([FromBody]MessageTO value)
        {
            value.FromId = -1;
            value.ToId = -1;
            value.Text = value.Text.Trim();
            if (value.Text.Length > 4000) value.Text = value.Text.Substring(0, 4000);
            if (value.Title != null)
            {
                value.Title = value.Title.Trim();
                if (value.Title.Length > 100) value.Title = value.Title.Substring(0, 100);
            }
            if (value.Description != null)
            {
                value.Description = value.Description.Trim();
                if (value.Description.Length > 500) value.Description = value.Description.Substring(0, 500);
            }
            if (value.Url != null)
            {
                value.Url = value.Url.Trim();
                if (value.Url.Length > 255) value.Url.Substring(255);
            }
            if (value.ImageUrl != null)
            {
                value.ImageUrl = value.ImageUrl.Trim();
                if (value.ImageUrl.Length > 255) value.ImageUrl.Substring(255);
            }
            if (value.VideoUrl != null)
            {
                value.VideoUrl = value.VideoUrl.Trim();
                if (value.VideoUrl.Length > 255) value.VideoUrl.Substring(255);
            }
            service.Insert(value);
        }

        /*
         * // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }*/

    }
}