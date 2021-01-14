using Debug.Database.Context;
using Debug.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debug.Database.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DatabaseController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DatabaseController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("db")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var messages = await _db.Messages.ToListAsync();
                return new JsonResult(messages);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("db/create")]
        public IActionResult SaveToDb([FromBody] Message msg)
        {
            try
            {
                _db.Add(msg);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        [Route("db/update")]
        public async Task<IActionResult> UpdateBug([FromBody] Message updatedMessage)
        {
            try
            {
                var message = _db.Messages.Where(x => x.Id == updatedMessage.Id).FirstOrDefault();
                message.Text = updatedMessage.Text;
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete]
        [Route("db/delete")]
        public async Task<IActionResult> DeleteBug(string id)
        {
            try
            {
                var guidId = Guid.Parse(id);
                var msg = await _db.Messages.Where(x => x.Id == guidId).ToListAsync();
                _db.RemoveRange(msg);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }

}
