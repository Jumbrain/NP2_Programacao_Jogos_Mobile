using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float speed = 5.4f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(1 * Time.deltaTime * speed, 0, 0));
    }
}
