﻿using UnityEngine;
using CVRunner.Controller;

namespace CVRunner
{
    /// <summary>
    /// Start point of programm
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        [SerializeField] GameObject Player;

        public static Main Instance { get; private set; }

        private GameObject _controllers;
        private DirectionController _directionController;
        private CameraMover _cameraMover;
        private GameObject _player;

        private void Start()
        {
            Instance = this;
            _controllers = new GameObject { name = "AllControllers" };
            _directionController = _controllers.AddComponent<DirectionController>();
            _cameraMover = GameObject.Find("Main Camera").transform.GetComponent<CameraMover>();
            _player = Instantiate(Player);
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
        #endregion
    }
}
