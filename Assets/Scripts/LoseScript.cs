using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public void LoadMenu()
    {
        Player.ResetPlayerValues();

        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
    }
}
