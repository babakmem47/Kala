using Kala.Controllers.Dtos;
using Kala.Models;
using System;
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
        // api/kalas to get all kalas for managers(except deleted)
        public IHttpActionResult GetKalas()
        {
            var kalas = _context.Kalas.ToList()
                .Where(k => !k.Deleted);

            return Ok(kalas.Select(k => new KalaDto()
            {
                Id = k.Id,
                Name = k.Name,
                Model = k.Model,
                Color = k.Color,
                Count = k.Count,
                Price = k.Price
            }));
        }

        [System.Web.Http.HttpGet]
        // api/kalasnames to get all names for autocomplete (except deleted)
        [System.Web.Http.Route("api/kalasnames")]
        public IHttpActionResult KalasNames()
        {
            var kalasnames = _context.Kalas
                .ToList()
                .Where(k => !k.Deleted)
                .Select(k => k.Name);

            return Ok(kalasnames);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/kalasbyname/{kalaname}")]
        // use:  api/kalasbyname/ساعت" for example in url for [search] and get one or more 
        public IHttpActionResult GetKala(string kalaName)
        {
            var kala = _context.Kalas
                .SingleOrDefault(k => k.Name == kalaName
                                      && !k.Deleted && k.Count > 0);

            if (kala != null)
                return Ok(new { data = kala });

            //else return a list of kalas that their names contain the keyword:
            var kalasThatNamesContainsKeyWord = _context.Kalas.ToList()
                    .Where(k => k.Name.Contains(kalaName)
                                && !k.Deleted);

            return Ok(kalasThatNamesContainsKeyWord);
        }

        [System.Web.Http.HttpGet]
        //use in edit
        [System.Web.Http.Route("api/kalas/{id}")]
        public IHttpActionResult GetKala(int id)
        {
            var kala = _context.Kalas
                .SingleOrDefault(k => k.Id == id && !k.Deleted && k.Count > 0);

            if (kala != null)
                return Ok(kala);

            return NotFound();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateKala(KalaDto kalaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("data is not valid");

            var kala = new Models.Kala()
            {
                Name = kalaDto.Name,
                Model = kalaDto.Model,
                Color = kalaDto.Color,
                Count = kalaDto.Count,
                Price = kalaDto.Price
            };

            _context.Kalas.Add(kala);
            _context.SaveChanges();

            kalaDto.Id = kala.Id;
            return Created(new Uri(Request.RequestUri + "/" + kala.Id), kalaDto);
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/updatekalas/{id}")]
        public IHttpActionResult UpdateKala(int id, KalaDto kalaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("data is not valid");

            var kalaInDb = _context.Kalas.SingleOrDefault(k => k.Id == id);

            if (kalaInDb == null)
                return NotFound();

            kalaInDb.Name = kalaDto.Name;
            kalaInDb.Model = kalaDto.Model;
            kalaInDb.Color = kalaDto.Color;
            kalaInDb.Count = kalaDto.Count;
            kalaInDb.Price = kalaDto.Price;

            _context.SaveChanges();

            return Ok();
        }

        //implementing logical delete
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/deletekalas/{id}")]
        public IHttpActionResult DeleteKala(int id)
        {
            var kala = _context.Kalas.SingleOrDefault(k => k.Id == id);

            if (kala == null)
                return BadRequest();

            kala.Deleted = true;

            return Ok("kala " + kala.Name + "deleted logically");
        }
    }
}
