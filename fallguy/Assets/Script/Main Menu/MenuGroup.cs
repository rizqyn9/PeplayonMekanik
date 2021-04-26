using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuGroup : MonoBehaviour
{
    public List<MenuList> menuLists;
    public MenuList selectedMenu;
    public Image selectCharacter;
    public Image Option;
    public Image Credit;
    public TextMeshProUGUI selectCharacterText;
    public TextMeshProUGUI OptionText;
    public TextMeshProUGUI CreditText;

    public void Subscribe(MenuList list)
    {
        if (menuLists == null)
        {
            menuLists = new List<MenuList>();
        }
        menuLists.Add(list);
    }

    public void OnListEnter(MenuList list)
    {
        if (selectedMenu == null | list != selectedMenu)
        {
            if (list == menuLists[2])
            {
                selectCharacter.enabled = true;
                selectCharacterText.enabled = true;
            }
            else if (list == menuLists[0])
            {
                Option.enabled = true;
                OptionText.enabled = true;
            }
            else
            {
                Credit.enabled = true;
                CreditText.enabled = true;
            }

            Debug.Log("enter");
        }
    }

    public void OnListSelected(MenuList list)
    {
    }

    public void OnListExit(MenuList list)
    {
        selectCharacter.enabled = false;
        selectCharacterText.enabled = false;
        Option.enabled = false;
        OptionText.enabled = false;
        Credit.enabled = false;
        CreditText.enabled = false;
    }
}