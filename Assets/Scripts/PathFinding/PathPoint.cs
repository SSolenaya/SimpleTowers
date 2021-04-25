using UnityEngine;

public class PathPoint : MonoBehaviour {
    public int index;
    public float disForCastle;//SALT

    public void Start() {
        GetComponent<MeshRenderer>().enabled = false;
    }
}