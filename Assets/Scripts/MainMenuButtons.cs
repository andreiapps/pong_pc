using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuButtons : MonoBehaviour
{
    public void ShowGameModeSelector()
    {
        gameObject.SetActive(false);
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (obj.name == "PlayerModeCanvas")
            {
                obj.SetActive(true);
                break;
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
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
