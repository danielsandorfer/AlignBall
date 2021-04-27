using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FillLine : MonoBehaviour
{
    private ScoreCounter scoreCounter;
    public GameObject shatterSphere;
    public CompleteLevel completeLevel;

    private void Start()
    {
        scoreCounter = GameObject.Find("MainCanvas").transform.GetChild(3).transform.GetChild(0).GetComponent<ScoreCounter>();
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, Camera.main.transform.position.z + Camera.main.orthographicSize * 2 + 3f);
        //this.transform.localScale = new Vector3(this.transform.localScale.x, Camera.main.orthographicSize, this.transform.localScale.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("BallPlayer"))
        {
            CalculatePoints(collision.gameObject);
            Instantiate(shatterSphere, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag.Equals("Finish"))
        {
            completeLevel.checkLevelPass();
        }
        
    }

    public void CalculatePoints(GameObject ball)
    {
        Int32 previousScore = Int32.Parse(scoreCounter.GetTextMeshProUGUI().text);
        double distance = Math.Abs(Math.Abs(ball.transform.position.x) - Math.Abs(this.gameObject.transform.position.x));
        if (distance <= 0.4f)
        {
            previousScore += 100;
        } else
        {
            previousScore += (int)((100f * scoreCounter.GetMultiplier() * System.Math.Exp(-0.6f * distance)));
        }

        
        scoreCounter.setText(previousScore.ToString());

    }
}
