using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class BasicMovementCommand : Command
{
    Movable _movable;
    Vector3 _position;
    Vector3 _originalPosition;

    public BasicMovementCommand(Movable movable, Vector3 position)
    {
        _movable = movable;
        _position = position;
    }

    protected override async Task<bool> OnExecute()
    {
        _originalPosition = _movable.transform.position;
        await MoveToPosition(_position);
        return false;
    }

    protected override void UndoSelf()
    {
        MoveToPosition(_originalPosition);
    }

    private async Task MoveToPosition(Vector3 targetPosition)
    {
        Debug.Log("Moving " + _movable.name + " to position: " + targetPosition);
    }
}
