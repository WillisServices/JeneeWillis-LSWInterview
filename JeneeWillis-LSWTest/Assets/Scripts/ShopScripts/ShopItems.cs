using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Shop
{
    [System.Serializable]
    internal class ShopItems
    {
        internal int itemID;
        internal Categories itemCategory;
        internal int itemSellPrice;
        internal bool isEquipped;

        public Sprite itemImage;
        public int itemCost;
    }
}
