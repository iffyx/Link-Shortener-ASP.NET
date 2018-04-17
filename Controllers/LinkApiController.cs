using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projekt2.Models;
using projekt2.Repositories;

namespace projekt2.Controllers
{
    public class LinkApiController : Controller
    {
        private readonly ILinkApiRepository _repository;
        private int itemPerPage = 10;
        public LinkApiController(ILinkApiRepository linkRepository)
        {
            _repository = linkRepository;
        }

        [HttpGet("api/links/{id}")]
        // GET api/links/{id}
        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        //GET api/links/?search={string}&page={int}
        [HttpGet("api/links/search={string}&page={int}")]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = _repository
                    .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            return Ok(result);
        }

        // DELETE api/links/{id}
        [HttpDelete("api/links/{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

        //POST api/links
        [HttpPost("api/links")]
        public IActionResult Post([FromBody]CreateLinkRequest createLink)
        {
            return Ok(_repository.Create(createLink.GetLink()));
        }

        //POST api/links
        [HttpPut("api/links")]
        public IActionResult Put([FromBody]Link link)
        {
            return Ok(_repository.Update(link));
        }


    }
}