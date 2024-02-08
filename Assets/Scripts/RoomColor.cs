using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomColor : MonoBehaviour
{
    public Image image;
    public GameObject gameObject;
    private Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        newColor = MainManager.Instance.sanityHaze;
        image.color = newColor;
    }

    
}
