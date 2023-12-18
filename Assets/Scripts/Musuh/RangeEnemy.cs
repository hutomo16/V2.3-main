using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public GameObject fireBall;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject fireParent;
    private Transform player;
    private float timer;
    private Animator anim;
    [SerializeField] private float attackCooldown;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer < lineOfSight && distanceFromPlayer > shootingRange)
        {

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            timer = 0f;
            anim.SetTrigger("attack");
            Instantiate(fireBall, fireParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }


        if (distanceFromPlayer <= shootingRange && timer < attackCooldown)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
