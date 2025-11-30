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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip quadrinho1;
    [SerializeField] private AudioClip quadrinho2;
    [SerializeField] private AudioClip quadrinho3;
    [SerializeField] private AudioClip quadrinho4;

    public void Update()
    {
        img.sprite = historinha[index];

        if(nextPage && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            index++;
            if (index == 2) { audioSource.PlayOneShot(quadrinho2); }
            if (index == 3) { audioSource.PlayOneShot(quadrinho3); }
            if (index == 4) { audioSource.PlayOneShot(quadrinho4); }
        }

        if (index >= 5) { SceneManager.LoadScene("Seletor Fase"); }
    }

    public void ProxPag()
    {
        button.SetActive(false);
        quadrinhos.SetActive(true);
        nextPage = true;
        index++;

        if (index == 1) { audioSource.PlayOneShot(quadrinho1); }
    }
}
