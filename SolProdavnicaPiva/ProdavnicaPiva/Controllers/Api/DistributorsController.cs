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
    public class DistributorsController : ApiController
    {
        private ApplicationDbContext _context;

        public DistributorsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/distributors
        public IEnumerable<DistributorDto> GetBeers()
        {
            return _context.Distributors.ToList().Select(Mapper.Map<Distributor, DistributorDto>);
        }

        //GET /api/distributors/{id}

        public IHttpActionResult GetDistributor(int id)
        {
            var distributor = _context.Distributors.SingleOrDefault(b => b.Id == id);
            if (distributor == null)
                return NotFound();

            return Ok(Mapper.Map<Distributor, DistributorDto>(distributor));
        }

        [HttpPost]
        public IHttpActionResult CreateDistributor(DistributorDto distributorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var distributor = Mapper.Map<DistributorDto, Distributor>(distributorDto);

            _context.Distributors.Add(distributor);
            _context.SaveChanges();

            distributorDto.Id = distributor.Id;

            return Created(new Uri(Request.RequestUri + "/" + distributorDto.Id), distributorDto);
        }


        [HttpPut]
        public void UpdateDistributor(int id, DistributorDto distributorDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var distributorInDb = _context.Distributors.SingleOrDefault(b => b.Id == id);

            if (distributorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(distributorDto, distributorInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteDistributor(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var distributorInDb = _context.Distributors.SingleOrDefault(b => b.Id == id);

            if (distributorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Distributors.Remove(distributorInDb);
            _context.SaveChanges();
        }
    }
}
