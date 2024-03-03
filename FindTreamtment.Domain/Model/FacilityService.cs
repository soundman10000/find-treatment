/*
* Find Treatment
*/

namespace FindTreatment.Domain.Model;

public readonly record struct FacilityService(string Code, string Name, string? Description)
{
    public override string ToString() => $"{this.Name} ({this.Code}) : {this.Description}";
};
