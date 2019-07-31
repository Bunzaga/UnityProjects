using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowerFollower : MonoBehaviour
{
    private static List<MouseFollowerFollower> _otherFollowers = new List<MouseFollowerFollower>();
    public static List<MouseFollowerFollower> OtherFollowers { get { return _otherFollowers; } }

    public Vector3 DesiredPosition;
    public float RadOffset;
    public float Speed = 1f;

    private void Awake()
    {
        Speed = Random.Range(1.5f, 1.25f);
        _otherFollowers.Add(this);
    }
}

