using UnityEngine;

namespace RIA
{
    /// <summary>
    /// 對話資料
    /// </summary>
    [CreateAssetMenu(menuName = "RIA/Dialogue Data", fileName = "New Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        [Header("對話名稱")]
        public string dialogueName;
        [Header("對話者内容")]
        public string[]
            dialogueContents;
    }
}


