using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovement playerMovementScript;
        [SerializeField]
        private LayerMask interactables;

        [SerializeField]
        private float stopDistance = 2f;

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 rayOrigin = new Vector2(clickPosition.x, clickPosition.y);

                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, interactables);

                if (hit.collider != null)
                {
                    if (Vector2.Distance(transform.position, hit.collider.transform.position) <= stopDistance)
                    {
                        playerMovementScript.targetPosition = transform.position;
                    }
                }
            }
        }
    }
}
