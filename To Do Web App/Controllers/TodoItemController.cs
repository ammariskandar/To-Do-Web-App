using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using AutoMapper;

namespace mvc.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly UserManager<WebAppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodoItemController(
            UserManager<WebAppUser> userManager,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        // GET: TodoItem
        public async Task<IActionResult> Index()
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);

            var todoItems = CurrentUser.TodoItems.ToList();
            if(todoItems == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<List<TodoItem>, List<TodoViewModel>>(todoItems));
        }

        // GET: TodoItem/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);

            if (id == null)
            {
                return NotFound();
            }

            var todoItem = CurrentUser.TodoItems.Single(t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<TodoViewModel>(todoItem));
        }

        // GET: TodoItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoItem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsComplete")] TodoViewModel todoItemVM)
        {
            if (ModelState.IsValid)
            {
                var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);
                
                TodoItem todoItem = _mapper.Map<TodoItem>(todoItemVM);

                CurrentUser.TodoItems.Add(todoItem);
                await _userManager.UpdateAsync(CurrentUser);
                return RedirectToAction(nameof(Index));
            }
            return View(todoItemVM);
        }

        // GET: TodoItem/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = CurrentUser.TodoItems.Single(t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<TodoViewModel>(todoItem));
        }

        // POST: TodoItem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,IsComplete")] TodoViewModel todoItemVM)
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);
            
            if (id != todoItemVM.Id)
            {
                return NotFound();
            }
            
            TodoItem todoItem = CurrentUser.TodoItems.Single(t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    todoItem.Name = todoItemVM.Name;
                    todoItem.IsComplete = todoItemVM.IsComplete;

                    _context.Entry(todoItem).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemExists(todoItem.Id))
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
            
            return View(_mapper.Map<TodoViewModel>(todoItem));
        }

        // GET: TodoItem/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);
            if (id == null)
            {
                return NotFound();
            }

            var todoItem = CurrentUser.TodoItems.Single(t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }
            
            return View(_mapper.Map<TodoViewModel>(todoItem));
        }

        // POST: TodoItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var CurrentUser = await _userManager.Users
                                                .Include(u => u.TodoItems)
                                                .SingleAsync(u => u.Id == CurrentUserId);

            var todoItem = CurrentUser.TodoItems.Single(t => t.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            CurrentUser.TodoItems.Remove(todoItem);
            await _userManager.UpdateAsync(CurrentUser);

            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
