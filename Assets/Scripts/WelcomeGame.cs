using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WelcomeGame : MonoBehaviour
{

    [SerializeField, TextArea(4, 6)] private string[] dialogueLine;
    [SerializeField] private GameObject[] lionImg;
    [SerializeField] private GameObject[] btn;
    [SerializeField] private GameObject[] circles;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private Vector2 scaleCircle;
    private int lineIndex;
    [SerializeField] float typingTime;

    void Start()
    {
        //Inicia sistema de dialogo
        StartDialogue();
    }

//Funcion que inicia el sistema de dialogo
    public void StartDialogue(){
        //Abilita el panel de dialogo
        dialoguePanel.SetActive(true);
        //Primer dialogo del array
        lineIndex = 0;
        //Toma como referencia el dialogo que le corresponde a cada imagen
        lionImg[lineIndex].SetActive(true);

        //Comiensa el tipeo del dialogo
        StartCoroutine(ShowLine());
    }

    public void NextDialogueLine(){
        lineIndex++;
        if(lineIndex < dialogueLine.Length){
            lionImg[lineIndex - 1].SetActive(false);
            lionImg[lineIndex].SetActive(true);
            circles[lineIndex - 1].transform.localScale = new Vector2(0.1f, 0.1f);
            circles[lineIndex].transform.localScale = new Vector2(0.15f, 0.15f);


            if(lineIndex == 2){
                btn[0].SetActive(false);
                btn[1].SetActive(false);
                btn[2].SetActive(true);
            }

            StartCoroutine(ShowLine());

        }else{
            dialoguePanel.SetActive(false);
        }
    }

    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


//Tipea el dialogo 
    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLine[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }
}
