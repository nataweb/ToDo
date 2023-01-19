using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Models;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class ToDoController : Controller
    {
        private readonly TodoContext _context;

        public ToDoController(TodoContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [ActionName("GetToDoItem")]
        public async Task<IActionResult> GetToDoItem()
        {
           var todoItems = new List<TodoItem>()
            {
                new ToDoItem
                {
                  Id = 1,
                  Name = "WebAPI",
                  IsComplete = true

                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "C#",
                    IsComplete = true

                },
                new ToDoItem
                {
                  Id = 1,
                  Name = "Javascript",
                  IsComplete = true

                },

           };
           return Ok(todoItems);

        }
        [HttpPost]
        public async Task<IActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
           _context.SaveChangesAsync();

            //    return CreatedAtAction("GetToDoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = todoItem.Id }, todoItem);
        }
        
    }
}
