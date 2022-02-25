using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Mapper;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controller
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository repository;

        public ItemController(IItemRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItems()
        {
            var items = (await repository.GetItemsAsync())
            .Select(item => item.ConvertItem());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(Guid id)
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return  NotFound();
            }

            return item.ConvertItem();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(CreateItemDto itemDto)
        {
            Item item =
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    CreateDate = DateTimeOffset.UtcNow
                };
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.ConvertItem());
        }

        [HttpPut]
        public async Task<ActionResult<ItemDto>> UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
          
            Item updateItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
           await repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<ItemDto>> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            await repository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
