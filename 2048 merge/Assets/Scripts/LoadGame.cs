using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void load(){
        SceneManager.LoadSceneAsync(1);

    }
    public void quit(){
        Application.Quit();
    }
}
