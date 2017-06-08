using UnityEngine;
using CVRunner.Interface;

namespace CVRunner
{
    public class CarNPC : BaseObjectScene, ICollision
    {
        //Value of additional moving speed
        private float accel;
        //Flag for start or stop moving script
        private bool isMoving;

        #region Property
        public float Acceleration
        {
            get { return accel; }
            set { accel = value; }
        }

        public bool IsMoving
        {
            get { return isMoving; }
        }
        #endregion

        void Start()
        {
            isMoving = true;
            InstanceObject.tag = "Barrier";
        }

        // Update is called once per frame
        void Update()
        {
            if (isMoving && !Main.Instance.GetPause.IsPaused)
            {
                Move();
            }
        }

        private void Move()
        {
            float speed = Main.Instance.GetData.Speed;
            Position = new Vector3(Position.x, Position.y, Position.z - speed - accel);
        }

        public void CollisionEffect()
        {
            //TODO: change this code
            Debug.Log("BANG!");
        }
    }
}
