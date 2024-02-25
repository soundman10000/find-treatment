/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public enum LimitType
{
    State = 0,
    County = 1,
    Distance = 2
}

public readonly record struct Limit(LimitType Type, int Value)
{
    public Limit(string stateCode) 
        : this(LimitType.State, CovStateCodeLookup.GetGovFacilityStateCode(stateCode))
    { }
}