using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : NetworkBehaviour
{
    private Transform IndicatorPointParent;
    private bool Call;
    private GameObject tt;
    private Transform gk;

    [SerializeField]
    private GameObject dust;

    private GameObject PauseMenu;

    public GameObject[] IndicatorItem;
    public GameObject dd;
    public GameObject UIeffect;
    public Text texteffect;

    private bool isPaused = false;

    [SerializeField]
    private GameObject dustlari;

    #region effect

    public void effectfaster()
    {
        texteffect.text = "LEBIH CEPAT";
    }

    public void effectslower()
    {
        texteffect.text = "MELAMBAT";
    }

    public void effectbigger()
    {
        texteffect.text = "BIGGER";
    }

    public void effecttransculent()
    {
        texteffect.text = "TEMBUS BENDA";
    }

    public void effecthighjump()
    {
        texteffect.text = "LOMPAT TINGGI";
    }

    public void EFFECTSTUNT()
    {
        texteffect.text = "TERDIAM";
    }

    public void effectrespawn()
    {
        texteffect.text = "RESPAWN";
    }

    #endregion effect

    [ClientRpc]
    public void startCutcsene()
    {
        Debug.Log("sadadffff");
        dd.SetActive(true);
        MovableObs.ready = true;
    }

    #region Set Playable Character and non

    [Command]
    public void CMDsetPlayable()
    {
        ClientRPCsetPlayable();
    }

    [ClientRpc]
    public void ClientRPCsetPlayable()
    {
        CharacterControls.cutsceneawal = false;
    }

    [Command]
    public void CMDsetnonPlayable()
    {
        ClientRPCsetnonPlayable();
    }

    [ClientRpc]
    public void ClientRPCsetnonPlayable()
    {
        CharacterControls.cutsceneawal = true;
    }

    #endregion Set Playable Character and non

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (!isPaused)
            {
                Paused();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    private void LateUpdate()
    {
    }

    #region set dust effect end Destroy

    [Client]
    public void ClientSpawnDustRun(Vector3 pos)
    {
        if (!hasAuthority) return;
        CMDSetDustRun(pos);
    }

    [Command]
    public void CMDSetDustRun(Vector3 pos2)
    {
        ClientRPCsetDustRun(pos2);
    }

    [ClientRpc]
    public void ClientRPCsetDustRun(Vector3 pos3)
    {
        Instantiate(dustlari, pos3, dustlari.transform.rotation);
    }

    [Client]
    public void ClientsetDust(Vector3 dddd)
    {
        if (!hasAuthority) return;
        CMDSetDust(dddd);
    }

    [Command]
    public void CMDSetDust(Vector3 vvv)
    {
        ClientRPCsetDust(vvv);
    }

    [ClientRpc]
    public void ClientRPCsetDust(Vector3 cccc)
    {
        /*Transform DD = GameObject.FindGameObjectWithTag("Dust").transform;*/
        Instantiate(dust, cccc, Quaternion.identity, gk);
        Debug.Log("DUST");
    }

    #endregion set dust effect end Destroy

    #region set indicator item and destroy

    [Client]
    public void ClientSetIndItem(int b, GameObject hit)
    {
        if (!hasAuthority) return;
        CMDsetIndItem(b, hit);
        Debug.Log("indicatoritem");
    }

    [Client]
    public void ClientsetDestroyIndItem(Transform v)
    {
        if (!hasAuthority) return;
        CMDsetDestroyIndItem(v);
        Debug.Log("indicatoritem");
    }

    [Command]
    public void CMDsetIndItem(int a, GameObject hit)
    {
        CilentRPCSetIndicatorItem(a, hit);
    }

    [Command]
    public void CMDsetDestroyIndItem(Transform z)
    {
        ClientRPCdestroy(z);
    }

    [ClientRpc]
    public void CilentRPCSetIndicatorItem(int index, GameObject player)
    {
        GameObject indicatorSpawn = player.transform.GetChild(6).gameObject;

        IndicatorPointParent = indicatorSpawn.transform;
        tt = Instantiate(IndicatorItem[index], IndicatorPointParent.position, Quaternion.identity, IndicatorPointParent);

        #region GAGAL

        /* if (!hasAuthority)
         {
             private Transform IndicatorItemPoint = GameObject.FindGameObjectWithTag("MultiplayerItemSpawn").transform;

     IndicatorPointParent = IndicatorItemPoint.transform;

             tt = private Instantiate(IndicatorItem[index], IndicatorPointParent.position, Quaternion.identity, IndicatorPointParent);
 }*/
    }

    /*[ClientRpc]
    public void SetIndicatorItemmm(int index)
    {
        if (isLocalPlayer) return;

        Call = true;
    }*/

    #endregion GAGAL

    [ClientRpc]
    public void ClientRPCdestroy(Transform dd)
    {
        Destroy(tt);
    }

    #endregion set indicator item and destroy

    #region PauseMenu

    private void Paused()
    {
        isPaused = true;
        Time.timeScale = 0f;
        Canvas tt = PauseMenu.GetComponent<Canvas>();
        tt.enabled = true;
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        Canvas tt = PauseMenu.GetComponent<Canvas>();
        tt.enabled = false;
    }

    #endregion PauseMenu
}