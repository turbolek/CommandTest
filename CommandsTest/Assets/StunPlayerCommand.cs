using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class StunPlayerCommand : Command
{
    Player _player;

    public StunPlayerCommand(Player player)
    {
        _player = player;
    }

    protected override async Task<bool> OnExecute()
    {
        _player.Stun();
        return false;
    }

    protected override void UndoSelf()
    {
        _player.RecoverStun();
    }
}
