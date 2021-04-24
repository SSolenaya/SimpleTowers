﻿using System.Collections.Generic;
using System.Linq;
using Seka;
using Unity.Collections;
using UnityEngine;

public class PathController : Singleton<PathController> {
    public Transform startPoint; //  point for spawn enemies

    [ReadOnly] public List<PathPoint> pathPointsList = new List<PathPoint>();

    private void OnEnable() {
        pathPointsList = transform.GetComponentsInChildren<PathPoint>().ToList();
        for (int i = 0; i < pathPointsList.Count; i++) {
            pathPointsList[i].index = i;
        }
    }

    public PathPoint GetNextPathPoint(int currentPointIndex) {
        if (currentPointIndex  + 1 >= pathPointsList.Count) {
            return null;
        }

        return pathPointsList[currentPointIndex + 1];
    }

    public PathPoint GetPathPointByIndex(int i) {
        return pathPointsList[i];
    }

    public PathPoint GetCastlePoint() {
        return pathPointsList[pathPointsList.Count - 1];
    }
}