using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataContainer : MonoBehaviour
{
    private List<string> path = new List<string>();
    private Animator animator;
    public List<string> PathList
    {
        get { return this.path; }
    }  

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        GameObject cameraAndUI = GameObject.Find("CameraAndUI"); // 変数名は小文字で始める
        if (cameraAndUI != null)
        {
            animator = cameraAndUI.GetComponent<Animator>();
        }
    }

    public void onClick_Straight()
    {
        path.Add("Straight");
        if (animator != null)
        {
            animator.SetTrigger("straight");
        }
    }

    public void onClick_Right()
    {
        path.Add("Right");
        if (animator != null)
        {
            animator.SetTrigger("right");
        }
    }

    public void onClick_Left()
    {
        path.Add("Left");
        if (animator != null)
        {
            animator.SetTrigger("left");
        }
    }

    public void SendResult()
    {
        SceneManager.LoadScene("Result");
    }
}
