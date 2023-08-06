using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;

    [SerializeField] private float maxHealth;

    private float health;
    private bool canPlayAnim = true;

    void Start()
    {
        health = maxHealth;
        healthFill.fillAmount = health / maxHealth;
    }

    public void TakeDamage(float damage)
    {
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
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamAnimation()
    {
        canPlayAnim = false;
        yield return new WaitForSeconds(.1f);
        canPlayAnim = true;
    }
}
