using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected int scoreValue;
    [SerializeField] protected GameObject explosionPrefab;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;

    public void TakeDamage(float damage)
    {
        health -= damage;

        HurtSequence();

        if (health <= 0)
        {
            DeathSequence();
        }
    }

    public virtual void HurtSequence()
    {

    }

    public virtual void DeathSequence()
    {
        EndGameManager.Instance.UpdateScore(scoreValue);
    }
}
