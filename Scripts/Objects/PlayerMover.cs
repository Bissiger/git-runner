using UnityEngine;

namespace CVRunner
{
    public class PlayerMover : BaseObjectScene
    {
        private float speed = 0.2f; //Speed of moving

        //Corners of field
        private int maxPos = 5;
        private int minPos = -5;

        void Update()
        {
            Move(Main.Instance.GetDirectionController.GetDirection);
        }

        // Direction always have value 1, -1 or 0
        private void Move(Vector2 direction)
        {
            Vector3 tmpPosition = new Vector3(Position.x + (speed * direction.x), Position.y, Position.z);
              if (tmpPosition.x < minPos || tmpPosition.x > maxPos) return;
            Position = tmpPosition;
        }
    }
}
