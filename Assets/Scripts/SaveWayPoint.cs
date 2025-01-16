using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;

public class SaveWayPoint : MonoBehaviour
{
    string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/SaveData.json";
    }

    private void Start()
    {
        RunSave();
    }

    private void RunSave()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("WayPoint");
        for (int i = 0; i < points.Length; i++)
        {
            PointData pointData = new PointData();

            var wayPoint = points[i].GetComponent<WayPoint>();

            pointData.ID = i;
            pointData.Pos = wayPoint.transform.position;

            pointData.NeiborsCount = wayPoint.Neibors.Count;
            if (wayPoint.Neibors.Count > 0)
            {
                foreach (var neibor in wayPoint.Neibors)
                {
                    pointData.NeightsID.Add(neibor.GetComponent<WayPoint>().ID);
                }
            }

            string jsonData = JsonConvert.SerializeObject(pointData);

            // 使用using可以實現interface的物件在使用完畢後自動釋放資源
            // 如果沒有使用using需手動釋放 writer.Close();
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(jsonData);
            }

            Debug.Log($"數據以保存至：{filePath}");
        }
    }
}

public class PointData
{
    public int ID;
    public Vector3 Pos;
    public float NeiborsCount;
    public List<int> NeightsID;

}