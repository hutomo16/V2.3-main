using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] public ParticleSystem MovementParticle;
    [SerializeField] public ParticleSystem JumpParticle;

    [Range(0,10)]
    [SerializeField] public int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] public float dustFormationPeriod;

    [SerializeField] Rigidbody2D RB;

    float counter;
    bool IsOnGround = true;

    private void Update()
    {
        counter += Time.deltaTime;
        
        if(IsOnGround && Mathf.Abs(RB.velocity.x) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                MovementParticle.Play();
                counter = 0;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            IsOnGround = true;
            /*Debug.Log("ditanah");*/
            JumpParticle.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            IsOnGround = false;
            /*Debug.Log("terbang");*/
        }
    }

}
