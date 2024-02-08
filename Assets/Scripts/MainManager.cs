using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
  
    public TextAsset story;
    public Story inkText;
    public void Update()
    {
        if(MainManager.Instance != null)
        {
            SetStory(MainManager.Instance.story);
            
        }
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetStory(TextAsset storyTime)
    {
        inkText = new Story(storyTime.text);
    }
}
