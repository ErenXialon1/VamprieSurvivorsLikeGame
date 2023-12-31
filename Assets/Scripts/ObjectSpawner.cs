using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // Kullanılacak prefabların listesi
    public float spawnRadius = 10f;
    public int numberOfObjects = 20;

    private void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawnedObject = Instantiate(prefabs[randomIndex], randomPosition, Quaternion.identity);
             // Collider bileşeni ekleyin
            spawnedObject.tag = "Obstacle"; // Etiketi ayarlayın
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Karakterin çarpıştığı engelle durmasını sağlayın
            Rigidbody2D characterRigidbody = GetComponent<Rigidbody2D>();
            characterRigidbody.velocity = Vector2.zero;
        }
    }
}
