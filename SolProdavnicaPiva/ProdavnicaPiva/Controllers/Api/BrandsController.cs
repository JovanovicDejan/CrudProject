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
    public class BrandsController : ApiController
    {
        private ApplicationDbContext _context;

        public BrandsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/brands
        public IEnumerable<BrandDto> GetBrands()
        {
            return _context.Brands.ToList().Select(Mapper.Map<Brand, BrandDto>);
        }

        //GET /api/brands/{id}

        public IHttpActionResult GetBrand(int id)
        {
            var brand = _context.Brands.SingleOrDefault(b => b.Id == id);
            if (brand == null)
                return NotFound();

            return Ok(Mapper.Map<Brand, BrandDto>(brand));
        }

        [HttpPost]
        public IHttpActionResult CreateBrands(BrandDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var brand = Mapper.Map<BrandDto, Brand>(brandDto);

            _context.Brands.Add(brand);
            _context.SaveChanges();

            brandDto.Id = brand.Id;

            return Created(new Uri(Request.RequestUri + "/" + brandDto.Id), brandDto);
        }


        [HttpPut]
        public void UpdateBrand(int id, BrandDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brandInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(brandDto, brandInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteBrand(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var brandInDb = _context.Brands.SingleOrDefault(b => b.Id == id);

            if (brandInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Brands.Remove(brandInDb);
            _context.SaveChanges();
        }
    }
}
