using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIScript : MonoBehaviour
{
    private static PauseUIScript single;
    private GameObject nextLevelPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (single == null)
        {
            single = this;
            DontDestroyOnLoad(gameObject);
            nextLevelPanel = this.transform.GetChild(1).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        nextLevelPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
