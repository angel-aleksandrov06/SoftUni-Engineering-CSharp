namespace ProductShop.DTO.User
{
    using Newtonsoft.Json;

    public class UserSoldProductDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFistName")]
        public string FirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string LastName { get; set; }
    }
}
