using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField]
    private Image backgroundImage; 

    public GameObject inkManager;
    public bool school;
    public bool room;

    [SerializeField]
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
       backgroundImage = gameObject.GetComponent<Image>();
        
    }

    private void Update()
    {
        school = inkManager.GetComponent<InkManager>().school;
        room = inkManager.GetComponent<InkManager>().room;
        if (school == true)
        {

           backgroundImage.enabled = false;
            ColorChange(backgroundImage);

        }

        if (room == true)
        {
            Debug.Log("Made it here!");
            
            backgroundImage.enabled = true;

        }
    }


    private void ColorChange(Image img)
    {
        img.color = newColor;
    }


}
