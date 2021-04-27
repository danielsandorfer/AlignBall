using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class CompleteLevel : MonoBehaviour
{
    
    ScoreCounter scoreCounter;
    FillLine fillLine;
    private GameObject pauseButton;
    private GameObject nextLevelPanel;
    private RectTransform scorePanelRectTransform;
    private double pixelRatio;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelPanel = GameObject.Find("PauseMenuCanvas").transform.GetChild(1).gameObject;
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton").gameObject;
        scoreCounter = GameObject.Find("MainCanvas").transform.GetChild(1).GetComponent<ScoreCounter>();
        scorePanelRectTransform = GameObject.Find("MainCanvas").transform.GetChild(3).GetComponent<RectTransform>();
        GUI.enabled = true;
        fillLine = GameObject.Find("LineCompleteFill").GetComponent<FillLine>();
        //Position needs to be a little below camera because the collision is triggered

        pixelRatio = (double)Camera.main.pixelWidth / Camera.main.pixelHeight;
    }


    // Input must be converted to fit the android inputs

    void Update()
    {
        // For android
       // if(Input.touchCount>0 && GUI.enabled == true && (Input.touches[0].phase == TouchPhase.Began) && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))

        if (GUI.enabled == true && ((Input.GetMouseButtonDown(0)  && !EventSystem.current.IsPointerOverGameObject()) || 
            Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Began) 
            && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId)))
        {
            RouteFollower.stopRoutine();

            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));
            fillLine.transform.localPosition = new Vector3(point.x, fillLine.transform.localPosition.y, fillLine.transform.localPosition.z);
            GUI.enabled = false;
            //Freeze all balls
            GameObject[] balls = GameObject.FindGameObjectsWithTag("BallPlayer");
            foreach(GameObject b in balls)
            {
                b.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            }
            pauseButton.SetActive(false);
            //StartCoroutine(LoadLine());
            LoadLineWithForce();
        }
    }



    private void LoadLineWithForce()
    {
        Rigidbody lineRigidbody = fillLine.GetComponent<Rigidbody>();
        lineRigidbody.AddForce(0, 0, -80000);
        
    }

    public void checkLevelPass()
    {
        if (GameObject.FindGameObjectsWithTag("BallPlayer").Length == 0)
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(true);
            nextLevelPanel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            pauseButton.SetActive(true);
            print("Game Over");
            SceneManager.LoadScene("EndScene");
        }
    }

    private IEnumerator LoadLine()
    {
        Transform lineCompleteFill = fillLine.transform;
        TextMeshProUGUI score = scoreCounter.GetTextMeshProUGUI();

       
        //Start from position that is 2 times underneath the position of CompleteLine
        double CameraRectSize = this.pixelRatio * Camera.main.orthographicSize * 2;
        double boxColliderTranslate = Camera.main.GetComponent<BoxCollider>().center.y / 2;
     
        for (float ft = lineCompleteFill.transform.position.z; ft >= 0f + 10 - CameraRectSize; ft -= 100f * Time.deltaTime)
        {
            if (PauseScript.gamePaused)
            {
                Time.timeScale = 0f;
                ft += 1f;
            }
            else
            {
                Time.timeScale = 1f;
                lineCompleteFill.transform.position = new Vector3(lineCompleteFill.position.x, lineCompleteFill.position.y, ft);
            }
            yield return null;
        }
        if (GameObject.FindGameObjectsWithTag("BallPlayer").Length == 0)
        {
            Time.timeScale = 0f;
            pauseButton.SetActive(true);
            nextLevelPanel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            pauseButton.SetActive(true);
            print("Game Over");
            SceneManager.LoadScene("EndScene");
        }
        
    }
    
    
}
