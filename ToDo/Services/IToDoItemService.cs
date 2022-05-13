using PracticeASP.NETCOREMVC.Models;

namespace ToDo.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItem[]> GetIncompleteItemsAsync();

        Task<bool> AddItemAsync(ToDoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);

        Task<ToDoItem[]> GetCompleteItemsAsync();



          

    }

}
