using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private GameManager gameManager;
    void Start()
    {
        if(gameObject.CompareTag("Obstacle")) { gameObject.transform.Rotate(-90, 0, 0); }
        GameObject gameManagerObj = GameObject.Find("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(new Vector3(1 * Time.deltaTime * gameManager.gameSpeed, 0, 0));
    }
}
