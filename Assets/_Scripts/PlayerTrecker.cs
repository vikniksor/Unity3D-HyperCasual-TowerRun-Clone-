using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrecker : MonoBehaviour
{
    [SerializeField] private PlayerTower _playerTower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _offsetPosition;
    [SerializeField] private Vector3 _offsetRotation;

    private Vector3 _targetOffsetPosition;


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
        _offsetPosition = Vector3.MoveTowards(_offsetPosition, _targetOffsetPosition, _moveSpeed * Time.deltaTime);
    }


    private void UpdatePosition()
    {

        //_targetPosition = _playerTower.transform.position + _offsetPosition;

        transform.position = _playerTower.transform.position;
        transform.localPosition += _offsetPosition;

        Vector3 lookAtPoint = _playerTower.transform.position + _offsetRotation;

        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, _targetPosition, _moveSpeed * Time.deltaTime);

        transform.LookAt(lookAtPoint);
    }

    private void OnCharacterAdded(int count)
    {
        _targetOffsetPosition = _offsetPosition + (Vector3.up + Vector3.back) * count;
        UpdatePosition();
    }
}
