using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.4f;
    private Rigidbody rb;
    private float jumpHeight = 7.6f;
    public bool canJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(new Vector3(0, 0, -1 * Time.deltaTime * speed)); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime * speed)); }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    #region Colisões
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }
    #endregion
}
