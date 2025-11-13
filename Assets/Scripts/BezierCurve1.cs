using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve1 : MonoBehaviour
{
    public Transform A, B, C;

    private Vector3 p0, p1;

    private Vector3 BezierPt;


    [Range(0, 1)]
    public float T;


    void OnDrawGizmos()
    {
        #region Drawing Lines
        Gizmos.DrawLine(A.position, B.position);
        Gizmos.DrawLine(B.position, C.position);
        Gizmos.DrawLine(p0, p1);
        #endregion

        #region Drawing Curve Line
        const int Detail = 32;
        Vector3 prev = A.position;
        for (int i = 1; i < Detail; i++)
        {
            float tDraw = i / (Detail - 1f);
            Vector3 p = GetBezierPoint(A.position, B.position, C.position, tDraw);
            Gizmos.DrawLine(prev, p);
            prev = p;
        }
        #endregion

        BezierPt = GetBezierPoint(A.position, B.position, C.position, tManager.instance.T);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BezierPt, 0.2f);
    }

    public Vector3 GetBezierPoint(Vector3 A, Vector3 B, Vector3 C, float t)
    {
        p0 = Vector3.Lerp(A, B, t);
        p1 = Vector3.Lerp(B, C, t);

        return Vector3.Lerp(p0, p1, t);

    }
}
