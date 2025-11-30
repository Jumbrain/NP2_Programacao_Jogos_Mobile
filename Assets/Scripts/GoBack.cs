using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("Seletor Fase");
        }
    }
}
