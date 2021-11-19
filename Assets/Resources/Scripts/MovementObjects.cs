using UnityEngine;

public class MovementObjects : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction = new Vector3(0, 0, 1);

    private void Start()
    {
        if (TryGetComponent(out Obstacle _))
            _speed = GameOptions.SpeedObstacle;
        else
            _speed = GameOptions.SpeedDecoration;

    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * _speed * Time.deltaTime * -1);
    }
}
