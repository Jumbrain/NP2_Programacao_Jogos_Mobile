using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public int spawnQuantity;
    [SerializeField] private GameObject[] obstaclePrefs;
    [SerializeField] private Vector3 spawnLocation;
    //[SerializeField] private int randomIndex;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            spawnQuantity = Random.Range(8, 12);

            for (int i = 0; i < spawnQuantity; i++)
            {
                spawnLocation.x = Random.Range(-160, -70);
                spawnLocation.z = Random.Range(-11.5f, 11.5f);

                int randomIndex = Random.Range(0, obstaclePrefs.Length);

                if (randomIndex == 0) { spawnLocation.y = 3; }
                if (randomIndex == 1) { spawnLocation.y = 1; }

                Instantiate(obstaclePrefs[randomIndex], spawnLocation, Quaternion.identity);
            }
        }
    }
}
