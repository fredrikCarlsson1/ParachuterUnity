using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuterController : MonoBehaviour
{
    
    public GameManager gameManager;
    public Sprite savedParachuter;
    public Sprite deadParachuter;
    private SpriteRenderer spriteR;



    public List<GameObject> positionList = new List<GameObject>();
    GameObject randomStartingPosition;
    int currentPosition = 0;

    public float moveDelay = 0.5f;
    public int sharkPosition;

    private void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        int random = Random.Range(0, positionList.Count);
        randomStartingPosition = positionList[random];
        StartCoroutine(Move());
        sharkPosition = random;
    }

    IEnumerator Move()
    {
        while (gameManager.continueGame)
        {
            yield return new WaitForSeconds(moveDelay);
            MoveParachuter();
        }
    }

    void MoveParachuter()
    {
        currentPosition++;
        if (currentPosition >= randomStartingPosition.transform.childCount)
        {
            currentPosition = 0;
            Die();
        }

        transform.position = randomStartingPosition.transform.GetChild(currentPosition).position;


        if (randomStartingPosition.transform.GetChild(currentPosition).GetComponent<ParachutePosition>().dangerPosition)
        {
            if (gameManager.Crash(gameObject))
            {
 
                spriteR.sprite = deadParachuter;



            }
            else {
                gameManager.ParachuterSaved();
                spriteR.sprite = savedParachuter;
            }   
        }
    }


    void Die()
    {
        Destroy(transform.parent.gameObject);

    }



}
