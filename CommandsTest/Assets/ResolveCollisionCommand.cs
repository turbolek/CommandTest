using UnityEngine;
using System.Collections;

public class ResolveCollisionCommand : Command
{
    private CollisionDetector _initiator;
    private CollisionDetector _receiver;

    public ResolveCollisionCommand(CollisionDetector initiator, CollisionDetector receiver)
    {
        _initiator = initiator;
        _receiver = receiver;
    }

    protected override void OnExecute()
    {
        Command collisionCommand = GetCollisionCommand();
        if (collisionCommand != null)
        {
            NestedCommands.Add(collisionCommand);
            collisionCommand.Execute();
        }
    }

    protected override void UndoSelf()
    {
    }

    private Command GetCollisionCommand()
    {
        if (_initiator.CollisionType == CollisionDetector.Type.Player && _receiver.CollisionType == CollisionDetector.Type.Player)
        {
            return new PlayerPlayerCollisionCommand(_initiator, _receiver);
        }

        return null;
    }
}
