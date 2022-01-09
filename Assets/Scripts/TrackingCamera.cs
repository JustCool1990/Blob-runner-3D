using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _followSpeed;


    private void Start()
    {
        transform.position = SetStartPosition(_player, _offset);
    }

    private void Update()
    {
        Follow(_player, _offset);
    }

    private Vector3 SetStartPosition(Player player, Vector3 offset)
    {
        return new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
    }

    private void Follow(Player player, Vector3 offset)
    {
        Vector3 target = SetStartPosition(player, offset);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, _followSpeed * Time.deltaTime);
        transform.position = currentPosition;
    }
}