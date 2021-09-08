using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrecker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;


    private void Update()
    {
        UpdatePosition();
    }


    private void UpdatePosition()
    {
        transform.position = _playerTower.transform.position;
        transform.localPosition += _offsetPosition;

        Vector3 lookAtPoint = _playerTower.transform.position + _offsetRotation;

        transform.LookAt(lookAtPoint);
    }
}
