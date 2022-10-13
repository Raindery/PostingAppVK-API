using Newtonsoft.Json;

namespace VKApiService
{
    public sealed class VkApiResponse : VkApiResponse<Dictionary<string, object>>
    {
        public VkApiResponse(VkApiResponse<Dictionary<string, object>> response)
        {
            ResponseData = response.ResponseData;
            ErrorData = response.ErrorData;
        }
    }

    public class VkApiResponse<T>
    {
        [JsonProperty("response")]
        public T? ResponseData { get; protected set; }
        [JsonProperty("error")]
        public Dictionary<string, object>? ErrorData { get; protected set; }
    }
}
