using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DustTrigger : NetworkBehaviour
{
    public bool Grounded;
    public bool CoroutineAllowed;
    public AudioSource jump;
    public AudioSource walk;

    private Transform self;
    private CharacterControls cr;

    private GameObject sfx;
    private float musicVolume = 1f;
    private Slider mm;

    [SerializeField]
    private GameObject dustlari;

    private void Start()
    {
        self = transform;
        cr = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControls>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Debug.Log("GROUNDED");
            jump.Play();

            /*
                        NetworkIdentity player = GameObject.FindGameObjectWithTag("Player").GetComponent<NetworkIdentity>();
                        NetworkIdentity dust = GetComponent<NetworkIdentity>();
                        ClientInstance cl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
                        cl.changeAuthory(dust, player);*/

            UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
            ui.ClientsetDust(transform.position);
            Grounded = true;
            CoroutineAllowed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Ground"))
        {
            Grounded = false;
            CoroutineAllowed = false;
        }
    }

    private void Update()
    {
        /* sfx = GameObject.FindGameObjectWithTag("dd");
         mm = sfx.GetComponent<Slider>();*/
        jump.volume = musicVolume;
        walk.volume = musicVolume;
        if (Grounded && cr.blend > 0 && CoroutineAllowed)
        {
            walk.Play();
            Debug.Log("run");
            StartCoroutine("spawndust");
            CoroutineAllowed = false;
        }
        if (cr.blend <= 0 || !Grounded)
        {
            walk.Stop();

            StopCoroutine("spawndust");
            CoroutineAllowed = true;
        }
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        /*  musicVolume = mm.value;*/
    }

    private IEnumerator spawndust()
    {
        while (Grounded)
        {
            UI ui = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UI>();
            ui.ClientSpawnDustRun(transform.position);
            yield return new WaitForSeconds(0.25f);
        }
    }
}