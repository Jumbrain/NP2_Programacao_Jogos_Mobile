using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float speed = 6.5f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(1 * Time.deltaTime * speed, 0, 0));
    }
}
