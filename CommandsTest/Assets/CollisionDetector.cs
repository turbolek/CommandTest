using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour
{
    public enum Type
    {
        Default,
        Obstacle,
        Player,
        Ball
    }

    public Type CollisionType;
}
