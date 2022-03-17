using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour

{
    
    private string username;
    private string password;
    public void ReadUsername(string s)
    {
        username = s;
        if (username == "user")
        {

            Debug.Log(username);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        
    }
    public void ReadPassword(string s)
    {
        password = s;
        if (password == "password")
        {
            Debug.Log(password);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
       
    }
}
