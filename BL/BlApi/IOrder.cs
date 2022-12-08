﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BlApi
{
    public interface IOrder
    {
        /// <summary>
        /// for the manager, return list of orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrderForList> GetListedOrders();
       /// <summary>
       /// for the manager and customer , retrun details of Order
       /// </summary>
        public BO.Order GetByID(int id);
        /// <summary>
        /// for help id of order and return list of BO.OrderItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BO.OrderItem> getDoOrderItem(int id);
        /// <summary>
        /// for the manager , update DeliveryDate and return Order
        /// </summary>
        public BO.Order UpdateDelivery(int id);
        /// <summary>
        /// for the manager , update ShipDate and return Order
        /// </summary>
        public BO.Order UpdateShipDate(int id);   
        /// <summary>
        /// for the manager, return order
        /// </summary>
        public BO.OrderTracking followOrder(int id);

    }
}
