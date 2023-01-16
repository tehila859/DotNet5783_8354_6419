﻿
using DO;
using DalApi;
using System;
using System.Reflection;

namespace Dal;

public class DalOrderItem : IOrderItem

{
    DataSource _dataSource = DataSource.s_instance;
    public OrderItem? GetById(Func<OrderItem?, bool>? predicate)
    {
        return _dataSource.OrderItemList?.FirstOrDefault(predicate)
            ?? throw new NotExists("Sorry ,this item does not exist in the List ");
    }
    /// <summary>
    /// This function adds an order item
    /// </summary>
    public int Add(OrderItem myOrderItem)
    {
        if (myOrderItem.ID == 0)
            myOrderItem.ID = DataSource.Config.NextOrderItemID;
        if (_dataSource.OrderItemList.Exists(p => p?.ID == myOrderItem.ID))
            throw new AlreadyExists("The order item already exists");
        _dataSource.OrderItemList.Add(myOrderItem);
        return myOrderItem.ID;
    }

    /// <summary>
    /// This function returns the details of an order item based on an id
    /// </summary>
    public OrderItem GetById(int id)
    {

        return _dataSource.OrderItemList?.FirstOrDefault(s => s?.ID == id)
        ?? throw new NotExists("Sorry ,this item does not exist in the List ");

    }

    /// <summary>
    /// This function returns the list with all of the order items
    /// </summary>
    public IEnumerable<OrderItem?> GetAll(Func<OrderItem?, bool>? predicate = null)
    {
        ///looking for all of the products that have their details filed in and returning them
        if (predicate == null) { return _dataSource.OrderItemList.AsEnumerable(); }
        return _dataSource.OrderItemList.Where(predicate) ?? _dataSource.OrderItemList.AsEnumerable();
    }

    /// <summary>
    /// This function receives an id of an ordre item and deletes the order item witn the same id
    /// </summary>
    public void Delete(int id)
    {

        //foreach (var item in _dataSource.OrderItemList)
        //{
        //    ///Checking if the requested id is equal to the id 
        //    if (item?.ID == id)
        //    {
        //        _dataSource.OrderItemList.Remove(item);
        //        return;
        //    }
        //}
        var orderItem = (from item in _dataSource.OrderItemList
                         where item?.ID == id
                         select item).FirstOrDefault();
        if (orderItem != null)
        {
            _dataSource.OrderItemList.Remove(orderItem);
            return;
        }
        /// If the order item was not found in the list
        throw new NotExists("Sorry ,this item does not exist in the list ");

    }

    /// <summary>
    /// This function receives an order item and updates the order item in the list that has the same id
    /// </summary>
    public void Update(OrderItem myOrderItem)
    {

        //int index = 0;
        //foreach (var item in _dataSource.OrderItemList)
        //{
        //    if (item?.ID == myOrderItem.ID) ///updating the order
        //    {
        //        _dataSource.OrderItemList.RemoveAt(index);
        //        _dataSource.OrderItemList.Insert(index, myOrderItem);
        //        return;
        //    }
        //    index++;
        //}
        var orderItem = (from item in _dataSource.OrderItemList
                         where item?.ID == myOrderItem.ID
                         select item).FirstOrDefault();
        if (orderItem != null)
        {
            _dataSource.OrderItemList.Remove(orderItem);
            _dataSource.OrderItemList.Add(myOrderItem);
            return;
        }
        ///if the id of the requested order item is not found in the list
        throw new NotExists("Order Item to be updated does not exist");
    }


}

    //!!!predicate בשלב 3 היינו צריכות למחוק את הפונקציות הללו כי הן מיותרות אחרי שלמדנו 



    /// <summary>
    /// This function receives an order id and a product id and returns the matching order item
    /// </summary>
    //public OrderItem getOrderItem(int idOrder, int idProduct)//צריכות למחוק את הפונקציה הזאת!!!
    //{

    //    //OrderItem orderItem = new OrderItem();
    //    //foreach (OrderItem item in _dataSource.OrderItemList)
    //    //{
    //    //    ///checking if an orderitem has the same product and order id's as the on e the user entered 
    //    //    if (item.ProductID == idProduct && item.OrderID == idOrder)
    //    //    {
    //    //        ///The correct order item based on the user input
    //    //        orderItem = item;
    //    //        return orderItem;
    //    //    }
    //    //}
    //    ////If the order item being looked for is not found in the list
    //    //throw new NotExists("Sorry ,this item does not exist in the list ");

    //    return GetById(item => item?.ProductID == idProduct && item?.OrderID == idOrder);
    //}


    /// <summary>
    /// This function returns an array of all of the order items with the order id the user entered
    /// </summary>
    //public IEnumerable <OrderItem?> getListOrderItems(int idOrder)// צריכות למחוק את הפונקציה הזאת!!!
    //{
    //    //creating an list with all of the order items that have the same order id as the one the user entered
    //    //Func<OrderItem, bool>? predicate = item =>
    //    //{
    //    //    bool b1 = item.OrderID == idOrder;
    //    //    return b1;
    //    //};
    //    //OrderItem orderItem=

    //    ////If no order items arec found with the order id the user entered
    //    //throw new NotExists("No order items found with the entered order id");
    //    return GetAll(item => item?.OrderID == idOrder) ??
    //    throw new NotExists("No order items found with the entered order id");

    //}



