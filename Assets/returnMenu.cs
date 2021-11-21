using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnMenu : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 60, 100, 50), "Menu"))
            SceneManager.LoadScene("Menu");
    }
}
