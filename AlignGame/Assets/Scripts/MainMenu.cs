using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject tutorialUI;
    public void Start()
    {
        Destroy(GameObject.Find("MainCanvas"));
        Destroy(GameObject.Find("PauseMenuCanvas"));
        if(PlayerPrefs.GetString("FirstStart", "false").Equals("false"))
        {
            PlayerPrefs.SetString("FirstStart", "true");
            tutorialUI.SetActive(true);
        }
        
    }
    public void Update()
    {
        if ((Input.GetMouseButtonDown(0) && GUI.enabled == true ) ||
           Input.touchCount > 0 && GUI.enabled == true && (Input.touches[0].phase == TouchPhase.Began))
        {
            tutorialUI.SetActive(false);
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Level1");
        
    }
    public void Quit()
    {
        // In Unity Editor
       // UnityEditor.EditorApplication.isPlaying = false;
        // In real app
       Application.Quit();
    }
    public void Tutorial()
    {
        tutorialUI.SetActive(true);
    }
}
