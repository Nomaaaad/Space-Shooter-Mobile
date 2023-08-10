public class BossDeath : BossBaseState
{
    public override void RunState()
    {
        EndGameManager.Instance.possibleWin = true;
        EndGameManager.Instance.StartResolveSequence();
        gameObject.SetActive(false);
    }
}
