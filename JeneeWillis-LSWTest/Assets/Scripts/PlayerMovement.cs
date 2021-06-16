using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Willis_Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5f;

        internal Vector2 targetPosition;

        private bool isMoving = false;

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                GetTargetPosition();
            }

            if (isMoving)
            {
                MovePlayer();
            }
        }

        private void GetTargetPosition()
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            isMoving = true;
        }

        private void MovePlayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

            if (ConvertToVector2(transform.position) == targetPosition)
            {
                isMoving = false;
            }
        }

        private Vector2 ConvertToVector2(Vector3 vector3)
        {
            return (new Vector2(vector3.x, vector3.y));
        }
    }
}
