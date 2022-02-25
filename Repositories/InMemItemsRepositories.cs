

using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{

  public class InMemItemsRepositories //: IItemRepository
  {
    private readonly List<Item> items = new()
    {
      new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreateDate = DateTimeOffset.UtcNow },
      new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreateDate = DateTimeOffset.UtcNow },
      new Item() { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreateDate = DateTimeOffset.UtcNow }
    };
    public IEnumerable<Item> GetItemsAysnc()
    {
      return items;
    }
    public Item GetItemAsync(Guid id)
    {
      return items.Where(item => item.Id == id).SingleOrDefault();
    }

    public void CreateItemAsync(Item item)
    {
      items.Add(item);
    }

    public void UpdateItemAsync(Item item)
    {
      var index=items.FindIndex(existItem=>existItem.Id==item.Id);
      items[index]=item;
    }

    public void DeleteItemAsync(Guid id)
    {
       var index=items.FindIndex(existItem=>existItem.Id==id);
      items.RemoveAt(index);
    }
  }
}