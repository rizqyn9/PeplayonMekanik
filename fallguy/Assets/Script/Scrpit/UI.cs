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

    public GameObject[] IndicatorItem;
    public GameObject dd;
    public GameObject UIeffect;
    public GameObject parent;
    public Text texteffect;

    public float TweenTimeItemInd;

    [SerializeField]
    private GameObject dustlari;

    #region effect

    public void effectfaster()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "LEBIH CEPAT";
    }

    public void effectslower()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "MELAMBAT";
    }

    public void effectbigger()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "BIGGER";
    }

    public void effecttransculent()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "TEMBUS BENDA";
    }

    public void effecthighjump()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "LOMPAT TINGGI";
    }

    public void EFFECTSTUNT()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
        texteffect.text = "TERDIAM";
    }

    public void effectrespawn()
    {
        LeanTween.scale(parent, Vector3.one, TweenTimeItemInd);
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
}