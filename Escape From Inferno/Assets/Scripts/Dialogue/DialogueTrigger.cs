using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [Header("Visual Cue")] [SerializeField]
        private GameObject visualCue;

        [Header("Ink JSON")] [SerializeField] private TextAsset[] inkJSON;
        private bool playerInRange;
        private int indexStory;

        private GameObject _gameObject;

        private void Awake()
        {
            playerInRange = false;
            visualCue.SetActive(false);
            _gameObject = transform.parent.gameObject;
            indexStory = 0;
        }

        private void Update()
        {
            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                if (InputManager.GetInstance().GetInteractPressed())
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON[indexStory], _gameObject);
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                playerInRange = false;
            }
        }

        public void RemoveCurrentDialogue()
        {
            if (indexStory < inkJSON.Length) indexStory++;
        }
    }
}