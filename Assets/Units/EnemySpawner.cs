using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemy;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    void Spawn()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-15.0f, 15.0f);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Enemy _enemy = Instantiate(this.enemy, spawnPoint, rotation);
            _enemy.size = Random.Range(_enemy.minSize, _enemy.maxSize);
            _enemy.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
