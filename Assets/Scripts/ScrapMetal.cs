using UnityEngine;
using UnityEngine.UIElements;

public class ScrapMetal : MonoBehaviour
{
    [SerializeField] private Sprite[] sprMetal;
    private GameManager gameManager;
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprMetal[Random.Range(0, sprMetal.Length)];

        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();

        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime * gameManager.gameSpeed));
    }
}
