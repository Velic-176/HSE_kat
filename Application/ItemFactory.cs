using HSE_kat.Domain.Interfaces;
using HSE_kat.Domain.Entities;
using HSE_kat.Domain.Results;

namespace HSE_kat.Application;

public class ItemFactory
{
    private readonly Dictionary<string, Func<string, string, int, int, double, IInventoryItem>> Creators;

    public ItemFactory()
    {
        Creators = new Dictionary<string, Func<
            string, string, int, int, double, IInventoryItem>>
        {
            ["scooter"] = (name, number, friendliness, workingCapacity, energy) =>
                new Scooter(name, number, friendliness, workingCapacity),

            // ["helmet"] = (name, number, friendliness, workingCapacity, energy) =>
            //     new Helmet(name, number),

            // ["cabinet"] = (name, number, friendliness, workingCapacity, energy) =>
            //     new ChargingCabinet(name, number, energy)
        };
    }

    public CreateResult Create(
        ref IInventoryItem buff,
        string type,
        string name,
        string number,
        int friendliness = 0,
        int workingCapacity = 100,
        double energy = 0)
    {
        if (!Creators.TryGetValue(type, out var creator))
            return CreateResult.InvalidType;

        buff = creator(name, number, friendliness, workingCapacity, energy);
        return CreateResult.Success;
    }
}