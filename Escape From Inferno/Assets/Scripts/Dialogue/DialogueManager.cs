using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [Header("Dialogue UI")] private static DialogueManager instance;
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;

        [Header("Choices UI")] [SerializeField]
        private GameObject[] choices;

        private TextMeshProUGUI[] choicesText;
        private Story currentStory;
        public bool dialogueIsPlaying { get; private set; }
        public string currentChoice { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("Found more than one Dialogue Manager in the scene");
            }

            instance = this;
        }

        public static DialogueManager GetInstance()
        {
            return instance;
        }

        private void Start()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);

            choicesText = new TextMeshProUGUI[choices.Length];
            int index = 0;
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }

        private void Update()
        {
            if (!dialogueIsPlaying)
            {
                return;
            }

            if (currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed())
            {
                ContinueStory();
            }
        }

        public void EnterDialogueMode(TextAsset inkJSON)
        {
            currentStory = new Story(inkJSON.text);
            dialogueIsPlaying = true;
            dialoguePanel.SetActive(true);

            ContinueStory();
        }

        private void ExitDialogMode()
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
            currentChoice = "";
        }

        private void ContinueStory()
        {
            if (currentStory.canContinue)
            {
                dialogueText.text = currentStory.Continue();
                DisplayChoices();
            }
            else
            {
                ExitDialogMode();
            }
        }

        private void DisplayChoices()
        {
            List<Choice> currentChoices = currentStory.currentChoices;

            if (currentChoices.Count > choices.Length)
            {
                Debug.LogError("More choices were given than the UI can support. Number of choices given: " +
                               currentChoices.Count);
            }

            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesText[index].text = choice.text;
                index++;
            }

            for (int i = index; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }

            StartCoroutine(SelectFirstChoice());
        }

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int choiceIndex)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            currentChoice = choicesText[choiceIndex].text;
        }
    }
}