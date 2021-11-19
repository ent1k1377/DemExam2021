using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> _obstacles;
    [SerializeField] private Vector2 _timeSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        float currentTime = 0;
        float time = Random.Range(_timeSpawn.x, _timeSpawn.y);
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
