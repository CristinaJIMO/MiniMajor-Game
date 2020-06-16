using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2 : MonoBehaviour {
    
  private Touch touch;
  private float speedModifier;
  public float mapLimit = 0f;
    
  void Start() {
      
    speedModifier = 0.01f;

  }

  void FixedUpdate() {
       
    if (Input.touchCount > 0) {
            
      Touch touch = Input.GetTouch(0);
            
        if ( touch.phase == TouchPhase.Moved) {
              
          float newPosition = Mathf.Clamp(transform.position.x + touch.deltaPosition.x  * speedModifier, -mapLimit, mapLimit);

          transform.position = new Vector2 (newPosition,transform.position.y);
          
        }
    }
        
  }
}
