using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMainMenu : MonoBehaviour
{
    public bool isSpawn;
    private int CharacterSelected1;
    private int CharacterSelected2;
    private int CharacterSelected3;
    private GameObject CurrentCharacter;

    public GameObject[] PlayerPrefab;
    public Transform SpawnPoint;
    private int selectRotate;

    private void Start()
    {
    }

    private void OnEnable()
    {
        isSpawn = false;
    }

    private void Update()
    {
        CharacterSelected1 = PlayerPrefs.GetInt("CharacterOne");
        CharacterSelected2 = PlayerPrefs.GetInt("CharacterTwo");
        CharacterSelected3 = PlayerPrefs.GetInt("CharacterThree");
        if (CharacterSelected1 == 1)
        {
            SpawnCharacterMainMenu(0);
            selectRotate = 0;
            Debug.Log("karakter1");
        }
        else if (CharacterSelected2 == 1)
        {
            SpawnCharacterMainMenu(1);
            selectRotate = 1;
            Debug.Log("karakter2");
        }
        else if (CharacterSelected3 == 1)
        {
            SpawnCharacterMainMenu(2);
            selectRotate = 2;
            Debug.Log("karakter3");
        }
        else
        {
            SpawnCharacterMainMenu(0);
            selectRotate = 0;
            Debug.Log("def");
        }
    }

    private void SpawnCharacterMainMenu(int select)
    {
        if (!isSpawn)
        {
            Debug.Log("gggggg");

            Destroy(CurrentCharacter);

            isSpawn = true;

            if (CharacterSelected3 == 1)
            {
                Vector3 spawnpoint = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y - 1, SpawnPoint.position.z);
                GameObject dd = Instantiate(PlayerPrefab[select], spawnpoint, SpawnPoint.rotation);
                CurrentCharacter = dd;
            }
            else
            {
                GameObject spawn = Instantiate(PlayerPrefab[select], SpawnPoint.position, SpawnPoint.rotation);
                CurrentCharacter = spawn;
            }
        }
    }
}