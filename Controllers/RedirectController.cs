using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projekt2.Repositories;
using projekt2.Models;
using HashidsNet;

namespace projekt2.Controllers
{
    public class RedirectController : Controller
    {
        private ILinkApiRepository _repository;
        
        public RedirectController(ILinkApiRepository linkRepository)
        {
            _repository = linkRepository;
        }

       /* [Route("{Id}")]
        //[HttpGet("/{shortUrl}")]
        public IActionResult RedirectToUrl(string Id) 
        {   
            var hashids = new Hashids("this is my salt",8);
            var hash = hashids.Decode(Id);
            Link link = _repository.Get(hash[0]);
            return Redirect("http://"+link.FullLink+"");
        }*/
    }
}