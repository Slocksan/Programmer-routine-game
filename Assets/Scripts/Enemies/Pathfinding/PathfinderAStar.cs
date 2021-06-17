using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using UnityEngine;

namespace Enemies.Pathfinding
{
    public class PathfinderAStar
    {
        public static List<Vector2> FindPath(Vector2 topLeftBorder, Vector2 bottomRightBorder, Vector2 start, Vector2 target)
        {
            var visitedNodes = new HashSet<PathNode>();
            var toOpen = new HashSet<PathNode>();
            
            PathNode startNode = new PathNode()
            {
                Position = start,
                PrevNode = null,
                DistanceFromStart = 0,
                EstimateRemainingPathLength = Vector2.Distance(start, target)
            };
            
            toOpen.Add(startNode);
            while (toOpen.Count > 0)
            {
                var currentNode = toOpen.OrderBy(node => 
                    node.EstimateFullPathLength).First();

                if (target.x - 0.5 < currentNode.Position.x && currentNode.Position.x < target.x + 0.5 &&
                    target.y - 0.5 < currentNode.Position.y && currentNode.Position.y < target.y + 0.5)
                    return GetPathForNode(currentNode);

                toOpen.Remove(currentNode);
                visitedNodes.Add(currentNode);

                foreach (var neighbourNode in GetNeighbours(currentNode, target, topLeftBorder, bottomRightBorder))
                {
                    if (visitedNodes.Contains(neighbourNode))
                        continue;
                    
                    var sameNode = toOpen.FirstOrDefault(node =>
                        node.Position == neighbourNode.Position);
                    
                    if (sameNode == null)
                        toOpen.Add(neighbourNode);
                    else if (sameNode.DistanceFromStart > neighbourNode.DistanceFromStart)
                    {
                        sameNode.PrevNode = currentNode;
                        sameNode.DistanceFromStart = neighbourNode.DistanceFromStart;
                    }
                }
            }
            return null;
        }
        
        private static List<PathNode> GetNeighbours(PathNode pathNode, 
            Vector2 goal, Vector2 topLeftBorder, Vector2 bottomRightBorder)
        {
            var result = new List<PathNode>();
            
            Vector2[] neighbours = new Vector2[4]
            {
                pathNode.Position + Vector2.down,
                pathNode.Position + Vector2.up,
                pathNode.Position + Vector2.right,
                pathNode.Position + Vector2.left,
            };

            foreach (var point in neighbours)
            {
                if (point.x >= bottomRightBorder.x)
                    continue;
                if(point.x < topLeftBorder.x)
                    continue;
                if (point.y > topLeftBorder.y)
                    continue;
                if(point.y <= bottomRightBorder.y)
                    continue;
                
                if (Physics.CheckSphere(new Vector3(point.x, point.y), 1))
                    continue;
                
                var neighbourNode = new PathNode()
                {
                    Position = point,
                    PrevNode = pathNode,
                    DistanceFromStart = pathNode.DistanceFromStart + 1,
                    EstimateRemainingPathLength = Vector2.Distance(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }
        
        private static List<Vector2> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Vector2>();
            var currentNode = pathNode;

            var isFirst = true;
            
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.PrevNode;
            }
            result.Reverse();
            return result.Skip(1).ToList();
        }
    }
}