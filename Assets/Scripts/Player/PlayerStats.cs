using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;
    [SerializeField] private Shield shield;

    [SerializeField] private float maxHealth;

    private float health;
    private bool canPlayAnim = true;
    public bool canTakeDmg = true;

    void OnEnable()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
        EndGameManager.Instance.gameOver = false;
        StartCoroutine(DamageProtection());
    }

    private void Start()
    {
        EndGameManager.Instance.RegisterPlayerStats(this);
        EndGameManager.Instance.possibleWin = false;
    }

    IEnumerator DamageProtection()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(1.5f);
        canTakeDmg = true;
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDmg) return;

        if (shield.isProtecting) return;

        health -= damage;

        healthFill.fillAmount = health / maxHealth;

        if (canPlayAnim)
        {
            animator.SetTrigger("isDamaged");
            StartCoroutine(AntiSpamAnimation());
        }

        if (health <= 0)
        {
            EndGameManager.Instance.gameOver = true;
            EndGameManager.Instance.StartResolveSequence();
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    public void AddHealth(int healAmount)
    {
        health += healAmount;
        if (healAmount >= maxHealth) health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(.1f);
        canPlayAnim = true;
    }
}
