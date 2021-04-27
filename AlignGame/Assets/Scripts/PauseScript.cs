using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseUI;
    GameObject scoreText;
    GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.transform.GetChild(0).gameObject;
        pauseButton = this.transform.GetChild(1).gameObject;
        
        RectTransform rectTransformPanel = this.GetComponent<RectTransform>();
        scoreText.GetComponent<RectTransform>().sizeDelta = new Vector2(rectTransformPanel.sizeDelta.x * 0.4f, rectTransformPanel.sizeDelta.y * 0.8f);
        
        pauseButton.GetComponent<RectTransform>().sizeDelta = new Vector2((float)this.GetComponent<RectTransform>().sizeDelta.y * 0.5f,
            (float)this.GetComponent<RectTransform>().sizeDelta.y * 0.5f);
        TranslateItems(scoreText, pauseButton);

        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(rectTransformPanel.rect.width, rectTransformPanel.rect.height, 800);
        boxCollider.center = new Vector3(boxCollider.center.x, -rectTransformPanel.rect.height / 2, boxCollider.center.z);
    }

    public void TranslateItems(GameObject scoreText, GameObject pauseButton)
    {
        RectTransform rectPanel = this.GetComponent<RectTransform>();
        RectTransform rectTransformScore = scoreText.GetComponent<RectTransform>();

        //scoreText.transform.localPosition = new Vector3(0, 0, 0);
        Vector3 currentTextPosition = scoreText.transform.localPosition;
    
        scoreText.transform.localPosition = new Vector3(currentTextPosition.x + rectPanel.rect.width / 5 + rectTransformScore.sizeDelta.x / 2, 
            currentTextPosition.y, currentTextPosition.z);
        Vector3 currentButtonPosition = pauseButton.transform.localPosition;
        pauseButton.transform.localPosition = new Vector3(currentButtonPosition.x - rectPanel.rect.width / 5,
            currentButtonPosition.y, currentButtonPosition.z);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        //print("Stisnuo resume");
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
    }
    public void RestartGame()
    {
        Resume();
        //Restart counter
        scoreText.GetComponent<TextMeshProUGUI>().SetText("0");
        SceneManager.LoadScene("Level1");
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
