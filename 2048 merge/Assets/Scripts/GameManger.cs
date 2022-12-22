using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{ 
    
    public GameObject btn;
    public Transform [] cells;
    public Sprite [] btns;
    public bool newRow = false;
    int x,y,z,a,b,c,d,e,f,g;
    public GameObject winPanel,pauseButton,losePanel;
    bool bigger = false;

    // Start is called before the first frame update
    void Awake()
    {   
    

        for (int i = 36 ; i < cells.Length; i++){
            float chance = Random.value;
            if (chance < 0.4){
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "2";
            x.GetComponent<Image>().sprite = btns[0];
            x.transform.GetChild(0).GetComponent<Text>().text = "2";
        }
        else if (chance < 0.7){
            GameObject x = Instantiate(btn,cells[i]);
            x.tag = "4";
            x.GetComponent<Image>().sprite = btns[1];
            x.transform.GetChild(0).GetComponent<Text>().text = "4";
        }
         else if (chance < 0.9) {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "8";
            x.GetComponent<Image>().sprite = btns[2];
            x.transform.GetChild(0).GetComponent<Text>().text = "8";
        }
        else {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "16";
            x.GetComponent<Image>().sprite = btns[3];
            x.transform.GetChild(0).GetComponent<Text>().text = "16";
        }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (ButtonScript.lose){
            losePanel.SetActive(true);
            Time.timeScale = 0;
            losePanel.transform.SetAsLastSibling();
            ButtonScript.lose = false;
        }

        if (GameObject.FindWithTag("128")){
            winPanel.SetActive(true);
            Time.timeScale = 0;
            winPanel.transform.SetAsLastSibling();
           pauseButton.GetComponent<Button>().interactable = false;

        }

        x = GameObject.FindGameObjectsWithTag("2").Length;
        y = GameObject.FindGameObjectsWithTag("4").Length;
        z = GameObject.FindGameObjectsWithTag("8").Length;
        a = GameObject.FindGameObjectsWithTag("16").Length;
        b = GameObject.FindGameObjectsWithTag("32").Length;
        c = GameObject.FindGameObjectsWithTag("64").Length;    
        d = GameObject.FindGameObjectsWithTag("128").Length;
        e = GameObject.FindGameObjectsWithTag("256").Length;    
        f = GameObject.FindGameObjectsWithTag("512").Length;
        g = GameObject.FindGameObjectsWithTag("1024").Length; 
        if (e != 0){
            bigger = true;
        }

        if (x<=1 && y<=1 && z<=1  && a<=1 && b<=1 && c<=1 && d <=1 && e <= 1 && f <= 1 && g<= 1)  
        {
            newRow = true;
        }

        if (newRow && !bigger){
            for (int i = 0 ; i < 6; i++){
            float chance = Random.value;
            if (chance < 0.4){
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "2";
            x.GetComponent<Image>().sprite = btns[0];
            x.transform.GetChild(0).GetComponent<Text>().text = "2";
        }
        else if (chance < 0.7){
            GameObject x = Instantiate(btn,cells[i]);
            x.tag = "4";
            x.GetComponent<Image>().sprite = btns[1];
            x.transform.GetChild(0).GetComponent<Text>().text = "4";
        }
         else if (chance < 0.9) {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "8";
            x.GetComponent<Image>().sprite = btns[2];
            x.transform.GetChild(0).GetComponent<Text>().text = "8";
        }
        else {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "16";
            x.GetComponent<Image>().sprite = btns[3];
            x.transform.GetChild(0).GetComponent<Text>().text = "16";
        }

        }

        newRow=false;
        
        }
        if (newRow && bigger){
            for (int i = 0 ; i < 6; i++){
            float chance = Random.value;
            if (chance < 0.4){
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "4";
            x.GetComponent<Image>().sprite = btns[1];
            x.transform.GetChild(0).GetComponent<Text>().text = "4";
        }
        else if (chance < 0.7){
            GameObject x = Instantiate(btn,cells[i]);
            x.tag = "8";
            x.GetComponent<Image>().sprite = btns[2];
            x.transform.GetChild(0).GetComponent<Text>().text = "8";
        }
         else if (chance < 0.9) {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "16";
            x.GetComponent<Image>().sprite = btns[3];
            x.transform.GetChild(0).GetComponent<Text>().text = "16";
        }
        else {
            GameObject x =Instantiate(btn,cells[i]);
            x.tag = "32";
            x.GetComponent<Image>().sprite = btns[4];
            x.transform.GetChild(0).GetComponent<Text>().text = "32";
        }

        }

        newRow=false;
        
        }

    }
}
