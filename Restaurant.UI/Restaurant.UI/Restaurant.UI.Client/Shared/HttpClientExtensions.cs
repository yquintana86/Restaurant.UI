using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Runtime.Intrinsics;
using System.Text;

namespace Restaurant.UI.Client.Shared;

[Authorize]
public static class HttpClientExtensions
{
    public static readonly string _apiBaseURL; 
    public static readonly string _header;
    public static readonly string _apiKey;
    static HttpClientExtensions()
    {
        var conf = ConfigurationHelperService.StaticConfig;
        _apiBaseURL = conf.GetSection("ApiBaseSettings")["ApiBaseUrl"] ?? "";
        _header = conf.GetSection("ApiBaseSettings")["Header"] ?? "";
        _apiKey = conf.GetSection("ApiBaseSettings")["ApiKey"] ?? "";

        if (string.IsNullOrWhiteSpace(_apiBaseURL))
            ArgumentException.ThrowIfNullOrWhiteSpace(nameof(_apiBaseURL));
    }
    
    public static void SetAuthentication(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add(_header, _apiKey);
    }

    public static async Task<T?> GetJsonNewtonAsync<T>(this HttpClient httpClient, string url)
    {
        SetAuthentication(httpClient);

        var finalUrl = url.Contains("http") ? url : $"{_apiBaseURL}{url}";

        var stringContent = await httpClient.GetStringAsync(finalUrl);

        var result = JsonConvert.DeserializeObject<T>(stringContent);

        return result;
    }

    public static async Task<T?> PostJsonNewtonAsync<T>(this HttpClient httpClient, string uri, object content)
        => await httpClient.SendNewtonAsync<T>(HttpMethod.Post, uri, content);

    public static async Task<T?> PutJsonNewtonAsync<T>(this HttpClient httpClient, string url, object content)
        => await httpClient.SendNewtonAsync<T>(HttpMethod.Put, url, content);

    public static async Task<T?> DeleteJsonNewtonAsync<T>(this HttpClient httpClient, string url)
        => await httpClient.SendNewtonAsync<T>(HttpMethod.Delete, url, null);

    public static async Task<T?> SendNewtonAsync<T>(this HttpClient httpClient, HttpMethod method, string uri, object content)
    {
        var responseStringContent = string.Empty;
        try
        {
            SetAuthentication(httpClient);

        var contentSerializable = JsonConvert.SerializeObject(content);
        var finalUrl = uri.Contains("http") ? uri : $"{_apiBaseURL}{uri}";

        var response = await httpClient.SendAsync(new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri(finalUrl),
            Content = new StringContent(contentSerializable, Encoding.UTF8, "application/json")
        });

        if (response is null)
            throw new Exception("An error has happened");

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            throw new Exception("Unauthorized Access");        

        

        
            responseStringContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseStringContent);
        }
        catch
        {
            throw new Exception(responseStringContent);
        }
    }
}






