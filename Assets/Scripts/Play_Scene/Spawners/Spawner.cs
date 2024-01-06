using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Collider2D spawnArea;

    public GameObject[] Enemy_Prefab;

    public float minSpawnTime = 0.25f;
    public float maxSpaawnTime = 1.0f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {

            Vector3 position = new Vector3();

            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            GameObject asteroid = Instantiate(Enemy_Prefab[Random.Range(0, Enemy_Prefab.Length)], position, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpaawnTime));
        }
    }
}
