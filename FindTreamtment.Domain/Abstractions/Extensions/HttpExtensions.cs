/*
* Find Treatment
*/

using Newtonsoft.Json;
using static System.Web.HttpUtility;

namespace FindTreatment.Domain;

internal static class HttpExtensions
{
    public static async Task<T?> ReadAndDeserializeResponse<T>(
        this HttpResponseMessage input,
        JsonSerializerSettings settings)
    {
        try
        {
            return await input.Content
                .ReadAsStringAsync()
                .Map(res => JsonConvert.DeserializeObject<T>(res, settings));
        }
        catch (Exception e)
        {
            throw new Exception("Was unable to parse the response", e);
        }
    }

    public static string ToQueryString(this object obj) =>
        obj
            .GetType()
            .GetProperties()
            .Where(p => p.GetValue(obj, null) != null)
            .Select(p => $"{p.Name}={UrlEncode(p.GetValue(obj, null)?.ToString())}")
            .ToArray()
            .Apply(x => string.Join("&", x))
            .Apply(z => $"?{z}");
}