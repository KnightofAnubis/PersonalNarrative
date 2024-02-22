using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendBehavior : MonoBehaviour
{
    [SerializeField]
    private Image Adrian;
    [SerializeField]
    private Image Brandon; 
    [SerializeField]
    private Image Shuttler; 
    [SerializeField]
    private Image Tiffany; 
    
    public GameObject inkManager_friends;
    public bool adrian;
    public bool brandon;
    public bool shuttler;
    public bool tiffany;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void Update()
    {
        adrian = inkManager_friends.GetComponent<InkManager>().adrian;
        brandon = inkManager_friends.GetComponent<InkManager>().brandon;
        shuttler = inkManager_friends.GetComponent<InkManager>().shuttler;
        tiffany = inkManager_friends.GetComponent<InkManager>().tiffany;
        if (adrian == true)
        {

            Adrian.enabled = true;
            Brandon.enabled = false;
            Tiffany.enabled = false;
            Shuttler.enabled = false;
        }
        
        else if (brandon == true)
        {

           Brandon.enabled = true;
           Adrian.enabled = false;
           Tiffany.enabled = false;
           Shuttler.enabled = false;

        }

        else if (shuttler == true)
        {

            Shuttler.enabled = true;
            Adrian.enabled = false;
            Brandon.enabled = false;
            Tiffany.enabled = false;
            

        }
        else if (tiffany == true)
        {

            Tiffany.enabled = true;
            Adrian.enabled = false;
            Brandon.enabled = false;
            Shuttler.enabled = false;

        }

        else
        {
            Adrian.enabled = false;
            Brandon.enabled = false;
            Tiffany.enabled = false;
            Shuttler.enabled = false;

        }

 
    }
}
