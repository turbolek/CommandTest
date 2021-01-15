using UnityEngine;
using System.Collections;

public class StunPlayerCommand : Command
{
    Player _player;

    public StunPlayerCommand(Player player)
    {
        _player = player;
    }

    protected override void OnExecute()
    {
        _player.Stun();
    }

    protected override void UndoSelf()
    {
        _player.RecoverStun();
    }
}
