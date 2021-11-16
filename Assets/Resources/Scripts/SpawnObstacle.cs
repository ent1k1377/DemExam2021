using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private List<Obstacle> _obstacles;

    private void Start()
    {
        StartCoroutine(SpawnQ());
    }

    private IEnumerator SpawnQ()
    {
        float currentTime = 0;
        float time = 0;
        time = Random.Range(1, 2);
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= time)
            {
                currentTime = 0;
                time = Random.Range(1, 10);
                Instantiate(_obstacles[Random.Range(0, _obstacles.Count)], transform.position, Quaternion.identity, transform);
            }
            yield return null;
        }
        
    }
}
