using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Character _startCharacter;
    [SerializeField] private Transform _distanceChecker;
    [SerializeField] private float _fixationMaxDistance;
    [SerializeField] private BoxCollider _checkCollider;

    private List<Character> _characters;


    private void Start()
    {
        _characters = new List<Character>();
        Vector3 spawnPoint = transform.position;
        _characters.Add(Instantiate(_startCharacter, spawnPoint, Quaternion.identity, transform));
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            Tower collisionTower = character.GetComponentInParent<Tower>();

            List<Character> collectedCharacters = collisionTower.CollectCharacter(_distanceChecker, _fixationMaxDistance);

            if (collectedCharacters != null)
            {
                InsertCharacter(collectedCharacters);
            }
        }
    }

    private void InsertCharacter(List<Character> collectedCharacters)
    {
        for (int i = collectedCharacters.Count - 1; i >= 0; i--)
        {
            Character insertCharacter = collectedCharacters[i];
            _characters.Insert(0, insertCharacter);
            SetCharacterPosition(insertCharacter);
        }
    }

    private void SetCharacterPosition(Character character)
    {
        character.transform.parent = transform;
        character.transform.localPosition = new Vector3(0, character.transform.localPosition.y, 0);
        character.transform.rotation = Quaternion.identity;
    }

}
