using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

[RequireComponent(typeof(Rigidbody))]
public class PathFollower : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private PathCreator _pathCreator;

    private Rigidbody _rigidBody;
    private float _distanceTravelled;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        _rigidBody.MovePosition(_pathCreator.path.GetPointAtDistance(_distanceTravelled));
    }

    private void Update()
    {
        _distanceTravelled += Time.deltaTime * _speed;

        Vector3 nextPoint = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Loop);
        nextPoint.y = transform.position.y;

        transform.LookAt(nextPoint);
        _rigidBody.MovePosition(nextPoint);
    }
}
