using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour {

    public GameManager gameManager;
    public List<Transform> positions = new List<Transform>();

private void Start()
    {
 
        RemoveShark();
    }

    void RemoveShark() {
        if (gameManager.continueGame){
            Destroy(gameObject, 1.0f);
        }

    }



}
