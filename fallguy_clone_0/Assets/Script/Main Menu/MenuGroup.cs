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
    public float TweenTime;
    public float TweenTimeHUD;
    private int index;

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
                index = 1;
                StartCoroutine(animMenuStart(1));
            }
            else if (list == menuLists[0])
            {
                index = 2;
                StartCoroutine(animMenuStart(1));
            }
            else
            {
                index = 3;
                StartCoroutine(animMenuStart(1));
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

    #region effect menu

    private IEnumerator animMenuStart(int i)
    {
        if (index == 1)
        {
            selectCharacter.enabled = true;
            LeanTween.value(selectCharacter.gameObject, 0.1f, 1, TweenTime)
                .setOnUpdate((value) =>
                {
                    selectCharacter.fillAmount = value;
                });
            yield return new WaitForSeconds(TweenTime);
            selectCharacterText.enabled = true;
        }
        else if (index == 2)
        {
            Option.enabled = true;

            LeanTween.value(Option.gameObject, 0.1f, 1, TweenTime)
                .setOnUpdate((value) =>
                {
                    Option.fillAmount = value;
                });
            yield return new WaitForSeconds(TweenTime);
            OptionText.enabled = true;
        }
        else if (index == 3)
        {
            Credit.enabled = true;

            LeanTween.value(Credit.gameObject, 0.1f, 1, TweenTime)
                .setOnUpdate((value) =>
                {
                    Credit.fillAmount = value;
                });
            yield return new WaitForSeconds(TweenTime);
            CreditText.enabled = true;
        }
    }

    #endregion effect menu

    public void animOnPointerExit()
    {
        StopAllCoroutines();
    }

    #region TweenActiveHUD

    public void setActive(GameObject hud)
    {
        Debug.Log("active");
        hud.SetActive(true);
        LeanTween.scale(hud.gameObject, Vector3.one, TweenTimeHUD)
            .setEaseInOutQuint();
    }

    public void setActivefalse(GameObject hud)
    {
        Debug.Log("false");

        LeanTween.scale(hud.gameObject, Vector3.zero, TweenTimeHUD)
            .setEaseInOutQuint();
        hud.SetActive(false);
    }

    #endregion TweenActiveHUD
}