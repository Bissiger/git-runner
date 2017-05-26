using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    //Speed of CityMoving
    [SerializeField] private float _speed = 0.5f;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
}
