using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InteractionMovementData
{
    [System.Serializable]
    public struct MovementTarget
    {
        public Vector3 Position;
        public CollisionDetector CollisionDetector;

        public MovementTarget(Vector3 position, CollisionDetector detector)
        {
            Position = position;
            CollisionDetector = detector;
        }
    }

    public List<MovementTarget> Targets;
}
