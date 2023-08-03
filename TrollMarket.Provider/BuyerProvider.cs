using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Repository;
using TrollMarket.ViewModel;
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
                BuyerId = buyer.Id,
                Name = buyer.Name,
                Role = "Buyer",
                Address = buyer.Address,
                Balance = FormatNullableDouble((double)buyer.Balance),
                History = query
            };
            return result;
        }

        public void TambahDana(TopupDanaViewModel model)
        {
            //ambil oldbuyer
            var oldBuyer = BuyerRepository.GetRepository().GetSingle(model.BuyerId);
            oldBuyer.Balance += model.Dana;

            //update
            BuyerRepository.GetRepository().Update(oldBuyer);
        }

        public JsonResultViewModel GetTransactionBuyerById(int id)
        {
            var check = HistoryRepository.GetRepository().GetSingle(id);
            if (check != null)
            {
                var data = (from hist in HistoryRepository.GetRepository().GetAll()
                            where hist.BuyerId == id
                            select new Transac
                            {
                                Date = FormatNullableDatetime(hist.PurchaseDate),
                                Product = hist.Product.ProductName,
                                Quantity = hist.Quantity,
                                Shipment = hist.Shipment.Name,
                                TotalPrice = FormatNullable(hist.TotalPrice)
                            }).ToList();
                return new JsonResultViewModel()
                {
                    Success = true,
                    Message = "Transaction Found",
                    ReturnObject = data
                };
            }
            else
            {
                return new JsonResultViewModel()
                {
                    Success = false,
                    Message = "Transaction Not Found",
                    ReturnObject = check
                };
            }
        }
    }
}
