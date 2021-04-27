using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    private const int SCREEN_WIDTH = 1440;
    private const int SCREEN_HEIGHT = 2560;

    public Vector3 velocity;
    Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {

        ball = GetComponent<Rigidbody>();
        //double resolutionSub = System.Math.Abs(((double)WIDTH / HEIGHT) - ((double)Screen.width / Screen.height));
        //velocity = new Vector3((float)(velocity.x - velocity.x* resolutionSub), 0, (float)(velocity.z -velocity.z* resolutionSub));
        float ratio = (float)Screen.width / Screen.height;
        if(ratio < (float)SCREEN_WIDTH / SCREEN_HEIGHT)
        {
            this.transform.localPosition = new Vector3
            (this.transform.localPosition.x * 0.8f, this.transform.localPosition.y * 0.8f, this.transform.localPosition.z * 0.8f);
        }
    
        ball.velocity = new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime,velocity.z*Time.fixedDeltaTime);
        print("Brzina lopti "+ball.velocity);


    }
    
}
