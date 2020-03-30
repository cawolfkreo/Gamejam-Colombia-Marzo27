using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    private int gameStatus = 1;
    public Transform sparkle;
    public Text StartText;
    public Text tutorialText;
    public Button continueButtonStart;
    public Button continueButtonEditor;
    public GameObject canvasStart;
    public GameObject canvasTuto;

    private int tutorialCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        canvasStart.SetActive(false);
        continueButtonStart.onClick.AddListener(LoadPlayerScene);
        continueButtonEditor.onClick.AddListener(PassTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        if(sparkle != null)
        {
            if (sparkle.GetComponent<ParticleSystem>().enableEmission && gameStatus == 1)
            {
                StartText.text = "Ok, eso es malo, ¿Crees poder evitarlo?";
                canvasStart.SetActive(true);
            }
        }
        else
        {
            if (gameStatus == 2)
            {
                canvasStart.SetActive(false);
            }
            else if (gameStatus == 3)
            {
                var spark = GameObject.Find("Sparks");
                if(spark != null)
                {
                    if (spark.GetComponent<ParticleSystem>().enableEmission)
                    {
                        StartText.text = "Ok, eso no ha salido bien... Volvamos a editar. Utiliza la tecla R para volver al editor.";
                        canvasStart.SetActive(true);
                    }
                }
            }
        }
         

        if (SceneManager.GetActiveScene().name != "MainScene")
        {
            canvasStart.SetActive(false);
        }
    }

    void LoadPlayerScene()
    {
        if(gameStatus != 3)
        {
            gameStatus = 2;
            canvasStart.SetActive(false);

            SceneManager.LoadScene("PlayerScene");
            canvasTuto.SetActive(true);
        }else
        {
            canvasStart.SetActive(false);
        }


    }
    void PassTutorial()
    {
        if(tutorialCount == 0)
        {
            tutorialText.text = "A la derecha encontrarás un menú para seleccionar objetos que te ayudarán entre 3 categorías (Rodadores, detonadores y cortadores)," +
                "debes usar al menos un objeto de cada categoría y ten en cuenta que los objetos cortadores deben ser accionados por ti.";
            tutorialCount = 1;
        }else if(tutorialCount == 1)
        {
            tutorialText.text = "Utiliza los objetos que tienes a la mano para crear una cadena que contrarreste a la que viste anteriormente. Buena suerte!" +
                " Puedes usar las teclas A y R para moverte entre la escena principal y el editor respectivamente";
            tutorialCount = 2;
        }
        else
        {
            canvasTuto.SetActive(false);
            gameStatus = 3;
        }
    }
}
