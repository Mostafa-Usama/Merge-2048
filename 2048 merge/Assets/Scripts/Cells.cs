using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Cells : MonoBehaviour, IDropHandler
{
    // Start is called before the first frame update
    GameObject cell;
    public Canvas canvas;
  private void Update() {
   
   
  }
  public void OnDrop(PointerEventData d){
    if (d.pointerDrag != null){
        d.pointerDrag.transform.SetParent(transform);
        d.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        d.pointerDrag.transform.SetParent(canvas.transform);
    }
    
  }

}
