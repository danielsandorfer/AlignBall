using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MainCanvas").GetComponent<Canvas>().worldCamera = Camera.main;
        Transform cameraTransform = this.GetComponent<Transform>();
        Camera camera = this.GetComponent<Camera>();

        //Horizontal colliders
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y + camera.orthographicSize + 0.5f - 5f, 0);
        boxCollider.size = new Vector3(2*camera.orthographicSize*camera.aspect, boxCollider.size.y, boxCollider.size.z);
   

        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y - camera.orthographicSize - 0.5f, 0);
        boxCollider.size = new Vector3(2 * camera.orthographicSize*camera.aspect, boxCollider.size.y, boxCollider.size.z);

        //Vertical colliders
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(boxCollider.center.x + camera.orthographicSize*camera.aspect + 0.5f, boxCollider.center.y, 0);
        boxCollider.size = new Vector3(boxCollider.size.x, 2 * camera.orthographicSize, boxCollider.size.z);

        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.center = new Vector3(boxCollider.center.x - camera.orthographicSize*camera.aspect - 0.5f, boxCollider.center.y, 0);
        boxCollider.size = new Vector3(boxCollider.size.x, 2 * camera.orthographicSize, boxCollider.size.z);

    }
}
