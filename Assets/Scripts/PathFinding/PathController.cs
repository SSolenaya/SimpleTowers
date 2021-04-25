using System.Collections.Generic;
using System.Linq;
using Seka;
using Unity.Collections;
using UnityEngine;

public class PathController : Singleton<PathController> {
    public Transform startPoint; //  point for spawn enemies

    [ReadOnly] public List<PathPoint> pathPointsList = new List<PathPoint>();

    private void OnEnable() {
        pathPointsList = transform.GetComponentsInChildren<PathPoint>().ToList();
        for (int i = pathPointsList.Count - 1; i >= 0; i--) {                       //  set distance to castle for each path point
            pathPointsList[i].index = i;
            if (i == pathPointsList.Count - 1) {
                pathPointsList[i].distanceForCastle = Vector3.Distance(pathPointsList[i].transform.position, Castle.Inst.transform.position);
            } else {
                pathPointsList[i].distanceForCastle = Vector3.Distance(pathPointsList[i].transform.position, pathPointsList[i + 1].transform.position) + pathPointsList[i + 1].distanceForCastle;
            }
        }
    }

    public PathPoint GetNextPathPoint(int currentPointIndex) {
        if (currentPointIndex + 1 >= pathPointsList.Count) {
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