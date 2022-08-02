using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public int score = 0;   
    void Start()
    {
        GlobalEventSystem.OnShowScore += ShowScore;
        
    }

    public void ShowScore()
    {
        score++;
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
   
}
