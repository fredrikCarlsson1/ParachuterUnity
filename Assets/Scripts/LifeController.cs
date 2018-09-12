using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {
    
    [SerializeField]
    private int lives = 4;
    public float distance = 0.7f;

    private void Start()
    {
        for (int i = 1; i < lives; i++)
        {
            GameObject newLife = Instantiate(transform.GetChild(0).gameObject);
            newLife.transform.SetParent(transform);
            Vector3 pos = newLife.transform.position;
            pos.x += (i * distance);
            newLife.transform.position = pos;

        }
    }


    public bool RemoveLife()
    {

        lives--;
        transform.GetChild(lives).gameObject.SetActive(false);

        if (lives == 0)
            return false;

        return true;

    }

    public void RestoreAllLives()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

    }

}
