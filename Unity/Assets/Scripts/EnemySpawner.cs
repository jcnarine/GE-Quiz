using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
	{
	public float min__X = -1056f, max__X = 1056;
	public int min_Size = 15, max_Size = 30;

	public Projectile asteroidPrefab;
	public GameObject enemyPrefab;
	public string sceneName;

	public TextMeshProUGUI WaveText;
	public float spawnTimer; 
	public float waveTimer;
	public int wave = 1;

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

		float pos__X = Random.Range(min__X, max__X);


		Vector3 spawnLocation = transform.position;

		spawnLocation.x = pos__X;

		if (Random.Range(0, 2) > 0)
			{
			Projectile asteroid = Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);
			int randomScale = Random.Range(min_Size, max_Size);
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

