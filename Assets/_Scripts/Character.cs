using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private Transform _fixationPoint;

    public Transform fixationPoint => _fixationPoint;

}
