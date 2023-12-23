using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue_Button_Manager : MonoBehaviour
{
    public void OnClick_Play()
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void OnClick_ExitButton()
    {
        Application.Quit();

        Debug.Log("Quit is pressed");
    }
}
