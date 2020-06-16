using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public void OnMouseUp()
    {
        if (targetObject != null)
        {
            //targetObject.SendMessage(targetMessage);
            SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex);
        }
    }
}
