using System;
using UnityEngine;

namespace CVRunner
{
    /// <summary>
    /// Base class for all scene objects
    /// </summary>
    public abstract class BaseObjectScene : MonoBehaviour
    {
        private int _layer;
        private Color _color;
        private Transform _myTransform;
        private Vector3 _position;
        private Quaternion _rotation;
        private Vector3 _scale;
        private GameObject _instanceObject;
        private Rigidbody _rigidbody;
        private Vector3 _center;
        private Bounds _bound;
        private string _name;
        private bool _isVisible;

        protected virtual void Awake()
        {
            _instanceObject = gameObject;
            _name = InstanceObject.name;
            _rigidbody = InstanceObject.GetComponent<Rigidbody>();
            _myTransform = InstanceObject.transform;
        }

        #region Property

        /// <summary>
        /// Object name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }

        /// <summary>
        /// Object layer
        /// </summary>
        public int Layers
        {
            get { return _layer; }

            set
            {
                _layer = value;
                AskLayer(GetTransform, value);
            }
        }

        /// <summary>
        /// Object material color
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                AskColor(GetTransform, _color);
            }
        }

        /// <summary>
        /// Object position
        /// </summary>
        public Vector3 Position
        {
            get
            {
                _position = GetTransform.position;
                return _position;
            }
            set
            {
                _position = value;
                GetTransform.position = _position;
            }
        }

        /// <summary>
        /// Object scale
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                _scale = GetTransform.localScale;
                return _scale;
            }
            set
            {
                _scale = value;
                GetTransform.localScale = _scale;
            }
        }

        /// <summary>
        /// Object rotation
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                _rotation = GetTransform.rotation;
                return _rotation;
            }
            set
            {
                _rotation = value;
                GetTransform.rotation = _rotation;
            }
        }

        /// <summary>
        /// Object rigidbody
        /// </summary>
        public Rigidbody GetRigidbody
        {
            get { return _rigidbody; }
        }

        /// <summary>
        /// Gameobject link
        /// </summary>
        public GameObject InstanceObject
        {
            get { return _instanceObject; }
        }

        /// <summary>
        /// Object visible
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (InstanceObject.GetComponent<Renderer>())
                    InstanceObject.GetComponent<Renderer>().enabled = _isVisible;
                if (GetTransform.childCount <= 0) return;
                foreach (Transform d in GetTransform)
                {
                    if (d.gameObject.GetComponent<Renderer>())
                        d.gameObject.GetComponent<Renderer>().enabled = _isVisible;
                }
            }
        }

        /// <summary>
        /// Object transform
        /// </summary>
        public Transform GetTransform
        {
            get { return _myTransform; }
        }

        #endregion

        #region PrivateFunction
        /// <summary>
        /// Chenge object layer and all childs layers
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="lvl">Layer</param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
            {
                AskLayer(d, lvl);
            }
        }

        /// <summary>
        /// Chenge object material color and all childs collors
        /// </summary>
        /// <param name="obj">Object</param>
        /// <param name="color">Color</param>
        private void AskColor(Transform obj, Color color)
        {
            foreach (Material curMaterial in obj.GetComponent<Renderer>().materials)
            {
                curMaterial.color = color;
            }
            if (obj.childCount <= 0) return;
            foreach (Transform d in obj)
            {
                AskColor(d, color);
            }
        }
        #endregion

        /// <summary>
        /// Check rigidbody
        /// </summary>
        public bool IsRigitBody()
        {
            return GetRigidbody;
        }

        /// <summary>
        /// Rigidbody Off for object and his childs
        /// </summary>
        public void DisableRigidBody()
        {
            if (!IsRigitBody()) return;

            Rigidbody[] rigidbodies = InstanceObject.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = true;
            }
        }

        /// <summary>
        /// Rigidbody On for object and his childs
        /// </summary>
        public void EnableRigidBody()
        {
            if (!IsRigitBody()) return;
            Rigidbody[] rigidbodies = InstanceObject.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rigidbodies)
            {
                rb.isKinematic = false;
            }
        }
    }
}
