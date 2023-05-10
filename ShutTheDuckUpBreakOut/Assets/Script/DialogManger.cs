using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManger : MonoBehaviour
{

    public TMP_Text DialogText;
    public TMP_Text nameText; 
    public GameObject dialogBox;


    private Queue <string> Sentence;

    void Start()
    {
        Sentence = new Queue<string>();
    }   

    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            DisplayNextSentence();
        }
    }


    public void StartDialog(Dialog dialog)
    {
        nameText.text = dialog.name;

        Sentence.Clear();

        foreach(string senntence in dialog.sentnce){
            Sentence.Enqueue(senntence);
        }   
        DisplayNextSentence();
        }

    public void DisplayNextSentence()
    {
        if(Sentence.Count == 0)
        {
            EndDialog();
            return;
        }
           string sentence = Sentence.Dequeue();
           StopAllCoroutines();
           StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        DialogText.text ="";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text +=letter;
            yield return null;
        }
    }

    void  EndDialog()
    {
        Debug.Log("End og Con");
        dialogBox.SetActive(false);

    }
}
