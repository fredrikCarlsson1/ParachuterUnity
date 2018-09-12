using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject parachuterPrefab;
    public GameObject boat;
    public GameObject sharkPrefab;
    public LifeController lifeController;
    public PointsController pointsController;
    public GameObject gameOverHeader;
    public GameObject restartGameButton;

    public float spawnDelay = 4.0f;
    public float moveDelay = 0.54f;
    int points = 0;

    public bool continueGame = true;

    Collider2D boatCollider;

	// Use this for initialization
	void Start () {
        boatCollider = boat.GetComponentInChildren<Collider2D>();
        StartCoroutine(ParachuteSpawner());
        lifeController.RestoreAllLives();
	}

    IEnumerator ParachuteSpawner() {
        while (continueGame){
            if (moveDelay >= 0.28f)
                moveDelay = moveDelay - 0.02f;
            NewParachuter(moveDelay);
            if (spawnDelay > 1f)
                spawnDelay = spawnDelay - 0.1f;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
	
    void NewParachuter(float delay) {
        GameObject newParachuter = Instantiate(parachuterPrefab);
        ParachuterController parachuterController = newParachuter.GetComponentInChildren<ParachuterController>();
        newParachuter.GetComponentInChildren<ParachuterController>().gameManager = this;

    }

    void NewShark(int pos) {
        GameObject newShark = Instantiate(sharkPrefab);
        newShark.transform.position = newShark.GetComponent<SharkController>().positions[pos].position;
    }

    public void ParachuterSaved()
    {
        points++;
        pointsController.SetPoints(points);
    }

    public bool Crash(GameObject parachuter)
    {
        int sharkPosition = parachuter.GetComponent<ParachuterController>().sharkPosition;
        LayerMask mask = LayerMask.GetMask("Boat");
        RaycastHit2D hit = Physics2D.Raycast(parachuter.transform.position, Vector2.down, Mathf.Infinity, mask);
        
        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            NewShark(sharkPosition);
            LoseOneLife();
            return true;

        }
    }

    void LoseOneLife()
    {

        //GAME OVER
        if (!lifeController.RemoveLife())
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            continueGame = false;
            GameObject newRestartGameButton = Instantiate(restartGameButton);
            GameObject newGameOverHeader = Instantiate(gameOverHeader);

        }
    
    }


    private void OnEnable()
    {
        GameOverController.RestartGameButton += GameOverController_RestartPressed;
    }

    private void OnDisable()
    {
        GameOverController.RestartGameButton -= GameOverController_RestartPressed;
    }


    void GameOverController_RestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}




