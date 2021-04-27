using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    
    int multiplier;
    TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GameObject.Find("MainCanvas").transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        multiplier = 1;
    }


    public int GetMultiplier()
    {
        return multiplier;
    }
    public TextMeshProUGUI GetTextMeshProUGUI()
    {
        return textMesh;
    }
    public void setText(string newScore) 
    {
        textMesh.text = newScore;
    }
}
