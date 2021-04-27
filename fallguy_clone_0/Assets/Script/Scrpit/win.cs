using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Peplayon;

public class win : NetworkBehaviour
{
    [SerializeField]
    private GameObject gm;

    private GameObject currentQualified;
    private GameObject hit;
    public int playerlolos;
    public GameObject canvasDisplayQualified;
    public GameObject canvasDisplayChangeCamera;
    private bool tru;
    private bool lolos;
    public GameObject camera1;

    public float TweenTimeQualified;

    public GameObject CameraSee;
    private int spaceindex = 1;
    public Transform modeView1;
    public Transform modeView2;
    public Transform modeView3;
    private Vector3 currentModeView;

    private void Update()
    {
        if (tru)
        {
            ClientSetWin();

            Debug.Log("lolos");
        }
        if (lolos)
        {
            canvasDisplayChangeCamera.SetActive(true);
            LeanTween.scale(canvasDisplayChangeCamera, Vector3.one, TweenTimeQualified);
            if (Input.GetKeyDown(KeyCode.Space) && spaceindex == 1)
            {
                spaceindex++;

                CameraSee.SetActive(true);

                Debug.Log("changeCamera");
                currentModeView = CameraSee.transform.position;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && spaceindex == 2)
            {
                spaceindex++;
                Debug.Log("changeCamera1");
                CameraSee.transform.position = modeView1.position;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && spaceindex == 3)
            {
                spaceindex++;
                Debug.Log("changeCamera2");
                CameraSee.transform.position = modeView2.position;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && spaceindex == 4)
            {
                spaceindex++;

                CameraSee.transform.position = modeView3.position;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && spaceindex == 5)
            {
                spaceindex = 1;

                CameraSee.transform.position = currentModeView;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject != currentQualified)
            {
                tru = true;
                ClientInstance cl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
                NetworkIdentity player = other.GetComponent<NetworkIdentity>();
                NetworkIdentity item = GetComponent<NetworkIdentity>();
                cl.getauthority(item, player);
                currentQualified = other.gameObject;
            }
        }
    }

    [Client]
    public void ClientSetWin()
    {
        if (!hasAuthority) return;
        tru = false;
        GameObject localplayer = ClientScene.localPlayer.gameObject;
        NetworkIdentity get = localplayer.GetComponent<NetworkIdentity>();
        string nm = get.netId.ToString();
        Debug.Log(nm);

        CMDWin(nm);
    }

    [Command]
    public void CMDWin(string kl)
    {
        CliensRPCsetWin(kl);
    }

    [ClientRpc]
    public void CliensRPCsetWin(string hj)
    {
        playerlolos++;
        GameObject klkl = ClientScene.localPlayer.gameObject;
        NetworkIdentity ff = klkl.GetComponent<NetworkIdentity>();
        string hh = ff.netId.ToString();
        Debug.Log(hh);
        NetworkManagerPong.haha = false;
        canvasDisplayQualified.SetActive(true);
        LeanTween.scale(canvasDisplayQualified, Vector3.one, TweenTimeQualified);

        GameObject score = canvasDisplayQualified.transform.GetChild(2).gameObject;
        score.GetComponent<Text>().text = playerlolos.ToString();
        if (hh == hj)
        {
            lolos = true;
            Debug.Log("Win");

            CharacterControls cr = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControls>();

            cr.lolos();
            if (playerlolos == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            if (playerlolos == 2)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                camera1.SetActive(true);
                gm.SetActive(true);
                Debug.Log("kalah");
            }
        }
    }
}