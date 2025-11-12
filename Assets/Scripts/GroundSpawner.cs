using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPref;
    [SerializeField] private Vector3 spawnLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            Instantiate(groundPref, spawnLocation, Quaternion.identity);
        }
    }
}
