using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void switchLine()
    {
        SceneManager.LoadScene("FishFollowLine");
    }
    public void switchFollow()
    {
        SceneManager.LoadScene("FishFollowFood");
    }
    public void switchPopper()
    {
        SceneManager.LoadScene("BubblePopper");
    }
}
