using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


//Added Code 
using System;
using System.Runtime.InteropServices;
/// <
public class EnemySpawner : MonoBehaviour
	{
	public float min__X = -1056f, max__X = 1056;
	public int min, max;

	public Projectile asteroidPrefab;
	public GameObject enemyPrefab;
	public string sceneName;

	public TextMeshProUGUI WaveText;
	public float spawnTimer; 
	public float waveTimer;
	public int wave = 1;

	public bool useDLL=false;

	[DllImport("RandomNumber")]
	private static extern int RandomNumber(int min, int max);

	[DllImport("SameNumber")]
	private static extern int sameNumber();

	// Start is called before the first frame update
	void Start()
		{
		Invoke("SpawnEnemies", spawnTimer);
		Invoke("nextWave", waveTimer);
		}

	// Update is called once per frame
	void Update()
		{

		}

	public void changeDLL() 
		{
		useDLL = !useDLL;
		}


	void nextWave()
		{
		if (wave < 5)
			{ wave += 1; WaveText.text = "Wave "+wave;
			  Invoke("nextWave", waveTimer);
			}
		else
			{SceneManager.LoadScene("YouWon");}
		}

	void SpawnEnemies()
		{

		float pos__X = UnityEngine.Random.Range(min__X, max__X);


		Vector3 spawnLocation = transform.position;

		spawnLocation.x = pos__X;

		if (UnityEngine.Random.Range(0, 2) > 0)
			{
			Projectile asteroid = Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);

			int randomScale;

			if (useDLL) 
				{ 
				 randomScale = RandomNumber(max, min); 
				} 
			else { 
				 randomScale = sameNumber(); 
				}

			asteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
			Invoke("SpawnEnemies", spawnTimer);
			}
		else
			{
			Instantiate(enemyPrefab, spawnLocation, Quaternion.Euler(0f, -90f, 90f));
			Invoke("SpawnEnemies", spawnTimer);
			}
		}
	}

