using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class SourcesRequests : RequestsBase
    {
        public SourcesRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetSourceActiveResponse : ResponsesBase
        {
            public bool VideoActive { get; set; }
            public bool VideoShowing { get; set; }
        }
        public Task<GetSourceActiveResponse> GetSourceActiveAsync(string sourceName) => 
            MakeCallAsync<GetSourceActiveResponse>(new { sourceName });

        public class GetSourceScreenshotResponse : ResponsesBase
        {
            public string ImageData { get; set; }
        }
        public Task<GetSourceScreenshotResponse> GetSourceScreenshotAsync(string sourceName, 
                                                                          string imageFormat, 
                                                                          int? imageWidth = null, 
                                                                          int? imageHeight = null, 
                                                                          int? imageCompressioQuality = null) => 
            MakeCallAsync<GetSourceScreenshotResponse>(new
            {
                sourceName,
                imageFormat,
                imageWidth,
                imageHeight,
                imageCompressioQuality
            });

        public class SaveSourceScreenshotResponse : ResponsesBase
        {
            public string ImageData { get; set; }
        }
        public Task<SaveSourceScreenshotResponse> SaveSourceScreenshotAsync(string sourceName, 
                                                                            string imageFormat, 
                                                                            string imageFilePath, 
                                                                            int? imageWidth = null, 
                                                                            int? imageHeight = null, 
                                                                            int? imageCompressionQuality = null) => 
            MakeCallAsync<SaveSourceScreenshotResponse>(new
            {
                sourceName,
                imageFormat,
                imageFilePath,
                imageWidth,
                imageHeight,
                imageCompressionQuality
            });
    }
}
