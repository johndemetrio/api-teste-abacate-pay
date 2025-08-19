namespace teste_abacate_pay.Models
{
    public class RequestApi
    {
        public decimal amount { get; set; }
        public int expiresIn { get; set; }
        public string description { get; set; }
        public Customer customer { get; set; }
    }
}
