using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    private int gameStatus = 1;
    public Transform sparkle;
    public Text myText;
    public Button continueButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.gameObject.SetActive(false);
        continueButton.onClick.AddListener(LoadPlayerScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (sparkle.GetComponent<ParticleSystem>().enableEmission && gameStatus == 1)
        {
            myText.text = "Ok, eso es malo, ¿Crees poder evitarlo?";
            continueButton.gameObject.SetActive(true);
        }
    }

    void LoadPlayerScene()
    {
        gameStatus = 2;
        myText.text = "";
        continueButton.gameObject.SetActive(false);
        SceneManager.LoadScene("PlayerScene");
    }
}
