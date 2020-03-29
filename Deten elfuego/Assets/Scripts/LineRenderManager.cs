using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderManager : MonoBehaviour
{

    private LineRenderer line;

    //Target for the line
    [SerializeField]
    public Vector3 target;

    public void DrawLine(Vector3 origin, Vector3 target)
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.SetPosition(0, origin);
        line.SetPosition(1, target);
    }
}
