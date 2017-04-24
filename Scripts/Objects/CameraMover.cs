using UnityEngine;

namespace CVRunner
{
    public class CameraMover : BaseObjectScene
    {

        [SerializeField] private float _speed = 0.3f;       //Speed of camera mooving
        [SerializeField] private GameObject targetPos;      //Camera will be moved to this target
        [SerializeField] private float _distToObj = 2.5f;   //Distance to object from Camera   
        private bool isActive = false;                      //flag ON/OFF moving

        private void Update()
        {
            MoveCamera();
        }

        public void On()
        {
            isActive = true;
        }
        public void Off()
        {
            isActive = false;
        }

        /// <summary>
        /// This void moving camera from current position to target object
        /// </summary>
        /// <param name="target">Camera will be moved to this target GameObject</param>
        public void MoveCamera()
        {
            if (!isActive) return;
            Vector3 tmpTargetPos = targetPos.transform.position;
            if (Position != tmpTargetPos)
            {
                float x = Mathf.Lerp(Position.x, tmpTargetPos.x, _speed * Time.deltaTime);
                float y = Mathf.Lerp(Position.y, tmpTargetPos.y, _speed * Time.deltaTime);
                float z = Mathf.Lerp(Position.z, tmpTargetPos.z-_distToObj, _speed * Time.deltaTime);
                Position = new Vector3 (x,y,z);
            }
        }
    }
}
