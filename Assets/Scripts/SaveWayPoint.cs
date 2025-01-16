using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveWayPoint : MonoBehaviour
{
    List<PointData> pointDatas;

    private void Awake()
    {
        pointDatas = new List<PointData>();
    }

    private void Start()
    {
        RunSave();
    }

    private void RunSave()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("WayPoint");
        
    }
}

public class PointData
{
    public int ID;
    public Vector3 Pos;
    public List<int> NeightsID;

}