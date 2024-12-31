


using System.ComponentModel.DataAnnotations;

namespace DTOs.Stock
{
    public class CreateStockRequestDTO
    {
        [Required]
        [MaxLength(15, ErrorMessage = "Symbol cannot be over 15 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(15, ErrorMessage = "CompanyName cannot be over 15 characters")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}