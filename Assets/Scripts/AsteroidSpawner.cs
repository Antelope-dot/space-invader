using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRate = 2.0f;
    public float trajectoryVariance = 15.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 10.0f;
    public Asteroid asteroidprefab;
    public bool startSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn),this.spawnRate, this.spawnRate );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        if (startSpawning == true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                //Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
                //Vector3 spawnPoint = this.transform.position + spawnDirection;


                Vector3 spawnPoint = new Vector3(Random.Range(-8, 8), 5);

                float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(this.asteroidprefab, spawnPoint, rotation);
                asteroid.size = Random.Range(asteroid.minsize, asteroid.maxSize);
                //asteroid.SetTrajectory(rotation * -spawnDirection);
                asteroid.SetTrajectory(rotation * Vector3.down);
            }
        }
    }
}
