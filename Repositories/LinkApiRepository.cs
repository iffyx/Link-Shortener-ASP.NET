using System;
using System.Collections.Generic;
using System.Linq;
using HashidsNet;
using Microsoft.EntityFrameworkCore;
using projekt2.Models;

namespace projekt2.Repositories
{
    public class LinkApiRepository : ILinkApiRepository
    {
        private readonly LinkDbContext _context;
        public LinkApiRepository(LinkDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Link stopEntity = _context.Links.Find(id);
            _context.Links.Remove(stopEntity);
            _context.SaveChanges();
        }

        public Link Create(Link link)
        {

            var hashids = new Hashids("this is my salt",8);
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            // no hash collision check
            // can generate same hash for different links
            link.ShortLink = hashids.Encode(link.Id);
            //_links.Add(link);


            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public (IEnumerable<Link>, int) Get(string search, int skip)
        {
            var linksFilteredByShortLink = search != null ? _context.Links
            .Where(x => x.ShortLink.ToLower()
            .Contains(search)) : _context.Links;
            var linksCount = linksFilteredByShortLink.Count();

            var paginatedLink = linksFilteredByShortLink
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(20);

            return (paginatedLink, linksCount);
        }


        public Link Get(int id)
        {
            return _context.Links.Find(id);
        }
    }
}