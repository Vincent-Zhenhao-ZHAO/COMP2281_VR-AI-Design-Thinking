using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Password : MonoBehaviour

{


    private string _password;

    public void ReadPassword(string s)
    {
        _password = s;
        if (_password == "password")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
