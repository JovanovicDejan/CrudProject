using AutoMapper;
using ProdavnicaPiva.Dtos;
using ProdavnicaPiva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProdavnicaPiva.Controllers.Api
{
    public class BeersController : ApiController
    {
        private ApplicationDbContext _context;

        public BeersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/beers
        public IEnumerable<BeerDto> GetBeers()
        {
            return _context.Beers.ToList().Select(Mapper.Map<Beer, BeerDto>);
        }

        //GET /api/beer/{id}

        public IHttpActionResult GetBeer(int id)
        {
            var beer = _context.Beers.SingleOrDefault(b => b.Id == id);
            if (beer == null)
                return NotFound();

            return Ok(Mapper.Map<Beer, BeerDto>(beer));
        }

        [HttpPost]
        public IHttpActionResult CreateBeer(BeerDto beerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var beer = Mapper.Map<BeerDto, Beer>(beerDto);

            _context.Beers.Add(beer);
            _context.SaveChanges();

            beerDto.Id = beer.Id;

            return Created(new Uri(Request.RequestUri + "/" + beerDto.Id), beerDto);
        }


        [HttpPut]
        public void UpdateBeer(int id, BeerDto beerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var beerInDb = _context.Beers.SingleOrDefault(b => b.Id == id);

            if (beerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(beerDto, beerInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteBeer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var beerInDb = _context.Beers.SingleOrDefault(b => b.Id == id);

            if (beerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Beers.Remove(beerInDb);
            _context.SaveChanges();
        }
    }
}
