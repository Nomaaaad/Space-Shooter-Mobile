using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    protected Camera mainCamera;

    protected float maxLeft;
    protected float maxRight;
    protected float maxDown;
    protected float maxUp;

    protected BossController bossController;

    private void Awake()
    {
        bossController = GetComponent<BossController>();
        mainCamera = Camera.main;
    }

    protected virtual void Start()
    {
        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(.3f, 0)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(.7f, 0)).x;

        maxDown = mainCamera.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
        maxUp = mainCamera.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;
    }

    public virtual void RunState()
    {

    }

    public virtual void StopState()
    {
        StopAllCoroutines();
    }
}
