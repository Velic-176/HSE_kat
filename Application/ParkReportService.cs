using HSE_kat.Domain.Entities;
using HSE_kat.Domain.Interfaces;

namespace HSE_kat.Application;

// возвращает пользователю информацию о парке
public class ParkReportService
{
    public Park ParkOfItems {get; set;}

    public ParkReportService(Park park)
    {
        ParkOfItems = park;
    }

    void ConsolePrintAll()
    {
        List<IInventoryItem> items = ParkOfItems.GetOfType<IInventoryItem>();
        ConsolePrint(items);
    }

    void ConsolePrintVehicles()
    {
        List<IInventoryItem> items = ParkOfItems.GetOfType<IVehicle>();
        ConsolePrint(items);
    }

    void ConsolePrintNonVehicles()
    {
        List<IInventoryItem> items = ParkOfItems.GetAllExeptType<IVehicle>();
        ConsolePrint(items);
    }

    void ConsolePrintEnergyConsumers()
    {
        List<IInventoryItem> items = ParkOfItems.GetAllExeptType<IVehicle>();
        ConsolePrint(items);
    }

    void ConsolePrintBeginnerFriendly()
    {
        List<IInventoryItem> items = ParkOfItems.GetOfType<IVehicle>();
        items.RemoveAll(item => item is IVehicle vehicle && vehicle.BeginnerFriendliness < 6);
        ConsolePrint(items);
    }

void ConsolePrint(List<IInventoryItem> items)
    {
        double energyTotal = 0;

        Console.WriteLine("Информация о парке:\nНазвание;\tНомер;\tСостояние;\tПростота;\tПотребление энергии");
        foreach (var item in items)
        {
            Console.Write($"{item.Name}  {item.InventoryNumber}  {item.WorkingCapacity}  ");
            if (item is IVehicle vehicle) Console.Write($"{vehicle.BeginnerFriendliness}  ");
            else Console.Write("--\t");
            if (item is IEnergyConsumer consumer) 
            {
                Console.Write($"{consumer.DailyEnergyConsumption}\n");
                energyTotal += consumer.DailyEnergyConsumption;
            }
            else Console.Write("--\n");
        }
        Console.WriteLine($"\nОбщее потребление энергии: {energyTotal}");
    }
}

