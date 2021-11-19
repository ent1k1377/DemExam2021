using UnityEngine;

public class GameOptionsLoader : MonoBehaviour
{
    [SerializeField] private float _speedObstacle;
    [SerializeField] private float _speedDecoration;

    private void Start()
    {
        GameOptions.SpeedObstacle = _speedObstacle;
        GameOptions.SpeedDecoration = _speedDecoration;
    }
}
