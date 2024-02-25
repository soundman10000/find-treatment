/*
* Find Treatment
*/

namespace FindTreatment.Domain;

public static class CovStateCodeLookup
{
    private static readonly IReadOnlyDictionary<string, int> StateCodeLookup =
        new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase)
        {
            { "AL", 19 },
            { "AK", 20 },
            { "AZ", 21 },
            { "AR", 22 },
            { "CA", 23 },
            { "CO", 24 },
            { "CT", 25 },
            { "DE", 26 },
            { "DC", 27 },
            { "FL", 28 },
            { "GA", 29 },
            { "HI", 30 },
            { "ID", 31 },
            { "IL", 32 },
            { "IN", 33 },
            { "IA", 34 },
            { "KS", 35 },
            { "KY", 36 },
            { "LA", 37 },
            { "ME", 1 },
            { "MD", 18 },
            { "MA", 3 },
            { "MI", 2 },
            { "MN", 38 },
            { "MS", 39 },
            { "MO", 40 },
            { "MT", 4 },
            { "NE", 41 },
            { "NV", 12 },
            { "NH", 42 },
            { "NJ", 13 },
            { "NM", 43 },
            { "NY", 5 },
            { "NC", 6 },
            { "ND", 44 },
            { "OH", 7 },
            { "OK", 45 },
            { "OR", 46 },
            { "PA", 8 },
            { "RI", 9 },
            { "SC", 47 },
            { "SD", 48 },
            { "TN", 10 },
            { "TX", 11 },
            { "UT", 14 },
            { "VT", 49 },
            { "VA", 50 },
            { "WA", 15 },
            { "WV", 51 },
            { "WI", 16 },
            { "WY", 52 }
        };

    public static int GetGovFacilityStateCode(string stateCode)
    {
        if (!StateCodeLookup.TryGetValue(stateCode, out var code))
        {
            throw new Exception($"Invalid State Code : {stateCode}");
        }

        return code;
    }
}