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

    public int playerlolos;
    private bool tru;
    public GameObject camera1;

    public void Start()

    {
    }

    private void Update()
    {
        if (tru)
        {
            ClientSetWin();
            tru = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ClientInstance cl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
            NetworkIdentity player = other.GetComponent<NetworkIdentity>();
            NetworkIdentity item = GetComponent<NetworkIdentity>();
            cl.getauthority(item, player);
            tru = true;
            ;
        }
    }

    [Client]
    public void ClientSetWin()
    {
        if (!hasAuthority) return;
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

        if (hh == hj)
        {
            Debug.Log("Win");

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