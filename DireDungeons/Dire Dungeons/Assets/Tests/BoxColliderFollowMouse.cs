using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderFollowMouse : MonoBehaviour
{
    Vector3 rayPoint;
    Ray ray;
    float distance = 0.0f;

    [SerializeField]
    private List<Collider> _colliders = new List<Collider>();

    [SerializeField]
    private List<Renderer> _renderers = new List<Renderer>();

    [SerializeField]
    private LayerMask _collisionMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            rayPoint = ray.GetPoint(0);
            distance = Vector3.Distance(transform.position, rayPoint);
        }
        if (Input.GetMouseButton(0))
        {
            rayPoint = ray.GetPoint(distance);
            rayPoint.y = 0.0f;
            transform.position = rayPoint;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            rayPoint = ray.GetPoint(0);
            distance = Vector3.Distance(transform.position, rayPoint);

            if (NewNodeCollidesWithDungeon())
            {
                for (int i = 0, ilen = _renderers.Count; i < ilen; i++)
                {
                    _renderers[i].material.color = Color.red;
                }
            }
            else
            {
                for (int i = 0, ilen = _renderers.Count; i < ilen; i++)
                {
                    _renderers[i].material.color = Color.white;
                }
            }

        }
    }

    private bool NewNodeCollidesWithDungeon()
    {
        Vector3 center;
        Vector3 halfExtents;
        Collider[] results = new Collider[10];
        Quaternion orientation = Quaternion.identity;

        for (int i = 0, ilen = _colliders.Count; i < ilen; i++)
        {
            Collider col = _colliders[i];

            switch (col.GetType().Name)
            {
                case nameof(BoxCollider):
                    Debug.Log("Checking "+col.gameObject.name);
                    center = col.bounds.center;
                    halfExtents = col.transform.TransformDirection(col.bounds.extents);
                    orientation = transform.rotation;

                    //var box = Instantiate(boxPrefab, center, orientation);
                    //.transform.localScale = halfExtents * 2;
                    //box.transform.SetParent(col.transform.parent, true);

                    for (int j = 0, jlen = results.Length; j < jlen; j++)
                    {
                        results[j] = null;
                    }

                    int collisions = Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, _collisionMask, QueryTriggerInteraction.Collide);

                    if (collisions > 0)
                    {
                        for (int hitIndex = 0, resultLen = results.Length; hitIndex < resultLen; hitIndex++)
                        {
                            if (results[hitIndex] != null)
                            {
                                Debug.LogFormat("Checking Result[{0}]", hitIndex);
                                Debug.Log(results[hitIndex].transform.parent.parent.name);
                                Debug.Log(gameObject.name + ": There was a hit! " + hitIndex);
                                Debug.Log(results[hitIndex].transform.root.name);
                                return true;
                            }
                        }
                    }
                    break;

                case nameof(SphereCollider):
                    break;
            }

        }
        return false;
    }
}
