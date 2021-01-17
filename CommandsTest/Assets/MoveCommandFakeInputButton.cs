using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveCommandFakeInputButton : MonoBehaviour
{
    public Button Button { get; private set; }
    [SerializeField]
    private Movable _movable;
    [SerializeField]
    private InteractionMovementData _movementData;
    public InteractionMovementData MovementData => _movementData;

    // Use this for initialization
    public void Init()
    {
        Button = GetComponent<Button>();
    }

    public Command GetCommand()
    {
        return new InteractionMovementCommand(_movable, _movementData);
    }
}
