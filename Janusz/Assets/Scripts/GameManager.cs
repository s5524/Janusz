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


	public Inventory inventoryPrefab;

	private Inventory inventoryInstance;

	public HUD HUDPrefab;
	private HUD HUDInstance;

	public Item[] itemsPrefab;
	private Item[] itemsInstances;

	public GameObject completeLevelUi;
	public GameObject gameOverUi;

	private int size = 50;
	private int time = 5;
	public void CompleteLevel()
	{
		completeLevelUi.SetActive(true);

	}

	public void GameOver()
	{
		size = 20;
		time = 30;

		gameOverUi.SetActive(true);


	}
	public void GoNext()
	{
		size += 5;
		time += 20;
		RestartGame();
		completeLevelUi.SetActive(false);

	}

	//private bool playerLost = false;

	private void Update()
	{
		Debug.Log("3 " + playerInstance.transform.position);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			RestartGame();
		}
		if (enemyInstance.EnemyCaught)
		{
			GameOver();
		}
		enemyPioterInstance.SetTravelLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates1));
		enemySzwagierInstance.SetTravelLocation(mazeInstance.GetCell(mazeInstance.RandomCoordinates1));

		if (inventoryInstance.itemsColected() == 3)
		{
			CompleteLevel();
		}
		Debug.Log("4 " + playerInstance.transform.position);

		//if(timerInstance.timerStart < 1)
		//{
		//	RestartGame();
		//}
	}

	private void Start()
	{
		Wait();
		RestartGame();
		//Debug.Log("begin");
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(03f);
		
	}
		private void BeginGame()
	{
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.size = new IntVector2(size, size);
		mazeInstance.Generate();


		


		var entrancePosition = mazeInstance.GetCell(new IntVector2(0, 0)).transform.position;


		inventoryInstance = Instantiate(inventoryPrefab) as Inventory;
		HUDInstance = Instantiate(HUDPrefab) as HUD;

		HUDInstance.Inventory = inventoryInstance;


		playerInstance = Instantiate(playerPrefab) as PlayerMovement;
		//playerInstance.SetLocation(mazeInstance.GetCell(new IntVector2(0, 0)));
		entrancePosition.z = entrancePosition.z - 4;
		playerInstance.transform.position = entrancePosition;

		playerInstance.inventory = inventoryInstance;
		playerInstance.SetCells(mazeInstance);
		Debug.Log("1 " + playerInstance.transform.position);

		timerInstance = Instantiate(timerPrefab) as GameTimer;
		timerInstance.timerStart = time;
		timerInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
		HUDInstance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

		entrancePosition.z = entrancePosition.z - 2;
		//entrancePosition.y = entrancePosition.y + 1;
		enemyInstance = Instantiate(enemyPrefab) as Enemy;
		//enemyInstance.SetLocation(mazeInstance.GetCell(new IntVector2(15,15)));
		enemyInstance.transform.position = entrancePosition;

		enemyInstance.SetPlayer(playerInstance);
		enemyInstance.SetTimer(timerInstance);

		enemyPioterInstance = Instantiate(enemyPioterPrefab) as EnemyPioter;
		enemyPioterInstance.SetPlayer(playerInstance);
		enemyPioterInstance.SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(1, mazeInstance.size.x/2), UnityEngine.Random.Range(mazeInstance.size.z / 2, mazeInstance.size.z))));

		enemySzwagierInstance = Instantiate(enemySzwagierPrefab) as EnemySzwagier;
		enemySzwagierInstance.SetPlayer(playerInstance);
		enemySzwagierInstance.SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(mazeInstance.size.x/2,mazeInstance.size.x), UnityEngine.Random.Range(mazeInstance.size.z / 2, mazeInstance.size.z))));


		entrancePosition.z = entrancePosition.z + .5f;
		//entrancePosition.y = entrancePosition.y - 1;

		starterPointInstance = Instantiate(starterPointPrefab) as GameObject;
		starterPointInstance.transform.position = entrancePosition;

		surfaceInstance = Instantiate(surfacePrefab) as NavMeshSurface;

		surfaceInstance.BuildNavMesh();

		itemsInstances = new Item[itemsPrefab.Length]; 
		for (int i = 0; i < itemsPrefab.Length; i++)
		{
			itemsInstances[i] = Instantiate(itemsPrefab[i]) as Item;
			itemsInstances[i].SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(5, mazeInstance.size.x), UnityEngine.Random.Range(5, mazeInstance.size.z))));
				//SetLocation(mazeInstance.GetCell(new IntVector2(UnityEngine.Random.Range(mazeInstance.size.x / 2, mazeInstance.size.z), UnityEngine.Random.Range(mazeInstance.size.x / 2, mazeInstance.size.z))));

		}

		//foreach (var item in itemsPrefab)
		//{
		//	itemI
		//}

		Debug.Log("2 " + playerInstance.transform.position);

	}

	public void RestartGame()
	{
		StopAllCoroutines();
		if (mazeInstance != null)
		{
			Destroy(mazeInstance.gameObject);

		}
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
		if(itemsInstances != null)
		{
			foreach (var item in itemsInstances)
			{
				Destroy(item.gameObject);
			}
		}
		if (HUDInstance != null)
		{
			Destroy(HUDInstance.gameObject);
		}
		if(inventoryInstance != null)
		{
			Destroy(inventoryInstance.gameObject);
		}
		BeginGame();
	}
}