using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class nextScene : MonoBehaviour
{
    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
        if(TimelineClip.kDefaultClipDurationInSeconds==10)
        {
            SceneManager.LoadScene("Level01");
        }
    }
    public void slip()
    {
        SceneManager.LoadScene("Level01");
    }
}
