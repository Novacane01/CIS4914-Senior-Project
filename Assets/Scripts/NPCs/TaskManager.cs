using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.NPCs
{
    public class TaskManager : MonoBehaviour
    {
        public static TaskManager instance = null;

        public List<Transform> houses;
        public List<Transform> buildings;
        public uint tasksPerPerson = 0;

        //public uint totalNumTasks = Statistics.tasksPerDay * population;
        public uint tasksDuration = 0;
        public uint tasksCompleted = 0;

        System.Random rnd = new System.Random();

        private void Awake() {
            if (instance == null) {
                instance = this;
            }
            else if (instance != this) {
                Destroy(gameObject);
            }
        }

        void Start() {
            tasksPerPerson = Statistics.tasksPerDay;
            tasksDuration = Statistics.taskDuration;
        }

        public Transform assignHouse() {
            return houses[rnd.Next(houses.Count)];
        }

        public Task[] assignTasks() {
            List<Task> currentTasks = new List<Task>();

            Transform previousTransform = buildings[rnd.Next(buildings.Count)].Find("Door").transform;
            Transform currentTransform = previousTransform;

            currentTasks.Add(new Task(currentTransform));

            Debug.Log("Tasks per person: " + tasksPerPerson);

            for (int j = 1; j < tasksPerPerson; j++) {
                while (previousTransform.position.Equals(currentTransform.position)) {
                    previousTransform = currentTransform;
                    currentTransform = buildings[rnd.Next(buildings.Count)].Find("Door").transform;
                }

                currentTasks.Add(new Task(currentTransform));
                previousTransform = currentTransform;
            }
        
            return currentTasks.ToArray();
        }
    }
}