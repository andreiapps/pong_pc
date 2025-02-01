using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isMenuOpened = false;
    public Rigidbody2D ballRb;
    public Vector2 prevVelocity;
    public void ToggleMenu(GameObject menu)
    {
		// Toggle the menu and save the velocity for when the game resumes
        isMenuOpened = menu.activeSelf;
        menu.SetActive(!isMenuOpened);
        if (!isMenuOpened)
        {
            prevVelocity = ballRb.velocity;
            ballRb.velocity = Vector2.zero;
        }
        else
        {
            ballRb.velocity = prevVelocity;
        }
    }
    public void Resume(GameObject menu)
    {
        menu.SetActive(false);
        ballRb.velocity = prevVelocity;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
