using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve2 : MonoBehaviour
{
    public Transform A, B, C, D;

    private Vector3 p0, p1, p2;

    private Vector3 c0, c1;

    private Vector3 BezierPt;

    [Range(0, 1)]
    public float T;

    void OnDrawGizmos()
    {
        #region Drawing Lines
        Gizmos.DrawLine(A.position, B.position);
        Gizmos.DrawLine(B.position, C.position);
        Gizmos.DrawLine(C.position, D.position);

        Gizmos.DrawLine(p0, p1);
        Gizmos.DrawLine(p1, p2);

        Gizmos.DrawLine(c0, c1);
        #endregion

        #region Drawing Curve Line
        const int Detail = 32;
        Vector3 prev = A.position;
        for (int i = 1; i < Detail; i++)
        {
            float tDraw = i / (Detail - 1f);
            Vector3 p = GetBezierPoint(A.position, B.position, C.position, D.position, tDraw);
            Gizmos.DrawLine(prev, p);
            prev = p;
        }
        #endregion

        BezierPt = GetBezierPoint(A.position, B.position, C.position, D.position, tManager.instance.T);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BezierPt, 0.2f);
    }

    Vector3 GetBezierPoint(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
    {
        p0 = Vector3.Lerp(A, B, t);
        p1 = Vector3.Lerp(B, C, t);
        p2 = Vector3.Lerp(C, D, t);

        c0 = Vector3.Lerp(p0, p1, t);
        c1 = Vector3.Lerp(p1, p2, t);

        return Vector3.Lerp(c0, c1, t);
    }
}
