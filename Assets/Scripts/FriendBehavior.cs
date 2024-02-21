using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendBehavior : MonoBehaviour
{
    [SerializeField]
    private Image Adrian;

    public GameObject inkManager_friends;
    public bool adrian;


    // Start is called before the first frame update
    void Start()
    {
        Adrian = gameObject.GetComponent<Image>();

    }

    private void Update()
    {
        adrian = inkManager_friends.GetComponent<InkManager>().adrian;

        if (adrian == true)
        {

            Adrian.enabled = true;

        }

        else
        {
            Adrian.enabled = false;
        }
    }
}
