using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField] private GameObject enemies2;
    [SerializeField] private GameObject enemies2_1;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies2());
        StartCoroutine(SpawnEnemies2_1());
    }

    IEnumerator SpawnEnemies2()
    {
        yield return new WaitForSeconds(Random.Range(6f, 12f));
        float minX = box.bounds.min.x;
        float maxX = box.bounds.max.x;
        float minY = box.bounds.min.y;
        float maxY = box.bounds.max.y;
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        Instantiate(enemies2, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemies2());
    }

    IEnumerator SpawnEnemies2_1()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 6f));
        float minX = box.bounds.min.x;
        float maxX = box.bounds.max.x;
        float minY = box.bounds.min.y;
        float maxY = box.bounds.max.y;
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
        Instantiate(enemies2_1, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnEnemies2_1());
    }
}