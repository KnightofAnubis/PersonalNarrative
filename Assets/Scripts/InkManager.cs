
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InkManager : MonoBehaviour
{
    
    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;
    
    [SerializeField]
    private TMP_Text _textField;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;

    [SerializeField]
    private Color _demonTextColor;

    public bool school = false;
    public bool room = true;
    public bool demon = false;
    public bool adrian = false;

    public string nextNight;
    // Start is called before the first frame update
    void Start()
    {
        StartStory();
    }

    private void StartStory()
    {
        _story = MainManager.Instance.inkText;
        Debug.Log(_story);
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (_story.canContinue)
        {
            ChangeBackground();
            string text = _story.Continue();
            text = text?.Trim();
            ApplyStyling();
            _textField.text = text;
        }
        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }

        else
        {
            SceneManager.LoadScene(nextNight);
        }
       
      
    }

    private void DisplayChoices()
    {
        if (_choiceButtonContainer.GetComponentsInChildren<Button>().Length > 0) return;

        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(() => OnClickChoiceButton(choice)); 
        }
    }

    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonContainer.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text;

        return choiceButton;
    }
    


    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        RefreshChoiceView();
        DisplayNextLine();

    }


    void RefreshChoiceView()
    {
        foreach (var button in _choiceButtonContainer.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
    }

    private void ApplyStyling()
    {
        if (_story.currentTags.Contains("demonColor"))
        {
            _textField.color = _demonTextColor;
        }
        else
        {
            _textField.color = _normalTextColor;
        }
    }

    void ChangeBackground()
    {
        if (_story.currentTags.Contains("school"))
        {
            school = true;
            room = false;
        }

        if (_story.currentTags.Contains("room"))
        {
            school = false;
            room = true;
        }

        if (_story.currentTags.Contains("demon"))
        {
            demon = true;
        }
        else
        {
            demon = false;
        }

        if (_story.currentTags.Contains("Adrian"))
        {
            adrian = true;
        }
        else
        {
            adrian = false;
        }

    }
}
