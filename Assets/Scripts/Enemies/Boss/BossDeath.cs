public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        EndGameManager.Instance.StartResolveSequence();
        gameObject.SetActive(false);
    }
}
