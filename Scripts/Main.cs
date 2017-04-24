﻿using UnityEngine;
using CVRunner.Controller;

namespace CVRunner
{
    /// <summary>
    /// Start point of programm
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        private GameObject _controllers;
        private DirectionController _directionController;
        private CameraMover _cameraMover;

        private void Start()
        {
            Instance = this;
            _controllers = new GameObject { name = "AllControllers" };
            _directionController = _controllers.AddComponent<DirectionController>();
            _cameraMover = GameObject.Find("Main Camera").transform.GetComponent<CameraMover>();
        }

        #region Property
        /// <summary>
        /// Get GetCameraMover controller
        /// </summary>
        public CameraMover GetCameraMover
        {
            get { return _cameraMover; }
        }
        /// <summary>
        /// Get DirectionController controller
        /// </summary>
        public DirectionController GetDirectionController
        {
            get { return _directionController; }
        }
        #endregion
    }
}
