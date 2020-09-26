using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task {
    public Task(Transform location) {
        this.location = location; 
    }
    public Transform location;
    public float duration;
    public bool isDone = false;
    public bool inProgress = false;
    public bool enRoute = false;
}
