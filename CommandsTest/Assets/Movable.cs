using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public class Movable : MonoBehaviour
{

    public async Task Move(Vector3 targetPosition, bool instant)
    {
        if (!instant)
        {
            await MoveTween(targetPosition);
        }

        transform.position = targetPosition;
    }

    private async Task MoveTween(Vector3 targetPosition)
    {
        Debug.Log(name + "moving to: " + targetPosition);
        await Task.Delay(1000);
    }
}
