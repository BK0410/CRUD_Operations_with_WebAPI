using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPIproject.Data;
using SampleWebAPIproject.Data.Entities;

namespace SampleWebAPIproject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class WebAPIusersController : ControllerBase
    {

        private readonly WebAPIusersDBContext _webAPIusersDbContext;

        public WebAPIusersController(WebAPIusersDBContext webAPIusersDbContext)
        {
            _webAPIusersDbContext = webAPIusersDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _webAPIusersDbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("getByID")]
        public async Task<IActionResult> GetByID(int ID)
        {
            var user = await _webAPIusersDbContext.Users.FindAsync(ID);
            return Ok(user);
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync(Users newUser)
        {
            _webAPIusersDbContext.Users.Add(newUser);
            await _webAPIusersDbContext.SaveChangesAsync();
            return Created($"getByID?ID={newUser.ID}", newUser);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Users userToUpdate)
        {
            _webAPIusersDbContext.Users.Update(userToUpdate);
            await _webAPIusersDbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(int ID)
        {
            var userToDelete = await _webAPIusersDbContext.Users.FindAsync(ID);
            if(userToDelete == null)
            {
                return NotFound();
            }
            _webAPIusersDbContext.Users.Remove(userToDelete);
            await _webAPIusersDbContext.SaveChangesAsync();
            return NoContent();
        }
    }

    
}
