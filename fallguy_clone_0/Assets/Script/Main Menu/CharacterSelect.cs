using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wahyu;

public class CharacterSelect : MonoBehaviour
{
    private ManagerMenu manager;

    [SerializeField]
    private selected sl;

    [SerializeField]
    private selected sl2;

    [SerializeField]
    private selected sl3;

    public GameObject ad;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Character_one()
    {
        sl.setSelected = true;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("CharacterOne", 1);
        manager.isSpawn = false;
        manager.SpawnCharacter(0);
        Debug.Log("1");
    }

    public void Character_two()
    {
        sl2.setSelected = true;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("CharacterTwo", 1);
        manager.isSpawn = false;
        manager.SpawnCharacter(1);
        Debug.Log("2");
    }

    public void Character_tree()
    {
        sl3.setSelected = true;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ManagerMenu>();
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("CharacterThree", 1);
        manager.isSpawn = false;
        manager.SpawnCharacter(2);
        Debug.Log("3");
    }
}