using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int metaScrapAmount;
    public int elecScrapAmount;
    public int points;

    [SerializeField] private Animator LaelAnim;
    [SerializeField] private Animator BoardAnim;

    public Vector3 force;
    private float jumpHeight = 7.8f;
    private bool canJump = false;

    private float pcSpeed = 6.4f;
    private float mobileSpeed = 1.4f;
    private float deadZone = 0.3f;
    private bool autoCalibrateOnStart = true;

    private Rigidbody rb;
    Vector2 calib;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (autoCalibrateOnStart) { calib = ReadTiltXY(); }
    }

    public void CallibrateNow() => calib = ReadTiltXY();

    void FixedUpdate()
    {
        #region ACELEROMETRO CELULAR
        Vector2 tilt = ReadTiltXY().normalized - calib;

        if (tilt.magnitude < deadZone)
        {
            tilt = Vector2.zero;
        }

        #region Diversão Infinita PIADA

        //if (tilt.x < 0 && tilt.magnitude > deadZone) { transform.Rotate(0, -15, 0); }

        //if (tilt.x > 0 && tilt.magnitude > deadZone) { transform.Rotate(0, 15, 0); }

        #endregion

        force = new Vector3(0, 0, tilt.x) * mobileSpeed;

        if (force.z > 0)
        {
            LaelAnim.SetBool("TurnRight", true); BoardAnim.SetBool("TurnRight", true); LaelAnim.SetBool("TurnLeft", false); BoardAnim.SetBool("TurnLeft", false);
        }
        if (force.z < 0)
        { 
            LaelAnim.SetBool("TurnLeft", true); BoardAnim.SetBool("TurnLeft", true); LaelAnim.SetBool("TurnRight", false); BoardAnim.SetBool("TurnRight", false);
        }

        if (force.z > 0.5f) { force.z = 0.5f; }
        if(force.z < -0.5f) { force.z = -0.5f; }

        rb.AddForce(force, ForceMode.Impulse);
        #endregion

        #region configurações pra jogar no computador

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(0, 0, horizontal);
        rb.MovePosition(transform.position + move * pcSpeed * Time.deltaTime);

        if (horizontal > 0)
        {
            LaelAnim.SetBool("TurnRight", true); BoardAnim.SetBool("TurnRight", true); LaelAnim.SetBool("TurnLeft", false); BoardAnim.SetBool("TurnLeft", false);
        }

        if (horizontal < 0)
        {
            LaelAnim.SetBool("TurnRight", false); BoardAnim.SetBool("TurnRight", false); LaelAnim.SetBool("TurnLeft", true); BoardAnim.SetBool("TurnLeft", true);
        }

        #region Diversão Infinita PIADA
        //if (horizontal < 0) { transform.Rotate(0, -15, 0); }
        //if (horizontal > 0) { transform.Rotate(0, 15, 0); }
        #endregion

        #endregion
    }

    void Update()
    {

        //PC Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            canJump = false;
            LaelAnim.SetBool("Jumped", true);
            BoardAnim.SetBool("Jumped", true);
        }

        //Mobile Jump
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began && canJump)
            {
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                canJump = false;
                LaelAnim.SetBool("Jumped", true);
                BoardAnim.SetBool("Jumped", true);
            }
        }
    }

    Vector2 ReadTiltXY()
    {
        Vector3 acceleration = Input.acceleration;

        return new Vector2(acceleration.x, acceleration.y);
    }



    #region Colisões
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
            LaelAnim.SetBool("Jumped", false);
            BoardAnim.SetBool("Jumped", false);
        }

        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("JumpableObstacle"))
        {
            SceneManager.LoadScene("Derrota");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ElectricScrap"))
        {
            elecScrapAmount++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MetalScrap"))
        {
            metaScrapAmount++;
            Destroy(other.gameObject);
        }
    }
    #endregion
}
