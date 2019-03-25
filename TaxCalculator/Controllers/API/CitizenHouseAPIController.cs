using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TaxCalculator.DAL;
using TaxCalculator.DTOS;
using TaxCalculator.Models;

namespace TaxCalculator.Controllers.API
{
    public class CitizenHouseAPIController : ApiController
    {
        private CitizenDbContext _context;
        public CitizenHouseAPIController()
        {
            _context = new CitizenDbContext();
        }

        //GET /api/citizenhouses
        public IEnumerable<CitizenHouseDto> GetCitizenHouses()
        {
            return _context.CitizenHouses.ToList().Select(Mapper.Map<CitizenHouse,CitizenHouseDto>);
        }

        //GET /api/citizenhouses/1
        public CitizenHouseDto GetCitizenHouse(int id)
        {
            var citizenHouse = _context.CitizenHouses.SingleOrDefault(c => c.Id == id);

            if (citizenHouse == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<CitizenHouse,CitizenHouseDto>(citizenHouse);
        }

        //POST //api/citizenHouses
        [HttpPost]      //only be called if HTTPPOST request is sent
        public IHttpActionResult CreateCitizenHouse(CitizenHouseDto citizenHouseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var citizenHouse = Mapper.Map<CitizenHouseDto, CitizenHouse>(citizenHouseDto);
            _context.CitizenHouses.Add(citizenHouse);
            _context.SaveChanges();

            citizenHouseDto.Id = citizenHouse.Id;

            return Created(new Uri(Request.RequestUri + "/" + citizenHouse.Id),citizenHouseDto);
        }

        //PUT /api/CitizenHouse/1
        [HttpPut]
        public void UpdateCitizenHouse(int id, CitizenHouseDto citizenHouseDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var citizenHouseInDb = _context.CitizenHouses.SingleOrDefault(c => c.Id == id);

            if (citizenHouseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(citizenHouseDto, citizenHouseInDb);

            _context.SaveChanges();           
        }

        //Delete /api/CitizenHouse/1
        [HttpDelete]
        public void DeleteCitizenHouse(int id)
        {
            var citizenHouseInDb = _context.CitizenHouses.SingleOrDefault(c => c.Id == id);

            if (citizenHouseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.CitizenHouses.Remove(citizenHouseInDb);
            _context.SaveChanges();
        }




    }
}
