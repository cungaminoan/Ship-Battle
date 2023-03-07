using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner4 : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        float minX = -box.size.x / 2f;
        float maxX = box.size.x / 2f;
        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(enemies, temp, Quaternion.identity);
        StartCoroutine(SpawnEnemies());
    }
}
