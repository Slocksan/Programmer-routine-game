using UnityEngine;

namespace Enemies.Pathfinding
{
    public class PathNode
    {
        public Vector2 Position { get; set; }
        public float DistanceFromStart { get; set; }
        public PathNode PrevNode { get; set; }
        public float EstimateRemainingPathLength { get; set; }

        public float EstimateFullPathLength
        {
            get => DistanceFromStart + EstimateRemainingPathLength;
        }
    }
}