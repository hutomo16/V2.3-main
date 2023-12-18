using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class HealthPlayer : MonoBehaviour
{

    [Header("Health")]
    [SerializeField] public int maxhealth;
    public int currentHealth;
    public GameManagerScript gameManager;

    [Header("Health Sprite")]
    [SerializeField] private Sprite fullHealth;
    [SerializeField] private Sprite emptyHealth;
    [SerializeField] private Image[] HeartContainer;
    [SerializeField] private AudioSource deathSoundEffect;

    //player dead
    [HideInInspector] public bool playerisDead;

    public GameMaster gm;
    public Animator Anim;
    public bool hurt;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxhealth;
        Anim = GetComponent<Animator>();
        Damaged();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            GameOver();
        }

        if (currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i < HeartContainer.Length; i++)
        {
            if (i < currentHealth)
            {
                HeartContainer[i].sprite = fullHealth;
            }
            else
            {
                HeartContainer[i].sprite = emptyHealth;
            }
        }
    }

    public void GameOver()
    {
        AudioManager.instance.PlaySFX("Death");
        if (deathSoundEffect != null)
        {
            deathSoundEffect.Play();
        }

        playerisDead = true;

        if (gm != null && gm.LastCheckPointPos != null)
        {
            transform.position = gm.LastCheckPointPos.position;
        }

        currentHealth = maxhealth;

        if (gameManager != null)
        {
            gameObject.SetActive(false);
            gameManager.gameOver();
        }
    }

    public void heal(int amount)
    {
        /*StartCoroutine(VisualIndicator(Color.green));*/
        currentHealth += amount;
    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(VisualIndicator(Color.red));
        hurt = true;
        currentHealth -= damage;
        StartCoroutine(Damaged());
    }

    private IEnumerator Damaged()
    {
        if (hurt)
        {
            Anim.SetTrigger("isDamaged");
            yield return new WaitForSeconds(0.5f);
            Anim.ResetTrigger("isDamaged");
        }
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(VisualIndicator(Color.red));
            hurt = true;
            StartCoroutine(Damaged());
        }
        else
        {
            hurt = false;
        }
    }

}
