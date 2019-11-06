using Kala.Controllers.Dtos;
using Kala.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Kala.Controllers.Api
{
    public class KalasController : ApiController
    {
        private ApplicationDbContext _context;

        public KalasController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetKalas()
        {
            var kalas = _context.Kalas.ToList();

            return Ok(kalas.Select(k => new KalaDto()
            {
                Id = k.Id,
                Name = k.Name,
                Model = k.Model,
                Color = k.Color,
                AvailableNumber = k.AvailableNumber
            }));
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/kalasnames")]
        public IHttpActionResult KalasNames()
        {
            var kalasnames = _context.Kalas.ToList().Select(k => k.Name);

            return Ok(kalasnames);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/kalasbyname/{kalaname}")]
        // use:  api/kalas/ساعت" for example in url
        public IHttpActionResult GetKala(string kalaName)
        {
            var kala = _context.Kalas.SingleOrDefault(k => k.Name == kalaName);

            if (kala != null)
                return Ok(new { data = kala });
            
            //else return a list of kalas that their names contain the keyword:
            var kalasThatNamesContainsKeyWord = _context.Kalas.ToList()
                    .Where(k => k.Name.Contains(kalaName));

            return Ok(kalasThatNamesContainsKeyWord);
        }

    }
}
