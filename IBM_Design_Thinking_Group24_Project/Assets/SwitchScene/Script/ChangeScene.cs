using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void LoadVRRoom()
    {
        SceneManager.LoadScene(4);
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene(2);
    }
    
    public void  NormalLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void  Quit()
    {
        SceneManager.LoadScene(0);
    }
}
