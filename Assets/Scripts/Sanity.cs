using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;

  
    [SerializeField] private TextAsset _inkJsonAsset_one;
    [SerializeField] private TextAsset _inkJsonAsset_two;
    [SerializeField] private TextAsset _inkJsonAsset_three;
    [SerializeField] private TextAsset _inkJsonAsset_none;
    private void Update()
    {
        AmountofSanity();
    }
    public void AmountofSanity()
    {
        if (one == null && three != null && two != null || two == null && three != null && one != null || three == null && one != null && two != null)
        {
            
            Progression(_inkJsonAsset_one);
            //Debug.Log("one");
        }

        else if (two == null && one == null && three != null || three == null && one == null && two != null || three == null && two == null && one != null)
        {
            
            Progression(_inkJsonAsset_two);
            //Debug.Log("two");
        }

        else if (two == null && one == null && three == null)
        {
            
            Progression(_inkJsonAsset_three);
            //Debug.Log("three");
        }
        else
        {
            Progression(_inkJsonAsset_none);
            //Debug.Log("none");
        }
    }
    public void Progression(TextAsset next_up)
    {
        MainManager.Instance.story = next_up;
        //Debug.Log(next_up);


    }


}
