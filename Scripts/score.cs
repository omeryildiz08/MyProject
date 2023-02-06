using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int increaseScore;
    public Text scoreText;

    private void Update()
    {
        scoreText.text = "Kill:" + increaseScore;  
    }
}


