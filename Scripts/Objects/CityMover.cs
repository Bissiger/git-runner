using UnityEngine;

namespace CVRunner
{
    public class CityMover : BaseObjectScene
    {
        private float speed;

        private void Update()
        {
            if (!Main.Instance.GetPause.IsPaused)
            {
                speed = Main.Instance.GetData.Speed;
                Position = new Vector3(Position.x, Position.y, Position.z - speed);
            }
        }
    }
}
