using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Manager : MonoBehaviour
{
    public void OnClick_RePlay_Button()
    {
        SceneManager.LoadScene("Play_Scene");
    }
}
