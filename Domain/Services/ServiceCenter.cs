using HSE_kat.Domain.Entities;
using HSE_kat.Domain.Interfaces;
using HSE_kat.Domain.Results;

namespace HSE_kat.Domain.Services;

// Принимает решение о приёме/неприёме устройства(!) в парк
public class ServiceCenter : IServiceCenter
{
    public int Criteria;
    private readonly Park ParkOfItems;

    ServiceCenter(Park park, int criteria)
    {
        ParkOfItems = park;
        Criteria = criteria;
    }

    int CheckCriteria(int criteria)
    {
        if (criteria >= Criteria) return 1;
        return 0;
    }

    public int setCriteria(int value)
    {
        if (value <= 100 && value >= 1)
        {
            Criteria = value;
            return 1;
        }
        return 0;
    }

    public int getCriteria()
    {
        return Criteria;
    }

    public AddResult Add(IInventoryItem item)
    {
        if (CheckCriteria(item.WorkingCapacity) == 0) return AddResult.InspectationFailed;

        AddResult res = ParkOfItems.Add(item);
        return res;
    }
}