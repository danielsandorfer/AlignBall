using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteFollower : MonoBehaviour
{

    [SerializeField] private Transform[] vertices;

    private int vertixToGo;
    private float tParam;
    private Vector3 ballPosition;
    private float speedModifier;
    private bool coroutineAllowed;

    private static bool pause;

    // Start is called before the first frame update
    void Start()
    {
        vertixToGo = 0;
        speedModifier = 0.5f;
        tParam = 0f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(FollowRoute(vertixToGo));
        }
    }

    public static void stopRoutine()
    {
        pause = true;

    }

    private IEnumerator FollowRoute(int vertixNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = vertices[vertixNum].GetChild(0).position;
        Vector3 p1 = vertices[vertixNum].GetChild(1).position;
        Vector3 p2 = vertices[vertixNum].GetChild(2).position;
        Vector3 p3 = vertices[vertixNum].GetChild(3).position;

        while(tParam < 1)
        {
            if (pause)
            {
                yield return new WaitForSeconds(1f);
            }
            tParam += Time.deltaTime * speedModifier;

            ballPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                    3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                    3 * Mathf.Pow(tParam, 2) * (1 - tParam) * p2 +
                    Mathf.Pow(tParam, 3) * p3;

            transform.position = ballPosition;
            yield return new WaitForEndOfFrame();
        }
        

        tParam = 0f;
        vertixToGo++;

        if(vertixToGo > vertices.Length - 1)
        {
            vertixToGo = 0;
        }

        coroutineAllowed = true;

    }
}
