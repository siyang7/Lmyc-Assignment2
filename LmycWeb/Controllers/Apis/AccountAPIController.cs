using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LmycWeb.Data;
using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using LmycWeb.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using LmycWeb.Models.AccountViewModels;

namespace LmycWeb.Controllers.Apis
{
    [Produces("application/json")]
    [Route("api/AccountAPI")]
    public class AccountAPIController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AccountAPIController(
            UserManager<ApplicationUser> userManager,
            IEmailSender emailSender,
            ILogger<AccountAPIController> logger)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        // POST api/AccountAPI/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Street = model.Street,
                City = model.City,
                Province = model.Province,
                PostalCode = model.PostalCode,
                Country = model.Country,
                MobilePhone = model.MobileNumber,
                SailingExperience = model.SailingExperience
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            _logger.LogInformation("User created a new account with password.");
            await _userManager.AddToRoleAsync(user, "Member");

            return Ok();
        }
    }
}