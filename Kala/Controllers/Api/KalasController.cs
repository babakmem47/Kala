using Kala.Controllers.Dtos;
using Kala.Models;
using System.Linq;
using System.Web.Http;

namespace Kala.Controllers.Api
{
    public class KalasController : ApiController
    {
        private ApplicationDbContext _context;

        public KalasController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
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

        [HttpGet]
        [Route("api/kalasnames")]
        public IHttpActionResult KalasNames()
        {
            var kalasnames = _context.Kalas.ToList().Select(k => k.Name);

            return Ok(kalasnames);
        }

    }
}
