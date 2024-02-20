using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonBehavior : MonoBehaviour
{
    [SerializeField]
    private Image Demon;

    public GameObject inkManager;
    public bool demon;
    

    // Start is called before the first frame update
    void Start()
    {
        Demon = gameObject.GetComponent<Image>();

    }

    private void Update()
    {
        demon = inkManager.GetComponent<InkManager>().demon;
       
        if (demon == true)
        {

            Demon.enabled = true;

        }

        else
        {
            Demon.enabled = false;
        }
    }
}
