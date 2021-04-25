using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geser : MonoBehaviour
{
    public GameObject ChooseCharacter;
    public GameObject MainMenu;
    public GameObject camera;
    public Canvas main;
    public Canvas choose;

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
        LeanTween.move(camera, new Vector3(26.2999992f, 1f, -10f), 1f);
        main.enabled = false;
        yield return new WaitForSeconds(1);
        choose.enabled = true;
        MainMenu.SetActive(false);

        ChooseCharacter.SetActive(true);
    }

    private IEnumerator slidemenuBack()
    {
        LeanTween.move(camera, new Vector3(0f, 1f, -10f), 1f);

        choose.enabled = false;

        yield return new WaitForSeconds(1);
        main.enabled = true;
        ChooseCharacter.SetActive(false);

        MainMenu.SetActive(true);
    }
}