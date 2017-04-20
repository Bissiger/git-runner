using UnityEngine;

namespace CVRunner
{
    /// <summary>
    /// Start point of programm
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        private GameObject _controllers;
        private CameraMover _cameraMover;

        private void Start()
        {
            Instance = this;
            _controllers = new GameObject { name = "AllControllers" };
            _cameraMover = GameObject.Find("Main Camera").transform.GetComponent<CameraMover>();
        }

        #region Property
        /// <summary>
        /// Get DirectionController controller
        /// </summary>
        public CameraMover GetCameraMover
        {
            get { return _cameraMover; }
        }
        #endregion
    }
}
