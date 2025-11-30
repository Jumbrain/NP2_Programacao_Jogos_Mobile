using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeletorFase : MonoBehaviour
{

    [SerializeField] private Button fase2Button;
    [SerializeField] private Button fase3Button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.fase2Liberada == false) { fase2Button.interactable = false; } else { fase2Button.interactable = true; }
        if (GameManager.fase3Liberada == false) { fase3Button.interactable = false; } else { fase3Button.interactable = true; }
    }

    public void SelecionarFase(string nomeFase)
    {
        SceneManager.LoadScene(nomeFase);
    }
}
