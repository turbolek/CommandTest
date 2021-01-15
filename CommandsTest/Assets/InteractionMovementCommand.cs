﻿using UnityEngine;
using System.Collections;

public class InteractionMovementCommand : Command
{
    InteractionMovementData _data;
    Movable _movable;

    public InteractionMovementCommand(Movable movable, InteractionMovementData data)
    {
        _movable = movable;
        _data = data;
    }

    protected override void OnExecute()
    {
        foreach (InteractionMovementData.MovementTarget target in _data.Targets)
        {
            BasicMovementCommand basicMovementCommand = new BasicMovementCommand(_movable, target.Position);
            NestedCommands.Add(basicMovementCommand);
            basicMovementCommand.Execute();


        }
    }

    protected override void UndoSelf()
    {

    }
}