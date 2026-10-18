using HSE_kat.Domain.Interfaces;
namespace HSE_kat.Domain.Entities;

public abstract class BasicVehicle : IVehicle
{
    public string Name {get;}
    public string InventoryNumber {get;}
    public int BeginnerFriendliness {get;}
    public int WorkingCapacity {get; }
    // Базовый класс - чтобы в одном месте была реализация общих полей для всего транспорта. 
    // Интерфейс - для абстракции.
    protected BasicVehicle(string name, string inventory_number, int friendliness, int workingCapacity)
    {
        Name = name;
        InventoryNumber = inventory_number;
        BeginnerFriendliness = friendliness;
        WorkingCapacity = workingCapacity;
    }
}

// самокат
public class Scooter : BasicVehicle
{
    public Scooter(string name, string inventoryNumber, int friendliness, int workingCapacity)
        : base(name, inventoryNumber, friendliness, workingCapacity)
    {
    }
}

// электросамокат
public class ElecticScooter : BasicVehicle, IEnergyConsumer
{
    public double DailyEnergyConsumption {get;}
    public ElecticScooter(string name, string inventoryNumber, int friendliness, int workingCapacity, double dailyEnergyConsumption)
        : base(name, inventoryNumber, friendliness, workingCapacity)
    {
        DailyEnergyConsumption = dailyEnergyConsumption;
    }
}