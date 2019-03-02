using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    List<string> instructions = new List<string>();
    [SerializeField] GameObject StoryPanel;
    [SerializeField] GameObject btnPanel;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] int index = -1;
    [SerializeField] float displayTime = 2;
    [SerializeField] float typingSpeed = .05f;
    [SerializeField] GameObject Button;

    private void Start() {
        instructions.Add("Our homeworld is desperate for resources. It is up to you to recover them from various planets in our solar system ");

        instructions.Add("\n\nAim with Mouse");
        
        instructions.Add("\nRightClick to move to new planet.");
        

        instructions.Add("\n\nClick the resource button to exchange energy for resources in range.");
        instructions.Add("\nReturn home to distribute supplies");

        instructions.Add("BREAK");
        
        

        //StartStory();

    }
    public void StartButton() {
        btnPanel.SetActive(false);
        StoryPanel.SetActive(true);
        StartStory();
    }
    public void Quit() {
        Application.Quit();
    }

    void StartStory() {
        dialogText.text = "";
        GetNextLine();
    }
    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void GetNextLine() {

        index++;
        
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText() {
        yield return new WaitForSeconds(0.5f);


        if (instructions[index] == "BREAK") {
            Button.SetActive(true);
            yield break;
        }
        foreach (char c in instructions[index]) {
            yield return new WaitForSeconds(typingSpeed);
            dialogText.text += c;
        }
        yield return new WaitForSeconds(displayTime);
        GetNextLine();
    }
}
