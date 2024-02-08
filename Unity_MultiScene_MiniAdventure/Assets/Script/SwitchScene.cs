using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    public void SendResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void BackToMap(){
        SceneManager.LoadScene("Map");
    }
}
