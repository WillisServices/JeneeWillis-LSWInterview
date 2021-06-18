using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Shop
{
    /// <summary>
    /// CLASS: ShopItems
    /// Author: Jenee Willis
    /// Description: Holds information about each item in store
    /// </summary>
    [System.Serializable]
    internal class ShopItems
    {
        internal int itemID;
        internal int itemSellPrice;

        [Header("Equip Information")]
        public List<EquipInformation> equipInformation = new List<EquipInformation>();

        [Header("General Information")]
        public int itemCost;
        [Tooltip("item tags, put space between each tag")]
        public string itemFilters;

        internal bool canSell = false;
    }

    [System.Serializable]
    internal class EquipInformation
    {
        public SpriteRenderer spriteToChange;
        public Sprite itemImage;
    }
}
