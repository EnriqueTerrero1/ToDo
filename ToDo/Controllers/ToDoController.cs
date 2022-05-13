using Microsoft.AspNetCore.Mvc;
using ToDo.Services;
using ToDo.Models;
using PracticeASP.NETCOREMVC.Models;



namespace PracticeASP.NETCOREMVC.Controllers
{
 
    public class ToDoController : Controller
    {
        private readonly IToDoItemService _todoItemService;
       

        public ToDoController(IToDoItemService toDoItemService)
        {
            _todoItemService = toDoItemService;
          

        }
        public async Task<IActionResult> Index()
        {
           
            var items = await _todoItemService.GetIncompleteItemsAsync();
            var model = new ToDoItems_Model_View
            {
                toDoItems = items
            };
            return View(model);
        }

       public async Task<IActionResult> Completed()
        {

            var items = await _todoItemService.GetCompleteItemsAsync();
            var model = new ToDoItems_Model_View
            {
                toDoItems = items
            };
            return View(model);
        }
            [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(ToDoItem newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            
            var successful = await _todoItemService.AddItemAsync(newItem);
            if (!successful)
            {
                return BadRequest("Could not add item.");
            }

            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful)
            {
                return BadRequest("Could not mark item as done.");
            }

            return RedirectToAction("Index");
        }




    }
}
