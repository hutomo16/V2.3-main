using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Header("Animation Player")]
    public Animator Anim;

    private GameObject attackArea = default;
    private bool attacking = false;

    [Header("Interval Player attack")]
    [SerializeField] private float timeToAttack = 0.25f;
    [SerializeField] private float timer = 0f;

    [Header("Stamina System")]
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float AttackCost;
    public float ChargeRate;

    private Coroutine Recharge;

    [Header("Audio")]
    [SerializeField] private AudioSource AttackSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        attackArea = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && Stamina >= 25f)
        {
           
            Attack();
            Anim.SetBool("isAttacking", true);
            AudioManager.instance.PlaySFX("Attack");
            Stamina -= AttackCost;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (Recharge != null) StopCoroutine(Recharge);
            Recharge = StartCoroutine(RechargeStamina());
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                AudioManager.instance.PlaySFX("Attack");
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
                Anim.SetBool("isAttacking", false);
            }

        }
        
    }
   
    private void Attack()
    {
        AudioManager.instance.PlaySFX("Attack");
        attacking = true;
        attackArea.SetActive(attacking);
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);
        
        while(Stamina < MaxStamina)
        {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(1f);
        }
        
    }
}