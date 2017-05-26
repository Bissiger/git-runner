using UnityEngine;

namespace CVRunner
{
    public class PlayerMover : BaseObjectScene
    {
        //Speed of moving
        [SerializeField] private float speed = 0.2f;
        //Deviation from player position at wich you can choose different direction
        [SerializeField] private float deviation = 0.5f;

        //Corners of game field
        private float maxCornerX = -3.4f;
        private float minCornerX = -13.6f;

        //Player will be moving to this position after Start Animation
        private float targetPosX = -6.8f; 
  
        //Step for set next target
        private float step = 3.4f;

        //Helpers
        private Vector2 resetDirection = new Vector2(0, 0);
        private Vector2 tmpDirection = new Vector2(0,0);
        private bool isSetPosition = true;
      
        void Update()
        {
            if (!Main.Instance.GetPause.IsPaused)
            {
                SetDirection(Main.Instance.GetDirectionController.GetDirection);
                SetPosition();
                Move();
            }
        }

        //Just set direction of moving
        private void SetDirection(Vector2 direction)
        {
            if(direction.x != 0 && tmpDirection == resetDirection)
            { 
                tmpDirection = direction;
            }
        }

        //Move in set tmpDirection with set speed
        private void Move()
        {
            // move left (directin always -1, 0 ro 1)
            if(tmpDirection.x < 0 && targetPosX < Position.x)
            { 
                float pos_x = Position.x + (speed * tmpDirection.x);
                Position = new Vector3(pos_x, Position.y, Position.z);
                return;
            }
            // move right (directin always -1, 0 ro 1)
            if (tmpDirection.x > 0 && targetPosX > Position.x)
            {
                float pos_x = Position.x + (speed * tmpDirection.x);
                Position = new Vector3(pos_x, Position.y, Position.z);
                return;
            }
            //now i can change direction
            tmpDirection = resetDirection;
            isSetPosition = true;
        }

        private void SetPosition()
        {
            // move left
            if (isSetPosition && tmpDirection.x < 0 && targetPosX-step > minCornerX-deviation)
            {
                targetPosX -= step;
                isSetPosition = false;
            }
            // move right
            if (isSetPosition && tmpDirection.x > 0 && targetPosX+step < maxCornerX+deviation)
            {
                targetPosX += step;
                isSetPosition = false;
            }
        }
    }
}
