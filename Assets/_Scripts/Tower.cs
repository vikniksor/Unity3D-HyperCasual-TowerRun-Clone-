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

}
