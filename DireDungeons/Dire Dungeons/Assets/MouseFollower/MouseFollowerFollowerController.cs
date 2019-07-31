using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowerFollowerController : MonoBehaviour
{
    private void Start()
    {
        float radCountOffset = (90f / (MouseFollowerFollower.OtherFollowers.Count));
        for (int i = MouseFollowerFollower.OtherFollowers.Count; i-- > 0;)
        {
            MouseFollowerFollower a = MouseFollowerFollower.OtherFollowers[i];
            a.RadOffset = 90 + (i * radCountOffset);
        }
    }

    private void Update()
    {
        for (int i = MouseFollowerFollower.OtherFollowers.Count; i-- > 0;)
        {
            MouseFollowerFollower a = MouseFollowerFollower.OtherFollowers[i];
            Vector3 offsetDir = new Vector3(Mathf.Cos(a.RadOffset), Mathf.Sin(a.RadOffset)) * 200f;

            Vector3 aPointingToMouseFollower = (MouseFollower.Instance.transform.position + offsetDir) - a.transform.position;


            if (aPointingToMouseFollower.magnitude > 10)
            {
                a.DesiredPosition = aPointingToMouseFollower;
            }
            else
            {
                a.DesiredPosition = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = MouseFollowerFollower.OtherFollowers.Count; i-- > 0;)
        {
            MouseFollowerFollower a = MouseFollowerFollower.OtherFollowers[i];

            Vector3 waveOffset = new Vector3(a.DesiredPosition.normalized.y, -a.DesiredPosition.normalized.x) * Mathf.Sin((Time.time + a.RadOffset) * 10f) * a.DesiredPosition.magnitude * 0.25f;

            a.transform.position += (a.DesiredPosition + waveOffset) * Time.fixedDeltaTime * a.Speed;
        }

        for (int i = MouseFollowerFollower.OtherFollowers.Count; i-- > 0;)
        {
            MouseFollowerFollower a = MouseFollowerFollower.OtherFollowers[i];

            for (int j = i; j-- > 0;)
            {
                MouseFollowerFollower b = MouseFollowerFollower.OtherFollowers[j];

                Vector3 bPointingToA = a.transform.position - b.transform.position;

                if (bPointingToA.magnitude < 100)
                {
                    // they are in the same spot
                    if (bPointingToA.magnitude == 0)
                    {
                        bPointingToA = Random.onUnitSphere * 100f;
                        bPointingToA.z = 0;
                    }

                    a.transform.position += (bPointingToA.normalized * 0.5f * (100 - bPointingToA.magnitude));
                    b.transform.position -= (bPointingToA.normalized * 0.5f * (100 - bPointingToA.magnitude));
                }
            }
        }
    }
}