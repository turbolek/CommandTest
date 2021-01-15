using UnityEngine;
using System.Collections;

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

    protected override void OnExecute()
    {
        _originalPosition = _movable.transform.position;
        MoveToPosition(_position);
    }

    protected override void UndoSelf()
    {
        MoveToPosition(_originalPosition);
    }

    private void MoveToPosition(Vector3 targetPosition)
    {
        Debug.Log("Moving " + _movable.name + " to position: " + targetPosition);
    }
}
