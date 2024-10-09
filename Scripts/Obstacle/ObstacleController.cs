using UnityEngine;

namespace Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] public ObstacleGenerator _obstacleGenerator;

        void Update()
        {
            transform.Translate(Vector2.left * _obstacleGenerator.currentSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("NextLine"))
            {
                _obstacleGenerator.RandomizeObstacleGeneration();
            }
        
            if (collision.gameObject.CompareTag("FinishLine"))
            {
                Destroy(this.gameObject);
            }
        }
    
    }
}
