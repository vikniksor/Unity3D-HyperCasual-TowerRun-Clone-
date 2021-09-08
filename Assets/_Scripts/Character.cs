using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{

    [SerializeField] private Transform _fixationPoint;

    private Animator _animator;

    public Transform fixationPoint => _fixationPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void Run()
    {
        _animator.SetBool("isWalking", true);
    }

    public void StopRun()
    {
        _animator.SetBool("isWalking", false);
    }
}
