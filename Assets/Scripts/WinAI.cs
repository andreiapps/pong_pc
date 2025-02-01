using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinAI : MonoBehaviour
{

    private string winStrDefault = "won!";
    string winStr;
    bool leftWon;

    private void Update()
    {
		// Get score and check who won(this script only applies to AI vs player mode, Win.cs applies to player vs player mode)
        int leftScore = int.Parse(GameObject.Find("LeftScore").GetComponent<Text>().text);
        int rightScore = int.Parse(GameObject.Find("RightScore").GetComponent<Text>().text);
        if (leftScore == 9 || rightScore == 9)
        {
            leftWon = leftScore >= 9;
            winStr = leftWon switch
            {
                true => "AI ",
                false => "You "
            } + winStrDefault;
            GameObject.Find("WinText").GetComponent<Text>().text = winStr;
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            Debug.Log(winStr);
        }
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
