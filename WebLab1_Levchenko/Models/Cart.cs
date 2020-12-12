﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Количество котят
        /// </summary>
        /// 
        public int CatsWeight
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
               item.Value.Cats.CatsWeight);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="cats">добавляемый объект</param>
        public virtual void AddToCart(Cats cats)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(cats.CatsID))
                Items[cats.CatsID].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(cats.CatsID, new CartItem
                {
                    Cats = cats,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Cats Cats { get; set; }
        public int Quantity { get; set; }
    }


}

