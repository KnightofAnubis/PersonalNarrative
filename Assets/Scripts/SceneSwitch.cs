using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string nextCycle;
    public void OnCollisionEnter2D(Collision2D collision) 
    {
        SceneManager.LoadScene(nextCycle);
    }

    public void Restart()
    {
        SceneManager.LoadScene("First Night");
    }

}
