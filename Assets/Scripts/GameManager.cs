using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed;

    [SerializeField] private PlayerController playerController;

    [SerializeField] private TextMeshProUGUI textMetal;
    [SerializeField] private TextMeshProUGUI textElectrical;
    void Start()
    {
        
    }

    void Update()
    {
        textMetal.text = "" + playerController.metaScrapAmount;
        textElectrical.text = "" + playerController.elecScrapAmount;
    }
}
