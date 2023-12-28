using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn_Horizontal : MonoBehaviour
{
    public Camera MainCamera;

    public GameObject asteroidPrefab;

    public float respawnTime;

    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

        StartCoroutine(asteroidWave());
    }
    private void SpawnEnemy()
    {
        GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;

        asteroid.transform.position = new Vector2(screenBounds.x, Random.Range(-screenBounds.y, screenBounds.y));

    }

    private IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
}
