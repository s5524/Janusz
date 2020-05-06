using UnityEngine;
using UnityEngine.AI;

using System.Collections;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{

	public Maze mazePrefab;

	private Maze mazeInstance;

	public PlayerMovement playerPrefab;

	private PlayerMovement playerInstance;

	public Enemy enemyPrefab;

	private Enemy enemyInstance;

	public EnemyPioter enemyPioterPrefab;

	private EnemyPioter enemyPioterInstance;

	public EnemySzwagier enemySzwagierPrefab;

	private EnemySzwagier enemySzwagierInstance;

	public GameTimer timerPrefab;

	private GameTimer timerInstance;

	public NavMeshSurface surfacePrefab;

	private NavMeshSurface surfaceInstance;

	public GameObject starterPointPrefab;

	private GameObject starterPointInstance;

	//private bool playerLost = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			RestartGame();
		}
		if (enemyInstance.EnemyCaught)
		{
			RestartGame();
		}

		enemyPioterInstance.SetTravelLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates1));
		enemySzwagierInstance.SetTravelLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates1));



		//if(timerInstance.timerStart < 1)
		//{
		//	RestartGame();
		//}
	}

	private void Start()
	{
		BeginGame();
	}

	private void BeginGame()
	{
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.Generate();


		


		var entrancePosition = mazeInstance.GetCell(new IntVector2(0, 0)).transform.position;


		playerInstance = Instantiate(playerPrefab) as PlayerMovement;
		//playerInstance.SetLocation(mazeInstance.GetCell(new IntVector2(0, 0)));
		entrancePosition.z = entrancePosition.z - 4;
		playerInstance.transform.position = entrancePosition;
		playerInstance.SetCells(mazeInstance);

		timerInstance = Instantiate(timerPrefab) as GameTimer;
		timerInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

		entrancePosition.z = entrancePosition.z - 2;
		//entrancePosition.y = entrancePosition.y + 1;
		enemyInstance = Instantiate(enemyPrefab) as Enemy;
		//enemyInstance.SetLocation(mazeInstance.GetCell(new IntVector2(15,15)));
		enemyInstance.transform.position = entrancePosition;

		enemyInstance.SetPlayer(playerInstance);
		enemyInstance.SetTimer(timerInstance);

		enemyPioterInstance = Instantiate(enemyPioterPrefab) as EnemyPioter;
		enemyPioterInstance.SetPlayer(playerInstance);
		enemyPioterInstance.SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(1, mazeInstance.size.z/2), UnityEngine.Random.Range(mazeInstance.size.x / 2, mazeInstance.size.z))));

		enemySzwagierInstance = Instantiate(enemySzwagierPrefab) as EnemySzwagier;
		enemySzwagierInstance.SetPlayer(playerInstance);
		enemySzwagierInstance.SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(mazeInstance.size.x/2,mazeInstance.size.z), UnityEngine.Random.Range(mazeInstance.size.x / 2, mazeInstance.size.z))));


		entrancePosition.z = entrancePosition.z + 1;
		//entrancePosition.y = entrancePosition.y - 1;

		starterPointInstance = Instantiate(starterPointPrefab) as GameObject;
		starterPointInstance.transform.position = entrancePosition;

		surfaceInstance = Instantiate(surfacePrefab) as NavMeshSurface;

		surfaceInstance.BuildNavMesh();

	}

	private void RestartGame()
	{
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		if (starterPointInstance != null)
		{
			Destroy(starterPointInstance.gameObject);

		}
		if (playerInstance != null)
		{
			Destroy(playerInstance.gameObject);
		}
		if (timerInstance != null)
		{
			Destroy(timerInstance.gameObject);
		}
		if (enemyInstance != null)
		{
			Destroy(enemyInstance.gameObject);
		}
		if (surfaceInstance != null)
		{
			Destroy(surfaceInstance.gameObject);
		}
		if (enemyPioterInstance != null)
		{
			Destroy(enemyPioterInstance.gameObject);
		}
		if (enemySzwagierInstance != null)
		{
			Destroy(enemySzwagierInstance.gameObject);
		}

		BeginGame();
	}
}