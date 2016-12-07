using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class Carts
    {
        public Carts()
        { }

        public string CartID
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string GoodsID
        {
            get;
            set;
        }

        public int Amount
        {
            get;
            set;
        }

        public float TotalPrice
        {
            get;
            set;
        }

        public string GoodsName
        {
            get;
            set;
        }

        public string CreateTime
        {
            get;
            set;
        }

        public string GoodsFrom
        {
            get;
            set;
        }

        public string Introduction
        {
            get;
            set;
        }

        public float NowPrice
        {
            get;
            set;
        }

        public string Picture
        {
            get;
            set;
        }

    }
}