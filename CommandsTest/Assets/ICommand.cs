using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Command
{
    public bool Undone { get; private set; }
    public List<Command> NestedCommands = new List<Command>();
    public void Execute()
    {
        NestedCommands.Clear();
        Undone = false;

        OnExecute();
    }

    protected abstract void OnExecute();

    public void Undo()
    {
        foreach (Command nestedCommand in NestedCommands)
        {
            nestedCommand.Undo();
        }

        UndoSelf();
        Undone = true;
    }

    protected abstract void UndoSelf();
}
