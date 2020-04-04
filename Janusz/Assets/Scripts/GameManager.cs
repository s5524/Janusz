using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstance;

	public PlayerMovement playerPrefab;

	private PlayerMovement playerInstance;

	public GameTimer timerPrefab;

	private GameTimer timerInstance;

	
	private void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
		if(timerInstance.timerStart < 1)
		{
			RestartGame();
		}
	}

	private void Start () {
		BeginGame();
	}
	
	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.Generate();
		playerInstance = Instantiate(playerPrefab) as PlayerMovement;
		playerInstance.SetLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates));
		playerInstance.SetCells(mazeInstance);







		timerInstance = Instantiate(timerPrefab) as GameTimer;
		
		timerInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
		timerInstance.transform.position = new Vector3(1500,700,0);
	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (playerInstance != null) {
			Destroy(playerInstance.gameObject);
		}
		if (timerInstance != null)
		{
			Destroy(timerInstance.gameObject);
		}
		BeginGame();
	}
}