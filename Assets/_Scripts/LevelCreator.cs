using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelCreator : MonoBehaviour
{

    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Tower _towerTemplate;
    [SerializeField] private int _characterTowerCount;


    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        float roadLength = _pathCreator.path.length;
        float distanceBetweenTower = roadLength / _characterTowerCount;

        float distanceTravelled = 0;
        Vector3 spawnPoint;

        for (int i = 0; i < _characterTowerCount; i++)
        {
            distanceTravelled += distanceBetweenTower;
            spawnPoint = _pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            Instantiate(_towerTemplate, spawnPoint, Quaternion.identity);
        }
    }

}
