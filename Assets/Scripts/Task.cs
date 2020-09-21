using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task {
    public GameObject location;
    public float duration;
    public bool isDone = false;
    public bool inProgress = false;
}
