using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIzmos : MonoBehaviour
{
    public Color _color;
    public float _radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
