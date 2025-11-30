using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ScrapElectric : MonoBehaviour
{
    [SerializeField] private Sprite[] sprElectric;
    private GameManager gameManager;
    private Rigidbody rb;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
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
        float speed = 2.5f;

        float newY = startPosition.y + Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
