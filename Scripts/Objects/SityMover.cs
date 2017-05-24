using UnityEngine;

namespace CVRunner
{
    public class SityMover : BaseObjectScene
    {
        private float speed = 0.5f;

        private void Update()
        {
            if (!Main.Instance.GetPause.IsPaused)
            {
                Move();
            }
        }

        private void Move()
        {
            Position = new Vector3(Position.x, Position.y, Position.z - speed);
        }
    }
}
