using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatController : MonoBehaviour {

    Image boatImage;
    public Sprite leftBoat;
    public Sprite rightBoat;
    public GameManager gameManager;

    SpriteRenderer spriteRenderer;

    public List<Transform> positions = new List<Transform>();

    int currentPosition = 2;


	// Use this for initialization  
	void Start () {
        transform.position = positions[currentPosition].position;
        boatImage = GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	

    private void OnEnable()
    {
        ButtonsController.OnLeftPressed += Buttons_OnLeftPressed;
        ButtonsController.OnRightPressed += Buttons_OnRightPressed;
    }

    private void OnDisable()
    {
        ButtonsController.OnLeftPressed -= Buttons_OnLeftPressed;
        ButtonsController.OnRightPressed -= Buttons_OnRightPressed;
    }



    void Buttons_OnRightPressed()
    {
        if (currentPosition < positions.Count-1 && gameManager.continueGame ){
            spriteRenderer.flipX = true;// .sprite = rightBoat;
            currentPosition++;
            transform.position = positions[currentPosition].transform.position;
        }
    }


    void Buttons_OnLeftPressed()
    {
        
        if (currentPosition > 0 && gameManager.continueGame)
        {
            //spriteRenderer.sprite = leftBoat;
            spriteRenderer.flipX = false;
            currentPosition--;
            transform.position = positions[currentPosition].transform.position;
        }
    }



}
