namespace HSE_kat.Domain.Results;

public enum AddResult
{
    Success,
    InvalidData,
    InvalidInventoryNumber,
    InspectationFailed
}

public enum ChangeResult
{
    Success,
    InvalidData
}

public enum CreateResult
{
    Success,
    InvalidType,
    WrongType
}