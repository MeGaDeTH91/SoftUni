using System.Collections.Generic;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ExportOrdersDto
    {
        public string Name { get; set; }

        public List<ExpInnerOrdDto> Orders { get; set; } = new List<ExpInnerOrdDto>();

        public decimal TotalMade { get; set; }
    }
}
