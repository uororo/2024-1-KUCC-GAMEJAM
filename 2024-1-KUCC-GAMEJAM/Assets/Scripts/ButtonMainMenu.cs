using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
