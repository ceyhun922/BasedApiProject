using System.Threading.Tasks;
using BasetApi.Concrete;
using BasetApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasetApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class AdminController : ControllerBase
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        //Users
        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var values = _context.Users.ToList();

            return Ok(values);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetByUser(string id)
        {
            var value = _context.Users.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        [HttpPut("UserUpdateById/{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            var value = await _context.Users.FindAsync(id);
            if (value == null) return NotFound();

            value.Name = user.Name;
            value.Surname = user.Surname;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("UserDeleteById/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var value = await _context.Users.FindAsync(id);

            if (value == null) return NotFound();

            _context.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //products

        
        //category
        [HttpGet("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("GetCategoryById/{id}")]
        public IActionResult GetById(int id)
        {
            var value = _context.Categories.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }
        [HttpPost("AddnewCategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            var value = _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Category eklendi: " + value);
        }
        [HttpPut("UpdateCategoryById/{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            category.CategoryName = value.CategoryName;
            category.CategoryStatus = value.CategoryStatus;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("DeleteteCategoryById/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(value);
            _context.SaveChanges();
            
            return NoContent();
        }

    }
}