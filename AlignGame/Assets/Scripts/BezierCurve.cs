using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    private Vector3 gizmosPosition;
    [SerializeField] private Transform[] controlPoints;

    private LinkedList<Vector3> functionDots;

    private LineRenderer lineRenderer;


    public void OnDrawGizmos()
    {
        functionDots = new LinkedList<Vector3>();
        for (float t = 0; t <= 1; t += 0.025f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * controlPoints[0].position +
                     3 * t * Mathf.Pow(1 - t, 2) * controlPoints[1].position +
                     3 * (1 - t) * Mathf.Pow(t, 2) * controlPoints[2].position +
                     Mathf.Pow(t, 3) * controlPoints[3].position;

            functionDots.AddFirst(gizmosPosition);
            Gizmos.DrawSphere(gizmosPosition, 0.25f);
        }

        drawTrailFunction();

        Gizmos.DrawLine(new Vector3(controlPoints[0].position.x, 0, controlPoints[0].position.z),
            new Vector3(controlPoints[1].position.x, 0, controlPoints[1].position.z));

        Gizmos.DrawLine(new Vector3(controlPoints[2].position.x, 0, controlPoints[2].position.z),
            new Vector3(controlPoints[3].position.x, 0, controlPoints[3].position.z));
    }

    private void drawTrailFunction()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.positionCount = functionDots.Count;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, functionDots.Last.Value);
            functionDots.RemoveLast();
        }
    }
}
