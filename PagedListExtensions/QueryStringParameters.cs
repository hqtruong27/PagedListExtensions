using System;
using System.Text.Json.Serialization;

namespace PagedListExtensions
{
    public abstract class QueryStringParameters
    {
        private const int maxPageSize = 20;
        private int _pageSize = 10;
        private string _query = default;

        [JsonPropertyName("q")]
        public string Query { get => _query; set => _query = string.IsNullOrWhiteSpace(value) ? null : value; }
        public int PageSize { get => _pageSize; set => _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        public int PageNumber { get; set; } = 1;
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
