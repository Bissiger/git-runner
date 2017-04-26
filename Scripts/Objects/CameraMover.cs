using UnityEngine;

namespace CVRunner
{
    public class CameraMover : BaseObjectScene
    {

        [SerializeField] private float _speed = 0.3f;       //Speed of camera mooving
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
            Vector3 targetPos = Main.Instance.GetPlayer.transform.GetChild(1).transform.position;
            Quaternion targetRot = Main.Instance.GetPlayer.transform.GetChild(1).transform.rotation;

            if (Position != targetPos)
            {
                float pos_x = Mathf.Lerp(Position.x, targetPos.x, _speed * Time.deltaTime);
                float pos_y = Mathf.Lerp(Position.y, targetPos.y, _speed * Time.deltaTime);
                float pos_z = Mathf.Lerp(Position.z, targetPos.z, _speed * Time.deltaTime);
                Position = new Vector3 (pos_x, pos_y, pos_z);

                float rot_x = Mathf.Lerp(Rotation.x, targetRot.x, _speed * Time.deltaTime);
                float rot_y = Mathf.Lerp(Rotation.y, targetRot.y, _speed * Time.deltaTime);
                float rot_z = Mathf.Lerp(Rotation.z, targetRot.z, _speed * Time.deltaTime);
                float rot_w = Mathf.Lerp(Rotation.w, targetRot.w, _speed * Time.deltaTime);
                Rotation = new Quaternion(rot_x, rot_y, rot_z, rot_w);
            }
        }
    }
}
