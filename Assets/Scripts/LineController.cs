using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;

    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] points) {
        lr.positionCount = points.Length;
        this.points = points;
    }

    // Update is called once per frame
    private void Update() {
        for (int i = 0; i < points.Length; i++) {
            lr.SetPosition(i, points[i].position);
        }
    }


    // Start is called before the first frame update
    void Start() { }

}
