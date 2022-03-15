using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChangeScript : MonoBehaviour
{
    public GameObject STT;
    private SpeechToTextScript _theSpeechToText;

    private string finalTranscript;

    [SerializeField]
    private Text _note;

    //private string[] keywordStrings;
    //private string theActiveKeyword;

    // Start is called before the first frame update
    void Start()
    {
        _theSpeechToText = STT.GetComponent<SpeechToTextScript>();
        //_renderer = this.GetComponent<Renderer>();
        //keywordStrings = new string[3] { "blue", "yellow", "red"};
        //_theSpeechToText.SetKeywords(keywordStrings);
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpeech();
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
    public void CheckSpeech()
    {
        
        finalTranscript = _theSpeechToText.GetFinalTranscript();

        _note.text = finalTranscript;

    }

    
}
