using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler // implement interfaces
{   
RectTransform rect;
CanvasGroup cg;
public Sprite [] btns; // button images 
Rigidbody2D rb;
bool started = false; // constraints
public bool dropped = false;
Text score;
public static int totalscore=0;
public AudioClip pop;
public int times=0;
public static bool lose = false;
public bool ready = false;
private void Start() {
    rect = GetComponent<RectTransform>();
    cg = GetComponent<CanvasGroup>();
    rb = GetComponent<Rigidbody2D>();
    StartCoroutine(setParent());
    StartCoroutine(Ready());
    score = GameObject.FindWithTag("score").GetComponent<Text>();
    
    
    
}

private void Update() {
  if (started){
    transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.3f,2.41f),
    Mathf.Clamp(transform.position.y,-2.9f,2.5f),
    transform.position.z);
}  

}
  public void OnBeginDrag(PointerEventData d){
        started= true;
        cg.blocksRaycasts = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        times =0; // reset number of times merged
        dropped= false; // waiting for the object to be dropped
        
        
        
  }
  public void OnDrag(PointerEventData d){
    rect.anchoredPosition += d.delta;
       /* mp = Input.mousePosition;
        mp.x = Mathf.Clamp(mp.x,-2.3f,2.4f);
        mp.y = Mathf.Clamp(mp.y,-2.9f,2.5f);
      */
      ready = false; // cant trigger lose panel
  }
  public void OnEndDrag(PointerEventData d){
    cg.blocksRaycasts = true;
   rb.bodyType = RigidbodyType2D.Dynamic;
    dropped = true; // dropped
    StartCoroutine(Ready());
  
  }
  

private void OnCollisionStay2D(Collision2D other) {
  if (gameObject.tag == other.gameObject.tag){
    AudioSource.PlayClipAtPoint(pop,transform.position);
    times++; // number of times the holded block is merged  
    other.gameObject.GetComponent<ButtonScript>().times++; // same to make sure not to instatiate noe row
    int value =int.Parse(other.gameObject.tag) * 2;
    totalscore+= value;
    score.text = "Score: " + totalscore;

    string tag = value.ToString();
    other.gameObject.tag  = tag;
    other.gameObject.transform.GetChild(0).GetComponent<Text>().text = tag;
 
    switch(value){
    case 4:
    other.gameObject.GetComponent<Image>().sprite = btns[1];
    break;
    case 8:
    other.gameObject.GetComponent<Image>().sprite = btns[2];
    break;
    case 16:
    other.gameObject.GetComponent<Image>().sprite = btns[3];
    break;
    case 32:
    other.gameObject.GetComponent<Image>().sprite = btns[4];
    break;
    case 64:
    other.gameObject.GetComponent<Image>().sprite = btns[5];
    break;
    case 128:
    other.gameObject.GetComponent<Image>().sprite = btns[6];
    break;
    case 256:
    other.gameObject.GetComponent<Image>().sprite = btns[7];
    break;
    case 512:
    other.gameObject.GetComponent<Image>().sprite = btns[8];
    break;
    case 1024:
    other.gameObject.GetComponent<Image>().sprite = btns[9];
    
    break;
    case 2048:
    other.gameObject.GetComponent<Image>().sprite = btns[10];
    PlayerPrefs.SetInt("highScore",Mathf.Max(PlayerPrefs.GetInt("highScore"),totalscore));
    totalscore = 0;
    break;
    

    }
    Destroy(gameObject);
    
    }
    
  }
  
  
    

private void OnCollisionEnter2D(Collision2D other) {
  if (dropped/*block you dropped*/ && gameObject.tag != other.gameObject.tag && times == 0/*didnt merge before*/){
    Debug.Log(other.gameObject.tag + "+" + gameObject.tag);
    times = 1; // reset
    GameObject.FindWithTag("Player").GetComponent<GameManger>().newRow = true;
    dropped = false; // reset
  }
}

private void OnTriggerStay2D(Collider2D other) {
  if (other.gameObject.tag =="lose" && ready/*wait for instatitatating and not dragged*/){
    Debug.Log("Triggered");
      lose = true;
  }
}

IEnumerator setParent(){
  yield return new WaitForSeconds(.1f);
  transform.SetParent(GameObject.FindWithTag("Finish").transform);
  

}
IEnumerator Ready(){
   yield return new WaitForSeconds(0.8f);
   ready = true; // block now dropped 
}
  public void resetScore(){
    totalscore = 0;
  }

}