using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
  public void pause(){
    Time.timeScale = 0;
    gameObject.SetActive(true);
    transform.SetAsLastSibling();
  }
  public void resume(){
    Time.timeScale = 1;
    gameObject.SetActive(false);
  }
  public void menu(){
    Time.timeScale = 1;
    SceneManager.LoadScene(0);
  }
  public void restart(){
    Time.timeScale = 1;
    SceneManager.LoadScene(1);
    ButtonScript.totalscore = 0;
  }
}
