using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTower : MonoBehaviour
{
    [SerializeField] private Character _startCharacter;
    [SerializeField] private Transform _distanceChecker;
    [SerializeField] private float _fixationMaxDistance;
    [SerializeField] private BoxCollider _checkCollider;

    private List<Character> _characters;


    public UnityAction<int> CharacterAdded;


    private void Start()
    {
        _characters = new List<Character>();
        Vector3 spawnPoint = transform.position;
        _characters.Add(Instantiate(_startCharacter, spawnPoint, Quaternion.identity, transform));
        _characters[0].Run();
        CharacterAdded?.Invoke(_characters.Count);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character character))
        {
            Tower collisionTower = character.GetComponentInParent<Tower>();

            if (collisionTower != null)
            {
                List<Character> collectedCharacters = collisionTower.CollectCharacter(_distanceChecker, _fixationMaxDistance);

                if (collectedCharacters != null)
                {
                    _characters[0].StopRun();

                    for (int i = collectedCharacters.Count - 1; i >= 0; i--)
                    {
                        Character insertCharacter = collectedCharacters[i];
                        InsertCharacter(insertCharacter);
                        DisplaceCheckers(insertCharacter);
                    }

                    CharacterAdded?.Invoke(_characters.Count);
                    _characters[0].Run();
                }

                collisionTower.Break();
            }        
        }
    }

    private void InsertCharacter(Character collectedCharacter)
    {
        _characters.Insert(0, collectedCharacter);
        SetCharacterPosition(collectedCharacter);
    }

    private void SetCharacterPosition(Character character)
    {
        character.transform.parent = transform;
        character.transform.localPosition = new Vector3(0, character.transform.localPosition.y, 0);
        character.transform.rotation = Quaternion.identity;
    }

    private void DisplaceCheckers(Character character)
    {
        float displaceScale = 0.8f;
        Vector3 distanceCheckerNewPosition = _distanceChecker.position;
        distanceCheckerNewPosition.y -= character.transform.localScale.y * displaceScale;
        _distanceChecker.position = distanceCheckerNewPosition;
        _checkCollider.center = _distanceChecker.localPosition;

    }

}
