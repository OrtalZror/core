using  שיעור_2.Models;
using System.Collections.Generic;
using System.Linq;

namespace שיעור_2.Controllers
{
    public class ItemService
    {
        private static List<Item> items =new List<Item>
        {
            new Item{Id=1,Description="to do hw in Java",IsDone=false},
            new Item{Id=2,Description="to bake a cake",IsDone=true},
            new Item{Id=3,Description="to do shopping",IsDone=false},
            new Item{Id=2,Description="to sleep",IsDone=false}
        };
       public static List<Item> GetAll() => items;
        public static Item Get(int id)
        {
            return items.FirstOrDefault(t => t.Id == id);
        }

        public static void Add(Item item)
        {
            item.Id = items.Max(t => t.Id) + 1;
            items.Add(item);
        }

        public static bool Update(int id, Item newItem)
        {
            if (newItem.Id != id)
                return false;
            
            var item = items.FirstOrDefault(p => p.Id == id);
            item.Description = newItem.Description;
            item.IsDone = newItem.IsDone;
            return true;
        }

        public static bool Delete(int id)
        {
            var item = items.FirstOrDefault(t => t.Id == id);
            if (item == null)
                return false;
            items.Remove(item);
            return true;
        }
    }
}