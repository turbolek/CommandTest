using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Movable _playerMovable;

    [SerializeField]
    private Button _undoButton;
    [SerializeField]
    private Button _redoButton;

    [SerializeField]
    private CommandButton[] _commandButtons;

    private List<Command> _executedCommands = new List<Command>();

    // Start is called before the first frame update
    void Start()
    {
        InitButtons();
        AssignCommands();
    }

    private void AssignCommands()
    {
        foreach (CommandButton button in _commandButtons)
        {
            InteractionMovementData data = button.MovementData;
            InteractionMovementCommand movementCommand = new InteractionMovementCommand(_playerMovable, data);
            button.Command = movementCommand;
        }
    }

    private void InitButtons()
    {
        _undoButton.onClick.AddListener(UndoLastCommand);
        _redoButton.onClick.AddListener(RedoLastCoomand);

        foreach (CommandButton button in _commandButtons)
        {
            button.Init();
            button.Button.onClick.AddListener(delegate { ExecuteCommand(button.Command); });
        }
    }

    private void ExecuteCommand(Command command)
    {
        ClearUndoneCommands();
        _executedCommands.Add(command);
        command.Execute();
    }

    private void ClearUndoneCommands()
    {
        for (int i = _executedCommands.Count - 1; i >= 0; i--)
        {
            Command command = _executedCommands[i];
            if (command.Undone)
            {
                _executedCommands.Remove(command);
            }
        }
    }

    private void UndoLastCommand()
    {
        for (int i = _executedCommands.Count - 1; i >= 0; i--)
        {
            if (!_executedCommands[i].Undone)
            {
                _executedCommands[i].Undo();
            }
        }
    }

    private void RedoLastCoomand()
    {
        for (int i = 0; i < _executedCommands.Count; i++)
        {
            if (_executedCommands[i].Undone)
            {
                _executedCommands[i].Execute();
            }
        }
    }
}
