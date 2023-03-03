using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    [SerializeField] private GameObject enemies3;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
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
}
