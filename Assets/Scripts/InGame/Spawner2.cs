using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField] private GameObject enemies2;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies2());
    }

    IEnumerator SpawnEnemies2()
    {
        yield return new WaitForSeconds(Random.Range(4f, 8f));
        float minY = -box.size.y / 2f;
        float maxY = box.size.y / 2f;
        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(enemies2, temp, Quaternion.identity);
        StartCoroutine(SpawnEnemies2());
    }
}