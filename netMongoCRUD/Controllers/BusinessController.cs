using Microsoft.AspNetCore.Mvc;
using netMongoCRUD.Models;
using netMongoCRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netMongoCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : Controller
    {
        private IBusinessCollection db = new BusinessCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses()
        {
            return Ok(await db.GetAllBusinesses());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusiness([FromBody] Business business)
        {
            if(business == null)
            {
                return BadRequest();
            }
            if(business.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The business should't be empty");
            }

            await db.InsertBusiness(business);

            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusiness([FromBody] Business business, string id)
        {
            if (business == null)
            {
                return BadRequest();
            }
            if (business.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The business should't be empty");
            }

            business.Id = new MongoDB.Bson.ObjectId(id);

            await db.UpdateBusiness(business);

            return Created("Created", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(string id)
        {
            await db.DeleteBusiness(id);

            return NoContent();
        }
    }
}
