using TddFromTheScratch.Business;

namespace TddFromTheScratchWeb.Models.Mappers
{
    public class ProcessFileResultMapper
    {
        public ProcessResultModel Map(ProcessFileResult processFileResult)
        {
            return new ProcessResultModel
            {
                FileNumber = processFileResult.FileNumber,
                Items = processFileResult.Items.ConvertAll(x => MapItem(x))
            };
        }

        public ProcessResultItemModel MapItem(ProcessResultItem processResultItem)
        {
            return new ProcessResultItemModel
            {
                ClientName = processResultItem.ClientName,
                ProductCode = processResultItem.ProductCode,
                ProductDescription = processResultItem.ProductDescription,
                ProductPrice = processResultItem.ProductPrice,
                ProductQuantity = processResultItem.ProductQuantity,
                SellerCode = processResultItem.SellerCode,
                Subsidiary = processResultItem.Subsidiary,
                Total = processResultItem.Total
            };
        }
    }
}
