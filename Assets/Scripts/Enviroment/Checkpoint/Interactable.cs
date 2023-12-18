using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool isRange;

    private GameMaster gm;

    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   GameMaster.instance.setLastCheckPoint(transform);
                Anim.SetBool("LightsOn", true);
                EventManager.TriggerEvent("Checkpoint");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            isRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRange = false;
        }
    }

    private void OnEnable()
    {
        EventManager.StartListening("Checkpoint", Checkcheckpoint);
    }

    private void OnDisable()
    {
        EventManager.StopListening("Checkpoint", Checkcheckpoint);
    }

    public void Checkcheckpoint()
    {
        if (GameMaster.instance.LastCheckPointPos != transform)
        {
            Anim.SetBool("LightsOn", false);
        }
        
    }
}
