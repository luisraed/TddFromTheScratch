namespace TddFromTheScratchWeb.Models
{
    public class ProcessResultItemModel
    {
        public string Subsidiary { get; set; }
        public string SellerCode { get; set; }
        public string ClientName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Total { get; set; }
    }
}
