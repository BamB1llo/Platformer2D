using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;

    private void Update()
    {
        transform.position = new Vector3(_player.transform.position.x - _xOffset, _player.transform.position.y - _yOffset, _player.transform.position.z - _zOffset);
    }
}
