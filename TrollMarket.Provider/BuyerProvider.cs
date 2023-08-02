using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Repository;
using TrollMarket.ViewModel.Buyer;

namespace TrollMarket.Provider
{
    public class BuyerProvider : BaseProvider
    {
        private static BuyerProvider instance = new BuyerProvider();
        public static BuyerProvider GetProvider() { return instance; }
        private BuyerProvider() { }

        public IndexProfileBuyerViewModel GetProfileTransaction()
        {
            var histories = HistoryRepository.GetRepository().GetAll();
            var query = (from hist in histories
                         where hist.BuyerId == 1
                         select new TransactionHistoryViewModel
                         {
                             Date = FormatNullableDatetime(hist.PurchaseDate),
                             Product = hist.Product.ProductName,
                             Quantity = hist.Quantity,
                             Shipment = hist.Shipment.Name,
                             TotalPrice = FormatNullableDouble(hist.TotalPrice)
                         }).ToList();
            var buyer = BuyerRepository.GetRepository().GetSingle(1);
            var result = new IndexProfileBuyerViewModel
            {
                Name = buyer.Name,
                Role = "Buyer",
                Address = buyer.Address,
                Balance = FormatNullableDouble((double)buyer.Balance),
                History = query
            };
            return result;
        }
    }
}
