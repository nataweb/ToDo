using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly TodoContext _context;

        public ToDoController(TodoContext context)
        {
           _context = context;
        }
        //public IActionResult GetTodoItem()
        //{
        //    var context = _context.GetTodoItem();
        //    if (context == null)
        //    {
        //        return NotFound();
        //    }
            
        //    return Ok(context);
        //}
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
        
    }
}
