using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LmycWeb.Data;
using LmycWeb.Models;

namespace LmycWeb.Controllers
{
    public class RolesModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RolesModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RolesModel.ToListAsync());
        }

        // GET: RolesModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.RolesModel
                .SingleOrDefaultAsync(m => m.RoleId == id);
            if (rolesModel == null)
            {
                return NotFound();
            }

            return View(rolesModel);
        }

        // GET: RolesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RolesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,UserId")] RolesModel rolesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rolesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rolesModel);
        }

        // GET: RolesModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.RolesModel.SingleOrDefaultAsync(m => m.RoleId == id);
            if (rolesModel == null)
            {
                return NotFound();
            }
            return View(rolesModel);
        }

        // POST: RolesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RoleId,RoleName,UserId")] RolesModel rolesModel)
        {
            if (id != rolesModel.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolesModelExists(rolesModel.RoleId))
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
            return View(rolesModel);
        }

        // GET: RolesModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolesModel = await _context.RolesModel
                .SingleOrDefaultAsync(m => m.RoleId == id);
            if (rolesModel == null)
            {
                return NotFound();
            }

            return View(rolesModel);
        }

        // POST: RolesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rolesModel = await _context.RolesModel.SingleOrDefaultAsync(m => m.RoleId == id);
            _context.RolesModel.Remove(rolesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolesModelExists(string id)
        {
            return _context.RolesModel.Any(e => e.RoleId == id);
        }
    }
}
