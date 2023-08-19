using Amazon.Lambda.Core;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaSimpleSample;

public class Function
{

    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">https://stackoverflow.com/questions/50322362/pass-json-string-to-aws-lambda-in-step-function-jsonreaderexception-error</param>
    /// <param name="context"></param>
    /// <returns></returns>
    public LambdaResponse FunctionHandler(object input, ILambdaContext context)
    {
        var body = new Dictionary<string, string>()
        {
            {"message", "Hello, World!" },
        };

        var response = new LambdaResponse()
        {
            isBase64Encoded = false,
            statusCode = HttpStatusCode.OK,
            headers = new Dictionary<string, string>()
            {
                {"my_header", "my_value" }
            },
            body = JsonConvert.SerializeObject(body),
        };
        return response;
    }
}

/// <summary>
/// 
/// </summary>
public class LambdaResponse
{
    [JsonProperty(PropertyName = "isBase64Encoded")]
    public bool isBase64Encoded;

    [JsonProperty(PropertyName = "statusCode")]
    public HttpStatusCode statusCode;

    [JsonProperty(PropertyName = "headers")]
    public Dictionary<string, string>? headers;

    [JsonProperty(PropertyName = "body")]
    public string? body;
}