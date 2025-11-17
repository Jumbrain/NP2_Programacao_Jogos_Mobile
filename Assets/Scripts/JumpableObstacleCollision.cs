using UnityEngine;

public class JumpableObstacleCollision : MonoBehaviour
{
    private PlayerController p;
    void Start()
    {
        GameObject playerObj = GameObject.Find("Player (Lael)");
        p = playerObj.GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p.points = p.points + 500;
        }
    }
}
