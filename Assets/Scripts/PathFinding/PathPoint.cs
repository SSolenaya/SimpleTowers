using UnityEngine;

public class PathPoint : MonoBehaviour {
    public int index;
    public float distanceForCastle;

    public void Start() {
        GetComponent<MeshRenderer>().enabled = false;
    }
}