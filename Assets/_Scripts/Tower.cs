using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Vector2Int _characterInTowerRange;
    [SerializeField] private Character[] _characters;

    private List<Character> _characterInTower;


    private void Start()
    {
        _characterInTower = new List<Character>();
        int characterInTowerCount = Random.Range(_characterInTowerRange.x, _characterInTowerRange.y);
        SpawnCharacters(characterInTowerCount);
    }


    private void SpawnCharacters(int characterCount)
    {
        Vector3 spawnPoint = transform.position;

        for (int i = 0; i < characterCount; i++)
        {
            Character spawnedCharacter = _characters[Random.Range(0, _characters.Length)];

            _characterInTower.Add(Instantiate(spawnedCharacter, spawnPoint, Quaternion.identity, transform));

            _characterInTower[i].transform.localPosition = new Vector3(0, _characterInTower[i].transform.localPosition.y, 0);

            spawnPoint = _characterInTower[i].fixationPoint.position;
        }
    }

    public List<Character> CollectCharacter(Transform distanceChecker, float fixationMaxDistance)
    {
        for (int i = 0; i < _characterInTower.Count; i++)
        {
            float distanceBetweenPoints = CheckDistanceY(distanceChecker, _characterInTower[i].fixationPoint.transform);

            if (distanceBetweenPoints < fixationMaxDistance)
            {
                List<Character> collectedCharacters = _characterInTower.GetRange(0, i + 1);
                _characterInTower.RemoveRange(0, i + 1);
                return collectedCharacters;
            }
        }
        return null;
    }

    private float CheckDistanceY(Transform distanceChecker, Transform characterFixationPoint)
    {
        Vector3 distanceCheckerY = new Vector3(0, distanceChecker.position.y, 0);
        Vector3 characterFixationPointY = new Vector3(0, characterFixationPoint.position.y, 0);
        return Vector3.Distance(distanceCheckerY, characterFixationPointY);
    }

}
