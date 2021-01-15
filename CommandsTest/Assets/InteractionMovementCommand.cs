using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class InteractionMovementCommand : Command
{
    InteractionMovementData _data;
    Movable _movable;

    public InteractionMovementCommand(Movable movable, InteractionMovementData data)
    {
        _movable = movable;
        _data = data;
    }

    protected override async Task<bool> OnExecute()
    {
        bool terminate = false;

        foreach (InteractionMovementData.MovementTarget target in _data.Targets)
        {
            BasicMovementCommand basicMovementCommand = new BasicMovementCommand(_movable, target.Position);
            NestedCommands.Add(basicMovementCommand);
            terminate |= await basicMovementCommand.Execute();

            if (target.CollisionDetector != null)
            {
                ResolveCollisionCommand collisionCommand = new ResolveCollisionCommand(_movable.GetComponent<CollisionDetector>(), target.CollisionDetector);
                NestedCommands.Add(collisionCommand);
                terminate |= await collisionCommand.Execute();
            }

            if (terminate)
            {
                Debug.Log("InteractionMovement Command terminated");
                break;
            }
        }

        return terminate;
    }

    protected override void UndoSelf()
    {

    }
}
