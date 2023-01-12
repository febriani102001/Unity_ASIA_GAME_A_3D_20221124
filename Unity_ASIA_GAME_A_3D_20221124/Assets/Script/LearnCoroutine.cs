using UnityEngine;
using System.Collections;


namespace RIA
{
    public class LearnCoroutine : MonoBehaviour
    {
        private string testDialogue = "這裏好恐怖，我想要快點離開...";

        private void Awake()
        {
            //StartCoroutine(Test());
            //print("取得測試對話的第一個字 ：" + testDialogue[0]);
            //StartCoroutine(ShowDialogue());

            StartCoroutine(ShowDialogueUseFor());
        }
        private IEnumerator Test()
        {
            print("<color=#33ff33>第一行程式</color>");
            yield return new WaitForSeconds(2);
            print("<color=#33ff33>第一行程式</color>");
            yield return new WaitForSeconds(2);
        }

        private IEnumerator ShowDialogue()
        {
            print(testDialogue[0]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[1]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[2]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[3]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[4]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[5]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[6]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[7]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[8]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[9]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[10]);
            yield return new WaitForSeconds(0.1f);
            print(testDialogue[11]);
            yield return new WaitForSeconds(0.1f);
        }

        private IEnumerator ShowDialogueUseFor()
        {
            for(int i = 0; i < testDialogue.Length; i++)
            {
                print(testDialogue[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }


   
}
