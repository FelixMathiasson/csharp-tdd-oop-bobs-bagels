﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Manager manager = new Manager();
        double funds = 0;
        public Customer(double funds)
        {
            this.funds = funds;
        }


        public bool AddToBasket(string name, string variant)
        {
            if(manager.ConfirmOrder(name, variant, funds - basket.ShowCost(), basket.GetSize()))
            {
                //manager says yes
                // funds OK! Capcity OK! Item exists OK!
                Basket.BasketItem basketItem = new Basket.BasketItem(inventory.GetCode(name, variant));
                basket.Add(basketItem);
                return true;
            }
            return false;
        }
        public bool AddToBasket(string name, string variant, string filling)
        {
            if (manager.ConfirmOrder(name, variant, funds - basket.ShowCost(), basket.GetSize()))
            {
                //manager says yes
                // funds OK! Capcity OK! Item exists OK!

                //now we check filling 
                if (manager.ConfirmOrder("Filling", filling, funds - basket.ShowCost(), basket.GetSize()) && name == "Bagel")
                {
                    Basket.BasketItem basketItem = new Basket.BasketItem(inventory.GetCode(name, variant), inventory.GetCode("Filling", filling));
                    basket.Add(basketItem);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveItem(string name, string variant)
        {
            throw new NotImplementedException();
        }

        public double ShowCost()
        {
            return basket.ShowCost(); 
        }

        public void ViewMenu()
        {
            foreach (var item in inventory.stock)
            {
                Console.WriteLine(item.Value.name + " " + item.Value.variant
                    + " " + item.Value.price);
            }
        }
    }
}
