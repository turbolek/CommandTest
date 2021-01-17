using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button KickBallButton;
    public Button ContinueMovementButton;

    public static UIManager Instance;

    private void Start()
    {
        Instance = this;
        KickBallButton.gameObject.SetActive(false);
        ContinueMovementButton.gameObject.SetActive(false);
    }
}
