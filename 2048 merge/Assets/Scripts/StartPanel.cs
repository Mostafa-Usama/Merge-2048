using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
                StartCoroutine(activePanel());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start(){
    }

    IEnumerator activePanel(){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
