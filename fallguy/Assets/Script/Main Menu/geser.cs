using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geser : MonoBehaviour
{
    public GameObject ChooseCharacter;
    public GameObject MainMenu;
    public GameObject camera;

    public GameObject selectmenu;
    public GameObject option;
    public GameObject credit;
    public GameObject play;
    public Canvas main;
    public Canvas choose;
    public float tweentime;
    private bool mainmenuv;

    public void Slide()
    {
        StartCoroutine(slidemenu());
    }

    public void BckSlide()
    {
        StartCoroutine(slidemenuBack());
    }

    private IEnumerator slidemenu()
    {
        LeanTween.scale(selectmenu, Vector3.zero, tweentime)
            .setEaseInOutSine();
        LeanTween.scale(option, Vector3.zero, tweentime)
           .setEaseInOutSine();
        LeanTween.scale(credit, Vector3.zero, tweentime)
           .setEaseInOutSine();
        LeanTween.scale(play, Vector3.zero, tweentime)
           .setEaseInOutSine();
        yield return new WaitForSeconds(tweentime);
        LeanTween.move(camera, new Vector3(26.2999992f, 1f, -10f), 1f);
        main.enabled = false;
        yield return new WaitForSeconds(1);
        choose.enabled = true;
        MainMenu.SetActive(false);

        ChooseCharacter.SetActive(true);
    }

    private IEnumerator slidemenuBack()
    {
        mainmenuv = true;
        LeanTween.move(camera, new Vector3(0f, 1f, -10f), 1f);

        choose.enabled = false;

        yield return new WaitForSeconds(1);
        main.enabled = true;

        ChooseCharacter.SetActive(false);

        MainMenu.SetActive(true);
        LeanTween.scale(selectmenu, Vector3.one, tweentime)
           .setEaseInSine();
        LeanTween.scale(option, Vector3.one, tweentime)
           .setEaseInSine();
        LeanTween.scale(credit, Vector3.one, tweentime);
        LeanTween.scale(play, Vector3.one, tweentime)
           .setEaseInSine();
        Debug.Log("hai");
    }

    private void Update()
    {
    }
}