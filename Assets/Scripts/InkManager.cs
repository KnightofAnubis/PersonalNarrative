
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class InkManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.01f;

    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;
    [SerializeField] private GameObject continueIcon;
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

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    public bool school = false;
    public bool room = true;
    public bool classroom = false;
    public bool gym = false;

    [Header("Characters")]
    public bool demon = false;
    public bool adrian = false;
    public bool brandon = false;
    public bool shuttler = false;
    public bool tiffany = false;


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
    private IEnumerator DisplayLine(string line)
    {
        // set the text to the full line, but set the visible characters to 0
        _textField.text = line;
        _textField.maxVisibleCharacters = 0;
        // hide items while text is typing
        continueIcon.SetActive(false);
      

        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {
            
            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else
            {
               
               _textField.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // actions to take after the entire line has finished displaying
        

        canContinueToNextLine = true;
        continueIcon.SetActive(true);
    }
   
    public void DisplayNextLine()
        {


            if (_story.canContinue)
            {
                
                string text = _story.Continue();
                text = text?.Trim();
                displayLineCoroutine = StartCoroutine(DisplayLine(text));
              
                
                ChangeBackground();
                ApplyStyling();
                _textField.text = text;
                
            }
            else if (_story.currentChoices.Count > 0)
            {
                DisplayChoices();
                
            }

            else
            {
            if (MainManager.Instance.success)
                {
                    Debug.Log("success");
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    SceneManager.LoadScene(nextNight);
                }
                
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
        //background
        if (_story.currentTags.Contains("school"))
        {
            school = true;
            classroom = false;
            room = false;
            gym = false;
        }
        if (_story.currentTags.Contains("classroom"))
        {
            classroom = true;
            school = false;
            room = false;
            gym = false;
        }

        if (_story.currentTags.Contains("room"))
        {
            room = true;
            classroom = false;
            school = false;
            gym = false;
        }
        if (_story.currentTags.Contains("gym"))
        {
            gym = true;
            school = false;
            classroom = false;
            room = false;
        }

        //characters
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

        if (_story.currentTags.Contains("Brandon"))
        {
            brandon = true;
        }
        else
        {
            brandon = false;
        }
        if (_story.currentTags.Contains("Shuttler"))
        {
            shuttler = true;
        }
        else
        {
            shuttler = false;
        }
        if (_story.currentTags.Contains("Tiffany"))
        {
            tiffany = true;
        }
        else
        {
            tiffany = false;
        }

    }
}
