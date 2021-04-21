﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wahyu
{
    public class ManagerMenu : MonoBehaviour
    {
        #region Variable

        public Transform selectedCharacter;
        public GameObject[] CharacterPrefab;
        public bool isSpawn = false;

        private int selectedcharacterone;
        private int selectedcharactertwo;
        private int selectedcharactertree;
        private GameObject currentCharacter;

        #endregion Variable

        #region MonoBehaviourCallBack

        // Start is called before the first frame update
        private void Start()
        {
            selectedcharacterone = PlayerPrefs.GetInt("CharacterOne");
            selectedcharactertwo = PlayerPrefs.GetInt("CharacterTwo");
            selectedcharactertree = PlayerPrefs.GetInt("CharacterTree");
        }

        // Update is called once per frame
        private void Update()
        {
            if (selectedcharacterone == 1)
            {
                SpawnCharacter(0);
            }
            else if (selectedcharactertwo == 1)
            {
                SpawnCharacter(1);
            }
            else if (selectedcharactertree == 1)
            {
                SpawnCharacter(2);
            }
            else
            {
                SpawnCharacter(0);
            }
        }

        #endregion MonoBehaviourCallBack

        #region Public Method

        public void SpawnCharacter(int index)
        {
            if (!isSpawn)
            {
                if (currentCharacter != null)
                {
                    Destroy(currentCharacter);
                }

                isSpawn = true;

                if (index == 2)
                {
                    Vector3 spawnpoint = new Vector3(selectedCharacter.position.x, selectedCharacter.position.y - 1, selectedCharacter.position.z);
                    GameObject dd = Instantiate(CharacterPrefab[index], spawnpoint, selectedCharacter.rotation, selectedCharacter);
                    currentCharacter = dd;
                }
                else
                {
                    GameObject aa = Instantiate(CharacterPrefab[index], selectedCharacter.position, selectedCharacter.rotation, selectedCharacter);
                    currentCharacter = aa;
                }
            }
        }

        #endregion Public Method
    }
}