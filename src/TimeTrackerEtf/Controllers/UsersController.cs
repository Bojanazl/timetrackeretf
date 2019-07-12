using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimeTrackerEtf.Data;
using TimeTrackerEtf.Models;

namespace TimeTrackerEtf.Controllers
{

    [ApiController]
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
    }
}