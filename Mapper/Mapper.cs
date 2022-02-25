using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Mapper
{

  public static class Mapper
  {

    public static ItemDto ConvertItem(this Item item)
    {
      return new ItemDto()
      {
        Id = item.Id,
        Name = item.Name,
        Price = item.Price,
        CreateDate = item.CreateDate
      };

    }
  }
}
