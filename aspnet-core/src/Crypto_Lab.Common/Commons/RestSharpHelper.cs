using RestSharp;

namespace Crypto_Lab.Common.Commons;

public class RestSharpHelper
{
    public static async Task<string> PostAsync(string url, Dictionary<string, string>? headers = null, string? json = null)
    {
        var client = new RestClient();
        var request = new RestRequest(url, Method.Post);

        if (headers != null && headers.Count > 0)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        if (json != null)
        {
            request.AddBody(json, ContentType.Json);
        }

        var response = await client.ExecutePostAsync(request);

        return response.Content!;
    }

    public static async Task<string> PutAsync(string url, Dictionary<string, string>? headers = null, string? json = null)
    {
        var client = new RestClient();
        var request = new RestRequest(url, Method.Put);

        if (headers != null && headers.Count > 0)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        if (json != null)
        {
            request.AddBody(json, ContentType.Json);
        }

        var response = await client.ExecutePutAsync(request);

        return response.Content!;
    }

    public static async Task<string> GetAsync(string url, Dictionary<string, string>? headers = null, Dictionary<string, string>? parameters = null)
    {
        var client = new RestClient();
        var request = new RestRequest(url, Method.Get);

        if (headers != null && headers.Count > 0)
        {
            foreach (var header in headers)
                request.AddHeader(header.Key, header.Value);
        }

        if (parameters != null && parameters.Count > 0)
        {
            foreach (var parameter in parameters)
                request.AddParameter(parameter.Key, parameter.Value);
        }

        try
        {
            var response = await client.ExecuteGetAsync(request);

            if (response == null || response.Content == null)
            {
                return string.Empty;
            }

            return response.Content;
        }
        catch
        {
            throw;
        }
    }
}
