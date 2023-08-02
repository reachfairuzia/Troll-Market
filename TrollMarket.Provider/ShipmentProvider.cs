using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.DataAccess.Models;
using TrollMarket.Repository;
using TrollMarket.ViewModel.Shipment;

namespace TrollMarket.Provider
{
    public class ShipmentProvider
    {
        private static ShipmentProvider _instance = new ShipmentProvider();
        public static ShipmentProvider GetProvider()
        {
            return _instance;
        }
        public List<SelectListItem> GetShipmentDropdown()
        {
            var data = ShipmentRepository.GetRepository().GetAll();
            var dropdown = data.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ShipperId.ToString()
            }).ToList();
            return dropdown;
        }
        public IEnumerable<ShipmentViewModel> GetIndex()
        {
            return (from ship in ShipmentRepository.GetRepository().GetAll()
                    select new ShipmentViewModel
                    {
                        Name = ship.Name,
                        Price = ship.Price,
                        Service = ship.Service,
                        ShipperId = ship.ShipperId,
                        StringPrice = ship.Price == null ? "N/A" : ship.Price.Value.ToString("C2", CultureInfo.CurrentCulture),
                        ServiceStatus = ship.Service == true ? "Yes" : "No"
                    }).ToList();
        }

        public void Save(UpsertShipmentViewModel model)
        {
            if (model.ShipperId == 0)
            {
                var entity = new Shipment();
                entity.Name = model.Name;
                entity.Service = model.Service;
                entity.Price = model.Price;
                ShipmentRepository.GetRepository().Insert(entity);
            }
            else if (model.ShipperId != 0)
            {
                var entity = new Shipment();
                entity.Name = model.Name;
                entity.Service = model.Service;
                entity.Price = model.Price;
                entity.ShipperId = model.ShipperId;
                ShipmentRepository.GetRepository().Update(entity);
            }

        }

        public UpsertShipmentViewModel Edit(int id)
        {
            var shipment = ShipmentRepository.GetRepository().GetSingle(id);
            var model = new UpsertShipmentViewModel()
            {
                Name = shipment.Name,
                Price = shipment.Price,
                Service = shipment.Service,
                ShipperId = id
            };
            return model;
        }
        public void StopService(int id)
        {
            var shipment = ShipmentRepository.GetRepository().GetSingle(id);
            shipment.Service = false;
            ShipmentRepository.GetRepository().Update(shipment);
        }
        public ShipmentViewModel Detail(int id)
        {
            var shipment = ShipmentRepository.GetRepository().GetSingle(id);
            return new ShipmentViewModel()
            {
                Name = shipment.Name,
                Price = shipment.Price,
                Service = shipment.Service,
                ShipperId = id,
                ServiceStatus = shipment.Service == true ? "Yes" : "No",
                StringPrice = shipment.Price == null ? "N/A" : shipment.Price.Value.ToString("C", CultureInfo.CurrentCulture)
            };
        }
        public void Delete(int id)
        {
            var shipment = ShipmentRepository.GetRepository().GetSingle(id);
            ShipmentRepository.GetRepository().Delete(shipment);
        }
    }
}
