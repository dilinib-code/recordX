using Microsoft.AspNetCore.Mvc; // For ApiController, ControllerBase, HttpGet, HttpPost, IActionResult, etc.
using MongoDB.Driver; // For MongoDB database access
using System.Collections.Generic; // For List<T>
using System.Threading.Tasks; // For asynchronous programming (Task, async/await)
using recordX.Data;
using recordX.Models;

namespace recordX.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController(MongoDbContext context) : ControllerBase
    {
        private readonly MongoDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Customers.Find(c => true).ToListAsync();
                if (customers == null || customers.Count == 0)
                {
                    Console.WriteLine("No customers found.");
                }
                else
                {
                    Console.WriteLine($"Found {customers.Count} customers.");
                }
                return customers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching customers: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            await _context.Customers.InsertOneAsync(customer);
            return Ok();
        }
    }
}