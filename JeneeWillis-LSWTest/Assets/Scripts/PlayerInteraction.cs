using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Player
{
    /// <summary>
    /// CLASS: PlayerInteraction
    /// Author: Jenee Willis
    /// Description: Checks where player clicks and whether it is interactable
    /// </summary>
    internal class PlayerInteraction : MonoBehaviour
    {
        [Header("Script References")]
        [Tooltip("PlayerMovement script")]
        [SerializeField]
        private PlayerMovement playerMovementScript;

        [Header("Interactable Settings")]
        [Tooltip("What players can interact with")]
        [SerializeField]
        private LayerMask interactables;
        [Tooltip("How far character stops from the interactable gameobject")]
        [SerializeField]
        private float stopDistance = 2f;

        private GameObject hitObject;

        private bool canInteract = false;

        private void Update()
        {
            //checks if player has clicked on an interactable object with right mouse button
            if (Input.GetMouseButton(1))
            {
                RaycastHit2D hit = PlayerClick.GetHit(interactables);

                if (hit.collider != null)
                {
                    hitObject = hit.collider.gameObject;
                    canInteract = true;
                }
                else
                {
                    canInteract = false;
                }
            }

            //stop player at a certain distance if they clicked on an interactable object
            if (canInteract)
            {
                StopPlayerMovement();
            }
        }

        /// <summary>
        /// METHOD: StopPlayerMovement()
        /// Desscription: Stop player when they are close to interactable gameobject
        /// </summary> 
        private void StopPlayerMovement()
        {
            //check distance between player and the interactable gameobject to see how close they are to each other
            if (Vector2.Distance(transform.position, hitObject.transform.position) <= stopDistance)
            {
                playerMovementScript.isMoving = false;
                canInteract = false;
            }
        }
    }

    /// <summary>
    /// CLASS: PlayerClick
    /// Author: Jenee Willis
    /// Description: Get information about what gameobject the player has clicked on
    /// </summary>
    internal static class PlayerClick
    {
        internal static RaycastHit2D GetHit(LayerMask mask)
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayOrigin = new Vector2(clickPosition.x, clickPosition.y);

            //return clicked gameobject
            return Physics2D.Raycast(rayOrigin, Vector2.zero, mask);
        }
    }
}
