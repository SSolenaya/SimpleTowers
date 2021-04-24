using System.Collections;
using System.Collections.Generic;
using Seka;
using UnityEngine;

public class PathController : Singleton<PathController> {
    public Transform startPoint;    //  point for spawn enemies

    [SerializeField] private List<PathPoint> pathPointsList = new List<PathPoint>();

    void OnEnable() {
        for (int i = 0; i < pathPointsList.Count; i++)
        {
            pathPointsList[i].index = i;
        }
    }

    public PathPoint GetNextPathPoint(int currentPointIndex) {
        if (currentPointIndex >= pathPointsList.Count) return null;
        return pathPointsList[currentPointIndex + 1];
    }

    public PathPoint GetPathPointByIndex( int i)
    {
        return pathPointsList[i];
    }
}
