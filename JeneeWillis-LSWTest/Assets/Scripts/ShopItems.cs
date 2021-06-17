using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Shop
{
    [System.Serializable]
    internal class ShopItems
    {
        public int itemID;
        public Sprite itemImage;
        public int itemCost;
        public int itemSellPrice;
        public bool isEquipped;
    }
}
