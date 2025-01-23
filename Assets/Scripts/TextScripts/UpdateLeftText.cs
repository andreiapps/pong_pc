using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLeftText : MonoBehaviour
{

    public Ball ballScript;
    private int score;

    // Update is called once per frame
    void Update()
    {
        score = ballScript.leftScore;
        GetComponent<Text>().text = score.ToString();
    }
}
