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
    public class ManufacturersController : ApiController
    {
        private ApplicationDbContext _context;

        public ManufacturersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/brands
        public IEnumerable<ManufacturerDto> GetManufacture()
        {
            return _context.Manufacturers.ToList().Select(Mapper.Map<Manufacturer, ManufacturerDto>);
        }

        //GET /api/brands/{id}

        public IHttpActionResult GetManfucature(int id)
        {
            var manufacturer = _context.Manufacturers.SingleOrDefault(b => b.Id == id);
            if (manufacturer == null)
                return NotFound();

            return Ok(Mapper.Map<Manufacturer, ManufacturerDto>(manufacturer));
        }

        [HttpPost]
        public IHttpActionResult CreateManofacturer(ManufacturerDto manufacturerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var manufacture = Mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);

            _context.Manufacturers.Add(manufacture);
            _context.SaveChanges();

            manufacturerDto.Id = manufacture.Id;

            return Created(new Uri(Request.RequestUri + "/" + manufacturerDto.Id), manufacturerDto);
        }


        [HttpPut]
        public void UpdateManufacturer(int id, Manufacturer manufacturerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var manufacturerDb = _context.Manufacturers.SingleOrDefault(b => b.Id == id);

            if (manufacturerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(manufacturerDto, manufacturerDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteManufacturer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var manufacturerDb = _context.Manufacturers.SingleOrDefault(b => b.Id == id);

            if (manufacturerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Manufacturers.Remove(manufacturerDb);
            _context.SaveChanges();
        }
    }
}
