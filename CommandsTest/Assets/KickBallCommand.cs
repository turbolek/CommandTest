using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class KickBallCommand : Command
{
    Player _player;
    Ball _ball;
    Vector3 _ballTargetPosition;

    public KickBallCommand(Player player, Ball ball, Vector3 ballTargetPosition)
    {
        _player = player;
        _ball = ball;
        _ballTargetPosition = ballTargetPosition;
    }

    protected override async Task<bool> OnExecute()
    {
        Movable ballMovable = _ball.GetComponent<Movable>();
        BasicMovementCommand ballMoveCommand = new BasicMovementCommand(ballMovable, _ballTargetPosition);
        NestedCommands.Add(ballMoveCommand);
        return await ballMoveCommand.Execute();
    }

    protected override void UndoSelf()
    {

    }
}
