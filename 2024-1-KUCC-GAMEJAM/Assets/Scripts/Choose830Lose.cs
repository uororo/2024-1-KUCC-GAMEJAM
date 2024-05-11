using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SceneManagement
using UnityEngine.SceneManagement;

public class Choose830Lose : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Sad_Ending_Lose");
    }
}