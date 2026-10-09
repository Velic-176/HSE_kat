using HSE_kat.Domain.Interfaces;
namespace HSE_kat.Domain.Entities;


public class Park
{
    private List<IInventoryItem> Items;
    private HashSet<string> InventoryNumbers;

    Park()
    {
        Items = [];
        InventoryNumbers = [];
    }

    int Add(IInventoryItem item)
    {
        if (item is null) return 0; //проверка на существование
        if (!InventoryNumbers.Add(item.InventoryNumber)) return 0; //проверка на уникальность номера

        Items.Add(item);
        return 1;
    }

    List<IInventoryItem> GetAll()
    {
        return Items;
    }

    // List<IInventoryItem> GetVehicles()
    // {
    //     List<IInventoryItem> vehicles = [];
    //     foreach(IInventoryItem item in Items)
    //     {
    //         if (item is IVehicle) vehicles.Add(item);
    //     }
    //     return vehicles;
    // }
    List<IInventoryItem> GetOfType<T>() where T : IInventoryItem
    {
        List<IInventoryItem> items = [];
        foreach(IInventoryItem item in Items)
        {
            if (item is T) items.Add(item);
        }
        return items;
    }

    List<IInventoryItem> GetAllExeptType<T>() where T : IInventoryItem
    {
        List<IInventoryItem> items = [];
        foreach(IInventoryItem item in Items)
        {
            if (item is not T) items.Add(item);
        }
        return items;
    }


}