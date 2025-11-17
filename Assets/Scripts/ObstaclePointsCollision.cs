using UnityEngine;

public class ObstaclePointsCollision : MonoBehaviour
{
    private PlayerController p;
    private void Start()
    {
        GameObject playerObj = GameObject.Find("Player (Lael)");
        p = playerObj.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            p.points = p.points + 250;
        }
    }
}
