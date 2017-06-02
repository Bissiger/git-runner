using UnityEngine;

namespace CVRunner
{
    public class CityMover : BaseObjectScene
    {
        //Time of life an object
        private float lifeTime = 8f;

        private void Update()
        {
            if (!Main.Instance.GetPause.IsPaused)
            {
                Move();
            }
        }

        private void Move()
        {
            float speed = Main.Instance.GetData.Speed;
            Position = new Vector3(Position.x, Position.y, Position.z - speed);
            Destroy(gameObject, lifeTime);         
        }
    }
}
