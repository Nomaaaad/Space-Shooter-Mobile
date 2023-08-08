using UnityEngine;

public class Shield : MonoBehaviour
{
    private int hitsToDestroy = 3;

    public bool isProtecting = false;

    private void OnEnable()
    {
        hitsToDestroy = 3;
        isProtecting = true;
    }

    private void DamageShield()
    {
        hitsToDestroy--;

        if (hitsToDestroy <= 0)
        {
            isProtecting = false;
            gameObject.SetActive(false);
        }
    }

    public void RepairShield()
    {
        hitsToDestroy = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(10000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
