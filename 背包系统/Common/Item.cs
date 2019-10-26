﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int BuyPrice { get; private set; }
    public int SellPrice { get; private set; }
    public string Icon { get; private set; }
    public string ItemType { get; protected set; }   //protected表示子类也可以设置

    public Item(int id,string name,string description,int buyPrice,int sellPrice,string icon)
    {
        this.ID = id;
        this.Name = name;
        this.Description = description;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Icon = icon;
    }
}
