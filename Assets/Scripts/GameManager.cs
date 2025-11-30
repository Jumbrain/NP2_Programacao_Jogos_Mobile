using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameSpeed;

    [SerializeField] private static GameManager Instance;
    [SerializeField] private PlayerController playerController;

    [Header("Objetivo e HUD")]
    [SerializeField] private TextMeshProUGUI textMetal;
    [SerializeField] private TextMeshProUGUI textElectrical;
    [SerializeField] private GameObject concluido;
    public int requisitoSucataMetal;
    public int requisitoSucataEletrica;

    [Header("Fase")]
    public int faseIndex;
    public static bool fase2Liberada;
    public static bool fase3Liberada;

    void Update()
    {
        textMetal.text = "" + playerController.metaScrapAmount;
        textElectrical.text = "" + playerController.elecScrapAmount;

        if(playerController.elecScrapAmount >= requisitoSucataEletrica && playerController.metaScrapAmount >= requisitoSucataMetal)
        {
            concluido.SetActive(true);
            if (faseIndex == 1) { fase2Liberada = true; }
            if (faseIndex == 2) { fase3Liberada = true; }
        }
    }
}
