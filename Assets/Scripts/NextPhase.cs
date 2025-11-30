using UnityEngine;
using UnityEngine.SceneManagement;

public class NextPhase : MonoBehaviour
{
    private float timer;
    private bool timerActivated;
    [SerializeField] private string proximaFase;
    private void OnEnable()
    {
        timerActivated = true;
        timer = 5f;
    }
    void Update()
    {
        if(!timerActivated) { return; }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0) { SceneManager.LoadScene(proximaFase); }
        }
    }
}
