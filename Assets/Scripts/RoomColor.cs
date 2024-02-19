using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RoomColor : MonoBehaviour
{
    [SerializeField]
    private Image image;
    
    //public GameObject background;
    private Color newColor;
    
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        ColorChange(image);
    }


    private void ColorChange(Image img)
    {
        
        newColor = MainManager.Instance.sanityHaze;
        img.color = newColor;
    }

    
}
