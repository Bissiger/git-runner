using System;
using UnityEngine;

namespace CVRunner.Controller
{
    public class DirectionController : MonoBehaviour
    {
        private Vector2 _direction; //Direction
        private Vector2 _tmpDirection; //Temp direction
        private Vector2 _resetDirection = new Vector2(0, 0);

        //Axis of Vector2
        private float _x;
        private float _y;

        //Vector value
        private int right = 1;
        private int left = -1;
        private int up = 1;
        private int down = -1;

        #region Property
        /// <summary>
        /// Get Vector2 direction
        /// </summary>
        public Vector2 GetDirection
        {
            get { return _direction; }
        }
        #endregion

        #region UnityFunctions
        private void Update()
        {
            SetDirection();
        }
        #endregion

        #region MyFunctions
        private void SetDirection()
        {
            if (Input.touchCount <= 0) return;

            Vector2 delta = Input.GetTouch(0).deltaPosition;

             if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
             {
                if (delta.x > 0) _x = right;
                else _x = left;
             }
             else
             {
                if (delta.y > 0) _y = up;
                else _y = down;
             }

             _tmpDirection = new Vector2(_x, _y);

             if (Input.touches[0].phase == TouchPhase.Moved)
             {
                _direction = _tmpDirection;
             }
             if (Input.touches[0].phase == TouchPhase.Ended)
             {
                _direction = _resetDirection;
             }
        }
        #endregion
    }
}