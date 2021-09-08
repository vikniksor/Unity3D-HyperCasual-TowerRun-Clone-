using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrecker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;


    private void OnEnable()
    {
        _playerTower.CharacterAdded += OnCharacterAdded;
    }

    private void OnDisable()
    {
        _playerTower.CharacterAdded -= OnCharacterAdded;
    }


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

    private void OnCharacterAdded(int count)
    {
        _offsetPosition += (Vector3.up + Vector3.back) * count;
        UpdatePosition();
    }
}
