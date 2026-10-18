using HSE_kat.Domain.Entities;
using HSE_kat.Domain.Results;

namespace HSE_kat.Domain.Interfaces;

public interface IServiceCenter
{
    // int Criteria;
    // Park ParkOfItems {get;}

    AddResult Add(IInventoryItem item);
    // int CheckCriteria(int criteria);
    public int getCriteria();
    public ChangeResult setCriteria(int value);
}