using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine.UI;

public class PlayerBallCollisionCommand : Command
{
    Button _shootButton;
    Button _continueMovementButton;
    Player _player;
    Ball _ball;

    private bool _commandChosen = false;
    private bool _shootButtonChosen = false;

    public PlayerBallCollisionCommand(CollisionDetector player, CollisionDetector ball)
    {
        _shootButton = UIManager.Instance.KickBallButton;
        _continueMovementButton = UIManager.Instance.ContinueMovementButton;
        _player = player.GetComponent<Player>();
        _ball = ball.GetComponent<Ball>();

        _continueMovementButton.onClick.AddListener(delegate { _commandChosen = true; _shootButton.gameObject.SetActive(false); _continueMovementButton.gameObject.SetActive(false); });
        _shootButton.onClick.AddListener(delegate { _commandChosen = true; _shootButtonChosen = true; _shootButton.gameObject.SetActive(false); _continueMovementButton.gameObject.SetActive(false); });
    }

    protected override async Task<bool> OnExecute()
    {
        if (!_commandChosen)
        {
            _shootButton.gameObject.SetActive(true);
            _continueMovementButton.gameObject.SetActive(true);
        }

        while (!_commandChosen)
        {
            await Task.Yield();
        }

        Command chosenCommand = null;

        if (_shootButtonChosen)
        {
            chosenCommand = new KickBallCommand(_player, _ball, _player.transform.position + Vector3.right * 10f);
        }
        else
        {
            chosenCommand = new CaptureBallCommand(_player, _ball);
        }

        NestedCommands.Add(chosenCommand);
        return await chosenCommand.Execute();
    }

    protected override void UndoSelf()
    {

    }

}
