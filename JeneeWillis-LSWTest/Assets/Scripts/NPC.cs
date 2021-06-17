using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Willis_Interactions; //added

namespace Willis_NPC
{
    /// <summary>
    /// CLASS: NPC
    /// Author: Jenee Willis
    /// Description: Information about non-player characters
    /// </summary>
    public abstract class NPC : Interactable
    {
        [Header("NPC General Information")]
        [SerializeField] private string npcName = "";

        [Header("NPC Dialogue")]
        [SerializeField] private List<string> PassbyDialogue = new List<string>();
    }
}
