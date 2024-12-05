namespace EmpApplication.Models
{
    public class OrderRequest
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
