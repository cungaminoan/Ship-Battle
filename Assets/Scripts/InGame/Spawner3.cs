using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    [SerializeField] private GameObject enemies3;
    [SerializeField] private GameObject enemies3_1;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies3_1());
        StartCoroutine(SpawnEnemies3());
    }

    IEnumerator SpawnEnemies3()
    {
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        float minY = -box.size.y / 2f;
        float maxY = box.size.y / 2f;
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(enemies3, temp, Quaternion.identity);
        StartCoroutine(SpawnEnemies3());
    }
    IEnumerator SpawnEnemies3_1()
    {
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        float minY = -box.size.y / 2f;
        float maxY = box.size.y / 2f;
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(enemies3_1, temp, Quaternion.identity);
        StartCoroutine(SpawnEnemies3_1());
    }
}
