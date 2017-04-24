using UnityEngine;

namespace CVRunner
{
    public class PlayerMover : BaseObjectScene
    {
        private float speed = 0.2f; //Speed of moving

        //Corners of field
        private int maxPos = -5;
        private int minPos = -15;

        void Update()
        {
            Move(Main.Instance.GetDirectionController.GetDirection);
        }

        // Direction always have value 1, -1 or 0
        private void Move(Vector2 direction)
        {
            Vector3 tmpPosition = new Vector3(Position.x, Position.y, Position.z + (speed * direction.x));
            if (tmpPosition.z < minPos || tmpPosition.z > maxPos) return;
            Position = tmpPosition;
        }
    }
}
