using Mirror;
using Peplayon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    private GameObject dd;

    private Camera Camera2;
    private Camera Camera1;

    public GameObject CountStart;

    public Text txt;
    public AudioSource swepp;
    public AudioSource horn;
    public AudioSource countdown;

    private CharacterControls cr;
    private UI ui;
    private bool run = true;

    private void Awake()
    {
    }

    private void Update()
    {
        if (run)
        {
            dd = GameObject.FindGameObjectWithTag("PlayerCamera").gameObject;
            Camera1 = GameObject.FindGameObjectWithTag("Camera1").GetComponent<Camera>();
            Camera2 = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();
            cr = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControls>();
            run = false;
            StartCoroutine(startCutScene());
        }
    }

    private IEnumerator startCutScene()
    {
        dd.SetActive(false);
        LeanTween.move(Camera1.gameObject, new Vector3(16.2000008f, 19.8999996f, 188f), 9f);
        swepp.Play();
        yield return new WaitForSeconds(10);

        Camera1.enabled = false;
        Camera2.enabled = true;
        swepp.Stop();
        LeanTween.move(Camera2.gameObject, new Vector3(16.2000008f, 18, -179.800003f), 3f);
        swepp.Play();
        yield return new WaitForSeconds(2);

        LeanTween.move(Camera2.gameObject, new Vector3(35.7f, 23.8999996f, -200f), 1f);

        LeanTween.rotate(Camera2.gameObject, new Vector3(48.2000122f, 180f, 0), 1f);
        yield return new WaitForSeconds(1);
        swepp.Stop();
        LeanTween.move(Camera2.gameObject, new Vector3(11f, 23.8999996f, -200f), 4f);

        yield return new WaitForSeconds(3);

        yield return new WaitForSeconds(1);

        Camera2.enabled = false;
        dd.SetActive(true);
        countdown.Play();

        LeanTween.scale(CountStart, Vector3.one, 0.3f)
            .setEaseInCirc();
        yield return new WaitForSeconds(0.3f);
        txt.text = "1";
        yield return new WaitForSeconds(0.7f);
        CountStart.transform.localScale = Vector3.zero;
        LeanTween.scale(CountStart, Vector3.one, 0.3f)
             .setEaseInSine();
        yield return new WaitForSeconds(0.3f);
        txt.text = "2";
        countdown.Play();
        yield return new WaitForSeconds(0.7f);
        CountStart.transform.localScale = Vector3.zero;
        LeanTween.scale(CountStart, Vector3.one, 0.3f)
             .setEaseInQuad();
        yield return new WaitForSeconds(0.3f);

        txt.text = "3";
        countdown.Play();
        yield return new WaitForSeconds(0.7f);
        CountStart.SetActive(false);
        horn.Play();
        yield return new WaitForSeconds(1);
        playablePlayer();
    }

    private void playablePlayer()
    {
        NetworkManagerPong.haha = true;
    }
}