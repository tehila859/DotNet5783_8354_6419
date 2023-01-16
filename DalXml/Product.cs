﻿using System;
using DalApi;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using DO;
using System.Linq;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Text;

//implement IStudent with xelement
namespace Dal
{
   

    internal class Product : IProduct
    {
        const string s_products = "products1";
        static DO.Product? getProduct(XElement s) =>
        s.ToIntNullable("ID") is null ? null : new DO.Product()
        {
            ID = (int)s.Element("ID")!,
            Name = (string?)s.Element("FirstName"),
            Price = (double)s.Element("Price"),
            InStock = (int)s.Element("InStock")!,
            Category = s.ToEnumNullable<DO.Category>("Category"),
           
        };

        static IEnumerable<XElement> createProductElement(DO.Product product)
        {
            yield return new XElement("ID", product.ID);
            if (product.Name is not null)
                yield return new XElement("Name", product.Name);          
            if (product.Category is not null)
                yield return new XElement("Category", product.Category);
            
                yield return new XElement("Price", product.Price);
            
                yield return new XElement("Instock", product.InStock);
        }

        public IEnumerable<DO.Product?> GetAll(Func<DO.Product?, bool>? filter = null) =>
            filter is null
            ? XMLTools.LoadListFromXMLElement(s_products).Elements().Select(s => getProduct(s))
            : XMLTools.LoadListFromXMLElement(s_products).Elements().Select(s => getProduct(s)).Where(filter);

        public DO.Product GetById( int id) =>
            (DO.Product)getProduct(XMLTools.LoadListFromXMLElement(s_products)?.Elements()
            .FirstOrDefault(st => st.ToIntNullable("ID") == id)
            // fix to: throw new DalMissingIdException(id);
            ?? throw new Exception("missing id"))!;

        public DO.Product? GetById(Func<DO.Product?, bool>? predicate)
        {
            var productsList = XMLTools.LoadListFromXMLSerializer<DO.Product>(s_products)!;
            if (productsList.FirstOrDefault(predicate) == null)
            {
                throw new Exception("Product not Exsits");
            }
            return productsList.FirstOrDefault(predicate);

        }


        public int Add(DO.Product product)
        {
            XElement productsRootElem = XMLTools.LoadListFromXMLElement(s_products);

            if (XMLTools.LoadListFromXMLElement(s_products)?.Elements()
                .FirstOrDefault(st => st.ToIntNullable("ID") == product.ID) is not null)
                // fix to: throw new DalMissingIdException(id);;
                throw new Exception("id already exist");

            productsRootElem.Add(new XElement("Student", createProductElement(product)));
            XMLTools.SaveListToXMLElement(productsRootElem, s_products);

            return product.ID; ;
        }

        public void Delete(int id)
        {
            XElement studentsRootElem = XMLTools.LoadListFromXMLElement(s_products);

            (studentsRootElem.Elements()
                // fix to: throw new DalMissingIdException(id);
                .FirstOrDefault(st => (int?)st.Element("ID") == id) ?? throw new Exception("missing id"))
                .Remove();

            XMLTools.SaveListToXMLElement(studentsRootElem, s_products);
        }

        public void Update(DO.Product product)
        {
            Delete(product.ID);
            Add(product);
        }

    }
}
