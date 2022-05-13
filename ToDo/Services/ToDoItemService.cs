using Microsoft.EntityFrameworkCore;
using PracticeASP.NETCOREMVC.Models;


namespace ToDo.Services
{
    public class ToDoItemService: IToDoItemService
    {
        private readonly ApplicationDbContext dbContext;

        public ToDoItemService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ToDoItem[]> GetCompleteItemsAsync()
        {
            var items = await dbContext.items.Where(x => x.isDone == true).ToArrayAsync();
            return items;

        }
        public async Task<ToDoItem[]> GetIncompleteItemsAsync()
        {
            var items = await dbContext.items
                .Where(x => x.isDone == false)
                .ToArrayAsync();
            return items;
        }
        public async Task<bool> AddItemAsync(ToDoItem newItem)
        {
            newItem.id = Guid.NewGuid();
            newItem.isDone = false;
           // newItem.dueAt = DateTimeOffset.Now.AddDays(3);
            newItem.createdAt = DateTime.Now;

            dbContext.items.Add(newItem);

            var saveResult = await dbContext.SaveChangesAsync();
            return saveResult == 1;
        }
        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await dbContext.items
                .Where(x => x.id == id)
                .SingleOrDefaultAsync();
            item.isDone = true;

           
          
            if (item == null) return false;


            var saveResult = await dbContext.SaveChangesAsync();
            return saveResult == 1; // One entity should have been updated
        }





    }
}
