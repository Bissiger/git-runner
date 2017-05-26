using UnityEngine;
using CVRunner.Controller;

namespace CVRunner
{
    /// <summary>
    /// Start point of programm
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        [SerializeField] GameObject Player;

        private GameObject _controllers;
        private DirectionController _directionController;
        private CameraMover _cameraMover;
        private GameObject _player;
        private Pause _pause;
        private Data _data;

        private void Awake()
        {
            Instance = this;
            _controllers = new GameObject { name = "AllControllers" };
            _directionController = _controllers.AddComponent<DirectionController>();
            _cameraMover = GameObject.Find("Main Camera").GetComponent<CameraMover>();
            _player = Instantiate(Player);
            _pause = GameObject.Find("UI").GetComponent<Pause>();
            _data = gameObject.GetComponent<Data>();
        }

        #region Property
        /// <summary>
        /// Get GetCameraMover link
        /// </summary>
        public CameraMover GetCameraMover
        {
            get { return _cameraMover; }
        }
        /// <summary>
        /// Get DirectionController link
        /// </summary>
        public DirectionController GetDirectionController
        {
            get { return _directionController; }
        }
        /// <summary>
        /// Get Player link
        /// </summary>
        public GameObject GetPlayer
        { 
            get { return _player; }
        }
        /// <summary>
        /// Get link to Pause script
        /// </summary>
        public Pause GetPause
        {
            get { return _pause; }
        }
        /// <summary>
        /// Get link to Data script
        /// </summary>
        public Data GetData
        {
            get { return _data; }
        }
        #endregion

    }
}
