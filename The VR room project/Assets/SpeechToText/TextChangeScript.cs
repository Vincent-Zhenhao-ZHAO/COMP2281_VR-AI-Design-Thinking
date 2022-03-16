using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangeScript : MonoBehaviour
{
    public GameObject STT;
    private SpeechToTextScript _theSpeechToText;
    public Button m_Button;

    private string finalTranscript;
    private int ButtonInt = 0;

    [SerializeField]
    private Text _note;

    //private string[] keywordStrings;
    //private string theActiveKeyword;

    // Start is called before the first frame update
    void Start()
    {
        m_Button.onClick.AddListener(TaskOnClick);
        //_theSpeechToText = STT.GetComponent<SpeechToTextScript>();
        //_renderer = this.GetComponent<Renderer>();
        //keywordStrings = new string[3] { "blue", "yellow", "red"};
        //_theSpeechToText.SetKeywords(keywordStrings);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // checking keywords only
    // public void CheckColour()
    // {
    //     theActiveKeyword = _theSpeechToText.GetCurrentKeyword();

    //     if (string.Equals(theActiveKeyword, keywordStrings[0]))
    //     {
    //         _renderer.material.SetColor("_Color", Color.blue);
    //     }

    //     if (string.Equals(theActiveKeyword, keywordStrings[1]))
    //     {
    //         _renderer.material.SetColor("_Color", Color.yellow);
    //     }

    //     if (string.Equals(theActiveKeyword, keywordStrings[2]))
    //     {
    //         _renderer.material.SetColor("_Color", Color.red);
    //     }
    // }
    /// Retrieving finalTranscript and checking for any text rather than keywords only
    
    
    // public void CheckSpeech()
    // {
        
    //     finalTranscript = _theSpeechToText.GetFinalTranscript();

    //     _note.text += finalTranscript;
        

    // }
    
    public void TaskOnClick()
    {
        ButtonState();
        if (ButtonInt == 1)
        {
        _theSpeechToText = STT.GetComponent<SpeechToTextScript>();
        _theSpeechToText.CreateService();
        Debug.Log("You have clicked on Blue Sticky Note! Recording begins");
        }

        else
        {
            finalTranscript = _theSpeechToText.GetFinalTranscript();
            _note.text = finalTranscript;
        }
        
    }

    private void ButtonState()
    {
        if (ButtonInt == 0)
        {
            ButtonInt = 1;
        }

        else
        {
            ButtonInt = 0;
        }
    }

    
}
