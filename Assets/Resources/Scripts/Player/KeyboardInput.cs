using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class KeyboardInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            _playerMovement.Jump();

        if (Input.GetKeyDown(KeyCode.A))
            _playerMovement.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D))
            _playerMovement.MoveRight();
    }
}
