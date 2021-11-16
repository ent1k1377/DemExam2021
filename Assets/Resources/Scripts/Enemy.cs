using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime * -1);
    }
}
