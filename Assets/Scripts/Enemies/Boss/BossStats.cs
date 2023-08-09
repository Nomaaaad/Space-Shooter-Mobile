using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] private BossController bossController;

    public override void HurtSequence()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dmg")) return;

        animator.SetTrigger("isDamaged");
    }

    public override void DeathSequence()
    {
        base.DeathSequence();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0,0,Random.Range(0,360)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
