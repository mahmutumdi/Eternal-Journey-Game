using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacle
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] List<GameObject> _obstacles;

        public float minSpeed;
        public float maxSpeed;
        public float currentSpeed;
        public float speedMultiplier;

        private void Awake()
        {
            currentSpeed = minSpeed;
            GenerateObstacle();
        }

        public void RandomizeObstacleGeneration()
        {
            float randomWait = Random.Range(0.1f, 1.2f);
            Invoke(nameof(GenerateObstacle), randomWait);
        }

        private void GenerateObstacle()
        {
            int randomIndex = Random.Range(0, _obstacles.Count);
            GameObject selectedObstacle = _obstacles[randomIndex];
        
            GameObject obstacleInstance = Instantiate(selectedObstacle, transform.position, transform.rotation, transform);
            obstacleInstance.GetComponent<ObstacleController>()._obstacleGenerator = this;
        }
    
        void Update()
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += speedMultiplier;
            }
        }
    }
}
