using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    [SerializeField] private float _jumpForce;

    [SerializeField] private Rigidbody _rigidBody;

    private bool _isGrounded = false;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded == true)
        {
            _isGrounded = false;
            _rigidBody.AddForce(Vector3.up * _jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Road road))
        {
            _isGrounded = true;
        }
    }

}
