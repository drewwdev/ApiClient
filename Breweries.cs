using System;
using System.Text.Json.Serialization;

namespace ApiClient
{
    public class Breweries
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("brewery_type")]
        public string BreweryType { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("address_2")]
        public string SecondAddress { get; set; }
        [JsonPropertyName("address_3")]
        public string ThirdAddress { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("county_province")]
        public string CountyProvince { get; set; }
        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("website_url")]
        public string WebsiteUrl { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}