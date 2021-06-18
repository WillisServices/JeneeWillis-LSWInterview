using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Shop;
using Willis_Player;

namespace Willis_Inventory
{
    /// <summary>
    /// CLASS: EquipItems
    /// Author: Jenee Willis
    /// Description: Equip items to play and show it in game
    /// </summary>
    public class EquipItems : MonoBehaviour
    {
        [SerializeField] internal List<EquipInformation> equipInformation = new List<EquipInformation>();

        public void EquipItem()
        {
            for (int i = 0; i < equipInformation.Count; i++)
            {
                equipInformation[i].spriteToChange.sprite = equipInformation[i].itemImage;
            }
        }
    }
}
