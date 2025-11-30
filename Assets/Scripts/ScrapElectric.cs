using UnityEngine;
using UnityEngine.UIElements;

public class ScrapElectric : MonoBehaviour
{
    [SerializeField] private Sprite[] sprElectric;
    private GameManager gameManager;
    private Rigidbody rb;

    private bool goUp = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprElectric[Random.Range(0, sprElectric.Length)];

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();

        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime * gameManager.gameSpeed));

        UpAndDown();
    }

    void UpAndDown()
    {
        Vector3 lowerPos = new Vector3(0, -0.5f, 0);
        Vector3 upperPos = new Vector3(0, 0.5f, 0);

        if (goUp)
        {
            rb.AddForce(upperPos, ForceMode.Force);
            if (gameObject.transform.position.y > 4.5)
            {
                goUp = false;
            }
        }
        
        if (!goUp)
        {
            rb.AddForce(lowerPos, ForceMode.Force);
            if (gameObject.transform.position.y < 3)
            {
                goUp = true;
            }
        }
    }
}
