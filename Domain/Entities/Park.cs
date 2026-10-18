using HSE_kat.Domain.Interfaces;
using HSE_kat.Domain.Results;
namespace HSE_kat.Domain.Entities;

// хранит информацию о всём инвентаре
public class Park
{
    private List<IInventoryItem> Items;
    private HashSet<string> InventoryNumbers;

    public Park()
    {
        Items = [];
        InventoryNumbers = [];
    }

    public AddResult Add(IInventoryItem item)
    {
        if (item is null) return AddResult.InvalidData; //проверка на существование
        if (!InventoryNumbers.Add(item.InventoryNumber)) return AddResult.InvalidInventoryNumber; //проверка на уникальность номера

        Items.Add(item);
        return AddResult.Success;
    }

    public List<IInventoryItem> GetAll()
    {
        return Items;
    }

    public List<IInventoryItem> GetOfType<T>() where T : IInventoryItem
    {
        List<IInventoryItem> items = [];
        foreach(IInventoryItem item in Items)
        {
            if (item is T) items.Add(item);
        }
        return items;
    }

    public List<IInventoryItem> GetAllExeptType<T>() where T : IInventoryItem
    {
        List<IInventoryItem> items = [];
        foreach(IInventoryItem item in Items)
        {
            if (item is not T) items.Add(item);
        }
        return items;
    }


}