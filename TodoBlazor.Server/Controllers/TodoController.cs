using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoBlazor.Core.Models;
using TodoBlazor.Data;

namespace TodoBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpPost]
        public async Task<TodoItem> CreateToDoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        [HttpPut]
        public async Task<TodoItem> UpdateToDoItem(TodoItem item)
        {
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}