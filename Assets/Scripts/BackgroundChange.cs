using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField]
    private Image roomImage;
    [SerializeField]
    private Image schoolImage;

    [SerializeField]
    private Image classroomImage;

    //[SerializeField]
    //private Image gymImage;


    public GameObject inkManager;
    public bool school;
    public bool room;
    public bool classroom;
    //public bool gym;

    [SerializeField]
    private Color newColor;
    // Start is called before the first frame update
   

    private void Update()
    {
        school = inkManager.GetComponent<InkManager>().school;
        room = inkManager.GetComponent<InkManager>().room;
        classroom = inkManager.GetComponent<InkManager>().classroom;

        if (school == true)
        {
            schoolImage.enabled = true;
            roomImage.enabled = false;
            ColorChange(roomImage);

        }

        else if(classroom == true)
        {
            classroomImage.enabled = true;
            schoolImage.enabled = false;
            roomImage.enabled = false;
        }

        else if (room == true)
        {
           
            roomImage.enabled = true;
            schoolImage.enabled = false;
            classroomImage.enabled = false;

        }

    }


    private void ColorChange(Image img)
    {
        img.color = newColor;
    }


}
