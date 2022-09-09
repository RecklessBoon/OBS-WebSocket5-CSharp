using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using OBSWebSocket5.Response;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class GeneralRequests : RequestsBase
    {
        public GeneralRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetVersionResponse : ResponsesBase
        {
            public string ObsVersion { get; set; }
            public string ObsWebSocketVersion { get; set; }
            public float RpcVersion { get; set; }
            public string[] AvailableRequests { get; set; }
            public string[] SupportedImageFormats { get; set; }
            public string Platform { get; set; }
            public string PlatformDescription { get; set; }
        }
        public Task<GetVersionResponse> GetVersionAsync() => 
            MakeCallAsync<GetVersionResponse>();

        public class GetStatsResponse : ResponsesBase
        {
            public float CpuUsage { get; set; }
            public float MemoryUsage { get; set; }
            public float AvailableSpace { get; set; }
            public float ActiveFps { get; set; }
            public float AverageFrameRenderTime { get; set; }
            public int RenderSkippedFrames { get; set; }
            public int RenderTotalFrames { get; set; }
            public int OutputSkippedFrames { get; set; }
            public int OutputTotalFrames { get; set; }
            public int WebSocketSessionIncomingMessages { get; set; }
            public int WebSocketSessionOutgoingMessages { get; set; }
        }
        public Task<GetStatsResponse> GetStatsAsync() => 
            MakeCallAsync<GetStatsResponse>();

        public Task BroadcastCustomEventAsync(object eventData) => 
            MakeCallAsync(new { eventData });

        public class CallVendorResponse : ResponsesBase
        {
            public string VendorName { get; set; }
            public string RequestType { get; set; }
            public JObject RequestData { get; set; }
        }
        public Task<CallVendorResponse> CallVendorRequestAsync(string vendorName, string requestType, object requestData = null) => 
            MakeCallAsync<CallVendorResponse>(new { vendorName, requestType, requestData });

        public class GetHotkeyListResponse : ResponsesBase
        {
            public string[] Hotkeys { get; set; }
        }
        public Task<GetHotkeyListResponse> GetHotkeyListAsync() => 
            MakeCallAsync<GetHotkeyListResponse>();

        public Task TriggerHotkeyByNameAsync(string hotkeyName) => 
            MakeCallAsync(new { hotkeyName });

        [JsonObject(
            NamingStrategyType = typeof(CamelCaseNamingStrategy),
            ItemNullValueHandling = NullValueHandling.Ignore
        )]
        public class KeyModifiers
        {
            public bool Shift { get; set; } = false;
            public bool Control { get; set; } = false;
            public bool Alt { get; set; } = false;
            public bool Command { get; set; } = false;
        }
        public Task TriggerHotkeyByKeySequenceAsync(string keyId = null, KeyModifiers keyModifiers = null) => 
            MakeCallAsync(new { keyId, keyModifiers });

        public Task SleepAsync(int sleepMillis = 0, int sleepFrames = 0) => 
            MakeCallAsync(new { sleepMillis, sleepFrames });
    }
}
