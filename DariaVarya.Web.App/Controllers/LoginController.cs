using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DariaVarya.Web.App.Models;
using DariaVarya.Web.App.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace DariaVarya.Web.App.Controllers
{
    public class LoginController : Controller
    {
        private readonly DariaVaryaWebAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(DariaVaryaWebAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.User.Where(x => x.Username == model.Username).FirstOrDefault();

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Username or Password.");
                }
                else if (model.Username == user.Username && model.Password == user.Password)
                {
                    var userProfile = _context.UserProfiles.Where(x => x.Username == model.Username).FirstOrDefault();
                    //HttpContext.Session.SetString("UserName", userProfile.Username);
                    //HttpContext.Session.SetString("Name", userProfile.Name);
                    //HttpContext.Session.SetString("UserRole", userProfile.Role); 
                    //HttpContext.Session.SetString("DeparmentId", userProfile.DepartmentId.ToString()); 
                    //HttpContext.Session.SetString("DeparmentName", userProfile.DepartmentName);

                    var identity = new ClaimsIdentity(new List<Claim>
                    {
                      new Claim("UserName",userProfile.Username, ClaimValueTypes.String),
                      new Claim("Name", userProfile.Name, ClaimValueTypes.String),
                      new Claim("UserRole", userProfile.Role, ClaimValueTypes.String),
                      new Claim("DeparmentId", userProfile.DepartmentId.ToString(), ClaimValueTypes.String)
                    }, "Custom");

                    var claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    // Redirect to a success page or dashboard
                    return RedirectToAction("Index", "ChangeControls");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            HttpContext.SignOutAsync();

            // Redirect to login page after logout
            return RedirectToAction("Index", "Login");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Password")] UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.User.FindAsync(id);
            if (userModel != null)
            {
                _context.User.Remove(userModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
