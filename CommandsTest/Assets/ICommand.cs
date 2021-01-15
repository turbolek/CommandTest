using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

public abstract class Command
{
    public bool Undone { get; private set; }
    public List<Command> NestedCommands = new List<Command>();
    public async Task<bool> Execute()
    {
        NestedCommands.Clear();
        Undone = false;

        return await OnExecute();
    }

    protected abstract Task<bool> OnExecute();

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
