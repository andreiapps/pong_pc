using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuButtons : MonoBehaviour
{
	// Show the game mode selection menu
    public void ShowGameModeSelector()
    {
        gameObject.SetActive(false);
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
		// There might have been a better way to load the screen that iterating through all GameObjects and checking if it's the one I want, for example by using a tag, but honestly I don't care
        foreach (GameObject obj in objects)
        {
            if (obj.name == "PlayerModeCanvas")
            {
                obj.SetActive(true);
                break;
            }
        }
    }
	// Quit, very self explanatory
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
		// Check the selected game mode and load the correct scene
        Dropdown dropdown_component = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        string option = dropdown_component.options[dropdown_component.value].text;
        string scene = option switch
        {
            "Player vs Player" => "PlayerVsPlayer",
            "Computer vs Player" => "PlayerVsAI"
        };
        SceneManager.LoadScene(scene);
    }
}
