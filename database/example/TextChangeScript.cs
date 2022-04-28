using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TextChangeScript : MonoBehaviour
{   
    // database
    [SerializeField] private string add_component = "http://127.0.0.1:3000/add-component";
    [SerializeField] private string update_content = "http://127.0.0.1:3000/update";
    [SerializeField] private string export_content = "http://127.0.0.1:3000/export-content";
    
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
            Tryupdatecomponent();
            Tryexportcontent();
            _note.text = finalTranscript;
        }
        
    }

    private IEnumerator Tryupdatecomponent(){

        string content = _theSpeechToText.GetFinalTranscript();

        UnityWebRequest request = UnityWebRequest.Get($"{add_component}?rcontent={content}");
        var handler = request.SendWebRequest();
        
        float startTime = 0.0f;
        while (!handler.isDone){
            startTime += Time.deltaTime;
            
            if(startTime > 10.0f){
                break;
            }

            yield return null;
        }

        if(request.result == UnityWebRequest.Result.Success){
            Debug.Log(request.downloadHandler.text);
        }
        else{
            Debug.Log("Unable to connect to the sever");
        }
        yield return null;
    }

    private IEnumerator Tryexportcontent(){

        UnityWebRequest request = UnityWebRequest.Get($"{export_content}");
        var handler = request.SendWebRequest();
        
        float startTime = 0.0f;
        while (!handler.isDone){
            startTime += Time.deltaTime;
            
            if(startTime > 10.0f){
                break;
            }

            yield return null;
        }

        if(request.result == UnityWebRequest.Result.Success){
            Debug.Log(request.downloadHandler.text);
        }
        else{
            Debug.Log("Unable to connect to the sever");
        }
        yield return null;
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