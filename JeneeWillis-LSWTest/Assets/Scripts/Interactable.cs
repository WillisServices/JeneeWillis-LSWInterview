using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Willis_Interactions
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField]
        internal UnityEvent PlayerInteract;
    }
}
