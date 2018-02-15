using System.Collections.Generic;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExpInnerOrdDto
    {
        public string Customer { get; set; }

        public List<ExpInnerItemDto> Items { get; set; } = new List<ExpInnerItemDto>();

        public decimal TotalPrice { get; set; }
    }
}
