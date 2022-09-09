using Newtonsoft.Json.Linq;
using OBSWebSocket5.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OBSWebSocket5.Request
{
    public class FiltersRequests : RequestsBase
    {
        public FiltersRequests(OBSWebSocket.MessageDispatcher dispatcher) : base(dispatcher)
        {
        }

        public class GetSourceFilterListResponse : ResponsesBase
        {
            public JObject[] Filters { get; set; }
        }
        public Task<GetSourceFilterListResponse> GetSourceFilterListAsync(string sourceName) => 
            MakeCallAsync<GetSourceFilterListResponse>(new { sourceName });

        public class GetSourceFilterDefaultSettingsResponse : ResponsesBase
        {
            public JObject DefaultFilterSettings { get; set; }
        }
        public Task<GetSourceFilterDefaultSettingsResponse> GetSourceFilterDefaultSettings(string filterKind) => 
            MakeCallAsync<GetSourceFilterDefaultSettingsResponse>(new { filterKind });

        public Task CreateSourceFilterAsync(string sourceName, 
                                            string filterName, 
                                            string filterKind, 
                                            object filterSettings = null) => 
            MakeCallAsync(new
            {
                sourceName,
                filterName,
                filterKind,
                filterSettings
            });

        public Task RemoveSourceFilterAsync(string sourceName, string filterName) => 
            MakeCallAsync(new { sourceName, filterName });

        public Task SetSourceFilterNameAsync(string sourceName, string filterName, string newFilterName) => 
            MakeCallAsync(new { sourceName, filterName, newFilterName});

        public class GetSourceFilterResponse : ResponsesBase
        {
            public bool FilterEnabled { get; set; }
            public int FilterIndex { get; set; }
            public string FilterKind { get; set; }
            public JObject FilterSettings { get; set; }
        }
        public Task<GetSourceFilterResponse> GetSourceFilterAsync(string sourceName, string filterName) => 
            MakeCallAsync<GetSourceFilterResponse>(new { sourceName, filterName });

        public Task SetSourceFilterAsync(string sourceName, string filterName, int filterIndex) => 
            MakeCallAsync(new { sourceName, filterName, filterIndex });

        public Task SetSourceFilterSettingsAsync(string sourceName,
                                                 string filterName,
                                                 object filterSettings,
                                                 bool? overlay = null) =>
            MakeCallAsync(new
            {
                sourceName,
                filterName,
                filterSettings,
                overlay
            });

        public Task SetSourceFilterEnabledAsync(string sourceName, string filterName, bool filterEnabled) => 
            MakeCallAsync(new { sourceName, filterName, filterEnabled});
    }
}
