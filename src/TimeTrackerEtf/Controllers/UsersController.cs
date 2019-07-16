using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeTrackerEtf.Data;
using TimeTrackerEtf.Models;

namespace TimeTrackerEtf.Controllers
{

    /// <summary>
    /// Encapsulates functionality for adding, modeifying and deleting
    /// users.
    /// </summary>

    [ApiController]
    [Authorize]
    [Route("/api/users")]
    public class UsersController : Controller //ctor pa tab
    {
        private readonly TimeTrackerDbContext _dbContext; //konvencija pisanja sa donjom crtom
        private readonly ILogger<UsersController> _logger;
        public UsersController(TimeTrackerDbContext dbContext, ILogger<UsersController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        
        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<UserModel>> GetById(long id) //asinhrono izvrsavanje. ulazna tacka
        {
            _logger.LogInformation($"Getting user by  id: {id}");
            var user = await _dbContext.Users.FindAsync(id); //asinhrono izvrsavanje

            if (user == null)
            {
                _logger.LogWarning($"user with id: {id} not found.");
                return NotFound();
            }

            return UserModel.FromUser(user);
        }

        /// <summary>
        /// Gets a sngle page of users.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PageList<UserModel>>> GetPage(int page = 1, int size = 5)
        {
            _logger.LogInformation($"Getting a page {page} of user with page size {size}");

            var users = await _dbContext.Users
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            var totalUsers = await _dbContext.Users.CountAsync();

            return new PageList<UserModel>
            {
                Items = users.Select(UserModel.FromUser),
                Page = page,
                PageSize = size,
                TotalCount = totalUsers
            };
        }

        [Authorize (Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (long id)
        {
            _logger.LogInformation($"Deleting user with id {id}");

            var user = await _dbContext.Users.FindAsync(id); 

            if (user == null)
            {
                _logger.LogWarning($"No user found with id {id}");
                return NotFound();
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(UserInputModel model)
        {
            _logger.LogInformation($"Creating a new user with name {model.Name}");

            var user = new Domain.User();
            model.MapTo(user);

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var resultModel = UserModel.FromUser(user);

            return CreatedAtAction(nameof(GetById), "users", new { id = user.Id }, resultModel);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update(long id, UserInputModel model)
        {
            _logger.LogInformation($"Updating user with id {id}");

            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                _logger.LogWarning($"No user found with id {id}");
                return NotFound();
            }

            model.MapTo(user);

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return UserModel.FromUser(user);
        }
    }
}