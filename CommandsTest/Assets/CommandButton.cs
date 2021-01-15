using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommandButton : MonoBehaviour
{
    public Button Button { get; private set; }
    [SerializeField]
    private InteractionMovementData _movementData;
    public InteractionMovementData MovementData => _movementData;
    public Command Command;

    // Use this for initialization
    public void Init()
    {
        Button = GetComponent<Button>();
    }
}
