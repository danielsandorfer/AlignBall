using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu pauseMenu;

    private void Start()
    {
        if (pauseMenu == null)
        {
            GetComponent<RectTransform>().localScale = new Vector3
                (Camera.main.orthographicSize* 2 * Camera.main.aspect, 2*Camera.main.orthographicSize, 1f);
            pauseMenu = this;
            //5f is the scale of box collider on camera
            double panelScale = (double)(Camera.main.orthographicSize * 2) / 5f;
            GameObject scorePanel = gameObject.transform.GetChild(3).gameObject;
            scorePanel.GetComponent<RectTransform>().sizeDelta = new Vector2
                (gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<RectTransform>().sizeDelta.y / (float)panelScale);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }



     
    /*
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void Quit()
    {
        // In Unity Editor
        //UnityEditor.EditorApplication.isPlaying = false;
        // In real app
        Application.Quit();
    }*/
}
