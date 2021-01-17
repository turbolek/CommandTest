using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class CaptureBallCommand : Command
{
    Player _player;
    Ball _ball;
    public CaptureBallCommand(Player player, Ball ball)
    {
        _player = player;
        _ball = ball;
    }

    protected override async Task<bool> OnExecute()
    {
        _ball.gameObject.SetActive(false);
        return false;
    }

    protected override void UndoSelf()
    {
    }
}
