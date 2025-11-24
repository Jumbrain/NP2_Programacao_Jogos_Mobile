using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerPos;
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (new Vector3(xAxis, playerPos.position.y + yAxis, playerPos.position.z));
    }
}
