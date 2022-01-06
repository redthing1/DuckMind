using System;
using System.Collections.Generic;
using C5;
using Ducia.Primer;

namespace Ducia.Framework.Pathfinding; 

public class Pathfinder {
    private readonly Node[,] _nodeGrid;
    private readonly IntervalHeap<Node> _openList = new IntervalHeap<Node>();

    private readonly Predicate<Point> _passable;
    private readonly Point _size;
    private readonly Point _start;
    private readonly Point _goal;

    public Pathfinder(Point size, Point start, Point goal, Predicate<Point> passable) {
        _size = size;
        _start = start;
        _goal = goal;
        _passable = passable;
        _nodeGrid = new Node[_size.X, _size.Y];
    }

    public List<Point>? findPath() {
        if (_start == _goal) return new List<Point>();

        // add the start node to the open list
        _openList.Add(_nodeGrid[_start.X, _start.Y] =
            new Node(_start.X, _start.Y, 0, Point.mhDist(_goal, _start), null!));

        var curNode = default(Node);
        while (!_openList.IsEmpty) {
            curNode = _openList.DeleteMin(); // pop the next node off the open list
            curNode.open = false;

            // check if we've reached the goal
            var dx = _goal.X - curNode.X;
            var dy = _goal.Y - curNode.Y;
            if (Math.Abs(dx) + Math.Abs(dy) <= 0) {
                // return the found path
                var path = new List<Point>();
                while (curNode.parent != null) {
                    path.Add(new Point(curNode.X, curNode.Y));
                    curNode = curNode.parent;
                }

                path.Reverse();
                return path;
            }

            // add valid neighbors to the open list
            var x = curNode.X;
            var y = curNode.Y;
            var g = curNode.g + 1;
            if (x > 0) tryOpenNode(x - 1, y, g, curNode);
            if (x < _size.X - 1) tryOpenNode(x + 1, y, g, curNode);
            if (y > 0) tryOpenNode(x, y - 1, g, curNode);
            if (y < _size.Y - 1) tryOpenNode(x, y + 1, g, curNode);
        }

        // there isn't a path to the goal
        return null;
    }

    private void tryOpenNode(int x, int y, int g, Node parent) {
        var node = _nodeGrid[x, y];
        if (node == null) {
            if (_passable(new Point(x, y))) {
                // unvisited node; add to open list
                node = _nodeGrid[x, y] = new Node(x, y, g,
                    Point.mhDist(_goal, new Point(x, y)), parent);
                _openList.Add(ref node.pqHandle, node);
            }
        } else if (node.open) {
            if (g < node.g) {
                // this route is better
                node.g = g;
                node.parent = parent;
                _openList.Replace(node.pqHandle, node); // update in the priority queue
            }
        }
    }

    private class Node : IComparable<Node> {
        public int g;
        public readonly int h;
        public bool open = true;
        public Node parent;

        public IPriorityQueueHandle<Node>? pqHandle;
        public readonly int X;
        public readonly int Y;

        public Node(int x, int y, int g, int h, Node parent) {
            X = x;
            Y = y;
            this.g = g;
            this.h = h;
            this.parent = parent;
        }

        public int f => g + h;

        public int CompareTo(Node other) {
            return f - other.f;
        }
    }
}