using UnityEngine;

public class ScrapSpawner : MonoBehaviour
{
    public int spawnQuantity;
    [SerializeField] private GameObject[] scrapPrefs;
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
            spawnQuantity = Random.Range(1, 3);

            for (int i = 0; i < spawnQuantity; i++)
            {
                spawnLocation.x = Random.Range(-160, -70);
                spawnLocation.z = Random.Range(-11.5f, 11.5f);

                Instantiate(scrapPrefs[Random.Range(0, scrapPrefs.Length)], spawnLocation, Quaternion.identity);
            }
        }
    }
}
