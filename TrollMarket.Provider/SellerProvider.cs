﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.Repository;
using TrollMarket.ViewModel;
using TrollMarket.ViewModel.Buyer;
using TrollMarket.ViewModel.Seller;

namespace TrollMarket.Provider
{
    public class SellerProvider : BaseProvider
    {

        private static SellerProvider instance = new SellerProvider();
        public static SellerProvider GetProvider() { return instance; }
        private SellerProvider() { }

        public IndexProfileSellerViewModel GetProfileTransaction()
        {
            var histories = HistoryRepository.GetRepository().GetAll();
            var query = (from hist in histories
                         where hist.SellerId == 1
                         select new TransactionHistoryViewModel
                         {
                             Date = FormatNullableDatetime(hist.PurchaseDate),
                             Product = hist.Product.ProductName,
                             Quantity = hist.Quantity,
                             Shipment = hist.Shipment.Name,
                             TotalPrice = FormatNullableDouble(hist.TotalPrice)
                         }).ToList();
            var seller = SellerRepository.GetRepository().GetSingle(1);
            var result = new IndexProfileSellerViewModel
            {
                Name = seller.Name,
                Role = "Seller",
                Address = seller.Address,
                Balance = FormatNullableDouble(seller.Balance),
                History = query
            };
            return result;
        }

        public JsonResultViewModel GetTransactionSellerById(int id)
        {
            var check = HistoryRepository.GetRepository().GetSingle(id);
            if (check != null)
            {
                var data = (from hist in HistoryRepository.GetRepository().GetAll()
                            where hist.SellerId == id
                            select new TransactionHistoryViewModel
                            {
                                Date = FormatNullableDatetime(hist.PurchaseDate),
                                Product = hist.Product.ProductName,
                                Quantity = hist.Quantity,
                                Shipment = hist.Shipment.Name,
                                TotalPrice = FormatNullableDouble(hist.TotalPrice)
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
