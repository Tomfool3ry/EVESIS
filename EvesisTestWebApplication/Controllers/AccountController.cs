using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvesisTestWebApplication.Models;
using EvesisTestWebApplication.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EvesisTestWebApplication.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> UserManager;
		private readonly SignInManager<User> SignInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.UserManager = userManager;
			this.SignInManager = signInManager;
		}

		#region Registration

		[HttpGet]
		public IActionResult Register() { return View(); }

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new User
				{
					UserName = model.Email,
					Name = model.Name,
					Surname = model.Surname,
					Email = model.Email
				};

				var result = await UserManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

		#endregion

		#region Login

		[HttpGet]
		public IActionResult Login() { return View(); }

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Incorrect email or password");
			}

			return View(model);
		}

		#endregion

		#region Log out

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			await SignInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		#endregion
	}
}
