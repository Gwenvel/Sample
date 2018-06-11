using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test2.Models;

namespace test2.Controllers
{
    [Authorize]
    public class RequestController : Controller
    {
        private readonly RequestContext _context;
        private readonly UserManager<IdentityUser> _manager;

        public RequestController(RequestContext context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }



        // GET: Request
        public async Task<IActionResult> Index()
        {
            var user = this.User.Identity.Name;

            if (user.Contains("admin"))
            {
                return View(await _context.Request.ToListAsync());

            }
            else
            {

                return View(await _context.Request.Where(x => x.User == user).ToListAsync());
            }
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create()
        {


            if (!this.User.Identity.Name.Contains("admin"))
            {
                var depts = new SelectList(_context.Departments.ToList().Where(x => x.Department != "IT"), "DepartmentsId", "Department");
                ViewBag.departments = depts;
                return View();
            }
            else
            {
                var other = new SelectList(_context.Departments.ToList().Where(x => x.Department == "IT"), "DepartmentsId", "Department");
                ViewBag.departments = other;
                return View();
            }


        }

        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestId,WorkRequest,Department")] Request request)
        {

            var depts = _context.Departments.ToList();

            if (ModelState.IsValid)
            {
                foreach (var item in depts)
                {
                    if (request.Department == item.DepartmentsId.ToString())
                    {
                        request.Department = item.Department;
                    }

                }
                if (request.Department == "IT")
                {
                    request.User = this.User.Identity.Name;
                    request.Urgent = true;
                    request.Pending = true;
                    request.InProgress = false;
                    request.Closed = false;
                    request.Created = DateTime.Now;
                }
                else
                {
                    request.User = this.User.Identity.Name;
                    request.Urgent = false;
                    request.Pending = true;
                    request.InProgress = false;
                    request.Closed = false;
                    request.Created = DateTime.Now;
                }
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,User,WorkRequest,Department,Urgent,Pending,InProgress,Closed")] Request request)
        {
            if (id != request.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(this.User.Identity.Name.Contains("admin"))
                {
                    ViewBag.checker = "Admin";
                }
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestId))
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
            return View(request);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.RequestId == id);
        }
    }
}
