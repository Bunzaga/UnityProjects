using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private Transform _transform;

    private static MouseFollower _this;
    public static MouseFollower Instance { get { return _this; } }

    private void Awake()
    {
        if(_this != null && _this != this)
        {
            Destroy(gameObject);
            return;
        }
        _this = this;

        _transform = transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _transform.position = Input.mousePosition;
    }
}
