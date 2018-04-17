using System.Collections.Generic;
using projekt2.Models;

namespace projekt2.Repositories
{
    public interface ILinkApiRepository
    {
        (IEnumerable<Link>, int) Get(string search, int skip);
        Link Get(int Id);
        Link Create(Link link);
        Link Update(Link link);
        void Delete(int id);        
    }
}