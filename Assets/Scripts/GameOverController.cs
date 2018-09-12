using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {

    public delegate void RestartPressed();
    public static event RestartPressed RestartGameButton;


	
	// Update is called once per frame
	void Update () {
        #if UNITY_IOS


        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                LayerMask mask = LayerMask.GetMask("GameOver");
                RaycastHit2D hit = Physics2D.Raycast(
                    transform.position, Vector2.zero, Mathf.Infinity, mask);
                if (RestartGameButton != null && hit.collider != null && hit.collider.gameObject == gameObject)
                    RestartGameButton();
              
            }
        }



#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {

            //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("GameOver");
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (RestartGameButton != null && hit.collider != null && hit.collider.gameObject == gameObject)
                RestartGameButton();
        }

#endif
	}


}
