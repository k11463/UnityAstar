using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePathNodeState
{
    None = -1,
    Open = 0,
    Close
}

public class PathNode
{
    public List<PathNode> Neibors;

    public Vector3 Pos;
    public PathNode Parent;
    public float CostFromStart;
    public float CostFromEnd;
    public float TotalCost;
}
