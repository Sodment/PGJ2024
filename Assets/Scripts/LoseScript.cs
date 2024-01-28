using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(0);
    }
}
