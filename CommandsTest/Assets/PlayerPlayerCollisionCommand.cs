using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class PlayerPlayerCollisionCommand : Command
{
    CollisionDetector _initiator;
    CollisionDetector _receiver;

    bool _attackerWins = false;

    public PlayerPlayerCollisionCommand(CollisionDetector initiator, CollisionDetector receiver)
    {
        _initiator = initiator;
        _receiver = receiver;

        _attackerWins = Random.Range(0f, 1f) > 0.5f;
    }

    protected override async Task<bool> OnExecute()
    {
        Player playerToStun = GetPlayerToStun();
        if (playerToStun != null)
        {
            StunPlayerCommand stunCommand = new StunPlayerCommand(playerToStun);
            NestedCommands.Add(stunCommand);
            await stunCommand.Execute();
        }
        return !_attackerWins;
    }

    protected override void UndoSelf()
    {
    }

    private Player GetPlayerToStun()
    {
        CollisionDetector detector = _attackerWins ? _receiver : _initiator;
        return detector.GetComponent<Player>();
    }
}
