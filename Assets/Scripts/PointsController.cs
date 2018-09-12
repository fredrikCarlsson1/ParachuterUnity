using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour {

    TextMeshPro textMesh;


	// Use this for initialization
	void Start () {
        textMesh = GetComponent<TextMeshPro>();
        textMesh.SetText("0");
	}
	
    public void SetPoints(int points)
    {
        textMesh.SetText(points.ToString());

    }

}
