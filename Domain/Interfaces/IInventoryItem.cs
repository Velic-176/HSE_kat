namespace HSE_kat.Domain.Interfaces;

public interface IInventoryItem
{
    string InventoryNumber { get; }
    string Name { get; }
    int WorkingCapacity {get; } // 0 - 100
}
