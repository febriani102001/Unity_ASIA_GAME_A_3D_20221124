using UnityEngine;
using UnityEngine.Events;

namespace RIA
{
    public class InteractableSystem : MonoBehaviour
    {

        [SerializeField, Header("第一段對話資料")]
        private DialogueData dataDialogue;

        [SerializeField, Header("對話結束的事件")]
        private UnityEvent onDialogueFinish;

        [SerializeField, Header("啓動道具")]
        private GameObject propActive;
        [SerializeField, Header("啓動後的對話資料")]
        private DialogueData dataDialogueActive;

        [SerializeField, Header("啓動後對話結束的事件")]
        private UnityEvent onDialogueFinishAfterActive;


        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("畫布對話系統").GetComponent<DialogueSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                //如果不需要啓動道具
                if (propActive == null|| propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else 
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }

            }

        }

        private void OnTriggerExit(Collider other)
        {

        }

        private void OnTriggerStay(Collider other)
        {

        }

        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}
