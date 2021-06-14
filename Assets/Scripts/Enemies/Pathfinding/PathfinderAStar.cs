using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using UnityEngine;

namespace Enemies.Pathfinding
{
    public class PathfinderAStar
    {
        public static List<Point> FindPath(int[,] field, Vector2 start, Vector2 target)
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

                if (currentNode.Position == target)
                    return GetPathForNode(currentNode);

                toOpen.Remove(currentNode);
                visitedNodes.Add(currentNode);

                foreach (var neighbourNode in GetNeighbours(currentNode, target, field))
                {
                    // Шаг 7.
                    if (visitedNodes.Count(node => node.Position == neighbourNode.Position) > 0)
                        continue;
                    var openNode = toOpen.FirstOrDefault(node =>
                        node.Position == neighbourNode.Position);
                    // Шаг 8.
                    if (openNode == null)
                        toOpen.Add(neighbourNode);
                    else
                    if (openNode.DistanceFromStart > neighbourNode.DistanceFromStart)
                    {
                        // Шаг 9.
                        openNode.PrevNode = currentNode;
                        openNode.DistanceFromStart = neighbourNode.DistanceFromStart;
                    }
                }
            }
            // Шаг 10.
            return null;
        }
        
        private static Collection<PathNode> GetNeighbours(PathNode pathNode, 
            Vector2 goal, int[,] field)
        {
            var result = new Collection<PathNode>();
 
            // Соседними точками являются соседние по стороне клетки.
            Vector2[] neighbours = new Vector2[4]
            {
                pathNode.Position + Vector2.down,
                pathNode.Position + Vector2.up,
                pathNode.Position + Vector2.right,
                pathNode.Position + Vector2.left,
            };

            foreach (var point in neighbours)
            {
                // Проверяем, что не вышли за границы карты.
                if (point.X < 0 || point.X >= field.GetLength(0))
                    continue;
                if (point.Y < 0 || point.Y >= field.GetLength(1))
                    continue;
                // Проверяем, что по клетке можно ходить.
                if ((field[point.X, point.Y] != 0) && (field[point.X, point.Y] != 1))
                    continue;
                // Заполняем данные для точки маршрута.
                var neighbourNode = new PathNode()
                {
                    Position = point,
                    PrevNode = pathNode,
                    DistanceFromStart = pathNode.DistanceFromStart +
                                          GetDistanceBetweenNeighbours(),
                    EstimateRemainingPathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }
        
        private static List<Point> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Point>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }

        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }
    }
}