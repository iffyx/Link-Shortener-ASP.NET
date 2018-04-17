using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projekt2.Repositories;
using projekt2.Models;
using HashidsNet;

namespace projekt2.Controllers
{
    public class LinkController : Controller
    {
        private ILinkApiRepository _repository;
        
        public LinkController(ILinkApiRepository linkRepository)
        {
            _repository = linkRepository;
        }

        public IActionResult Index()
        {
            var links = _repository.Get(1);
            return View(links);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            _repository.Create(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link.Id);
            return Redirect("Index");
        }
    }
}