using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawBounds : MonoBehaviour
{
    public void OnDrawGizmosSelected()
    {
        var r = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        if (r == null)
            return;
        var bounds = r.bounds;
        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(bounds.center, bounds.extents * 2);
    }
}
