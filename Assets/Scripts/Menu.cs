using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    private int index;
    private bool nextPage;
    public Image img;
    [SerializeField] private Sprite[] historinha;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject quadrinhos;

    public void Update()
    {
        img.sprite = historinha[index];

        if(nextPage && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            index++;
        }

        if(index >= 5) { SceneManager.LoadScene("Seleção de fases"); }
    }

    public void ProxPag()
    {
        button.SetActive(false);
        quadrinhos.SetActive(true);
        nextPage = true;
        index++;
    }
}
