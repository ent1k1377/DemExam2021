using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;
    private Vector3[] _playerPoints;
    private int _currentNumberRoad = 2;

    private float _moveTime = 0.2f;
    private float _currentMoveTime;

    public SidesOfRoad _playerSidesOfRoad;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Start()
    {
        _currentMoveTime = _moveTime;
        InitilizePlayerPoints();
    }

    private void Update()
    {
        _currentMoveTime += Time.deltaTime;
        //print(_currentNumberRoad + " " + _currentMoveTime);
    }

    private int CheckOutputWithSubtraction(int currentNumber, int borderNumber = 0)
    {
        if (currentNumber - 1 > borderNumber)
            return currentNumber - 1;
        return borderNumber;
    }

    private int CheckOutputWithAddition(int currentNumber, int borderNumber = 2)
    {
        if (currentNumber + 1 < borderNumber)
            return currentNumber + 1;
        return borderNumber;
        
    }

    public void MoveLeft()
    {
        if (_currentMoveTime > _moveTime)
        {
            _currentNumberRoad = CheckOutputWithSubtraction(_currentNumberRoad);
            Vector3 fromPosition = new Vector3(_playerPoints[_currentNumberRoad].x, transform.position.y, transform.position.z);
            StartCoroutine(Move(transform.position, fromPosition));
        }
        
    }

    public void MoveRight()
    {
        if (_currentMoveTime > _moveTime)
        {
            _currentNumberRoad = CheckOutputWithAddition(_currentNumberRoad);
            Vector3 fromPosition = new Vector3(_playerPoints[_currentNumberRoad].x, transform.position.y, transform.position.z);
            StartCoroutine(Move(transform.position, fromPosition));
        }
        
    }

    private IEnumerator Move(Vector3 fromPosition, Vector3 toPosition) 
    { 
        float startTime = Time.realtimeSinceStartup; 
        float fraction = 0f; 
        while (fraction < 1f) 
        { 
            fraction = Mathf.Clamp01((Time.realtimeSinceStartup - startTime) / _moveTime);
            transform.position = Vector3.Lerp(fromPosition, toPosition, fraction); 
            yield return null; 
        } 
    }

    public void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce);
    }

    private void InitilizePlayerPoints()
    {
        _playerPoints = new Vector3[3];
        _playerPoints[0] = new Vector3(0.25f, 0, 0);
        _playerPoints[1] = new Vector3(2.40f, 0, 0);
        _playerPoints[2] = new Vector3(4.55f, 0, 0);
    }
}

public enum SidesOfRoad
{
    Left,
    Center, 
    Right
}
