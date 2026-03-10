using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGate : MonoBehaviour
{
    private bool _isInRange;

    private PlayerBase _player;

    private void Update()
    {
        if (_player != null && _player.PressedInteract() && _isInRange)
        {
            Debug.Log("Enter the dungeon!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstant.GameTag.PLAYER))
        {
            _isInRange = true;
            _player = other.gameObject.GetComponent<PlayerBase>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(GameConstant.GameTag.PLAYER))
        {
            _isInRange = false;
            _player = null;
        }
    }
}
