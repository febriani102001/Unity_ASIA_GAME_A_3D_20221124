using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace RIA
{
    public class DialogueSystem : MonoBehaviour
    {
        #region 資料區城
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;

        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;

        [SerializeField, Header("對話按鍵")]
        private KeyCode dialogueKey = KeyCode.Space;


        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;

        #endregion

        private PlayerInput playerInput;

        private UnityEvent onDialogueFinish;
        #region MyRegion


        
        private void Awake()
        {
            groupDialogue = GameObject.Find("畫布對話系統").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話内容").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("對話完成圖示");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);
        }
        #endregion

        /// <summary>
        /// start dialogue
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_onDialogueFinish"></param>


        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {
            playerInput.enabled = false;
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            //true? 1 : 10 result 1
            //false？ 1 ：10 result 10

            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i < 10; i++)
            {
                groupDialogue.alpha += increase;
                yield return new WaitForSeconds(0.04f);

            }
        }

        private IEnumerator TypeEffect(DialogueData data)
        {
            textName.text = data.dialogueName;
            

            for (int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContent.text = "";
                    goTriangle.SetActive(false);

                string dialogue = data.dialogueContents[j];

                for (int i = 0; i < dialogue.Length; i++)
                {
                    textContent.text += dialogue[i];
                    yield return dialogueInterval;

                }

                goTriangle.SetActive(true);

                // IF THE PLAYER DIDN'T CLICK DIALOGUE KEY THEN WAIT..?
                while (!Input.GetKeyDown(dialogueKey))
                {
                    yield return null;
                }

                print("<color=#993300>玩家按下按鍵！</color>");
            }

            StartCoroutine(FadeGroup(false));

            playerInput.enabled = true;
            onDialogueFinish?.Invoke();
        }
    }
}


