using System.Net;
using System.Text.Json.Serialization;

namespace teste_abacate_pay.Models
{
    public class ResponseApi
    {
        [JsonPropertyName("data")]
        public Response Response { get; set; }
        [JsonPropertyName("error")]
        public string error { get; set; }
        [JsonPropertyName("code")]
        public string code { get; set; }
        [JsonPropertyName("statusCode")]
        public HttpStatusCode statusCode { get; set; }
        [JsonPropertyName("message")]
        public string message { get; set; }
    }

    public class Response
    {
        public string id { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public bool devMode { get; set; }
        public string brCode { get; set; }
        public string brCodeBase64 { get; set; }
        public decimal platformFee { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime expiresAt { get; set; }
    }

    public class ErrorHandler
    { 
        
    }

}
