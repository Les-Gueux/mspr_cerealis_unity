using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanScript : MonoBehaviour
{
    public GameObject Form;
    
    public void PressReturnButton ()
    {
        SceneManager.LoadScene(0);
    }

    public void PressShareButton ()
    {
        Form.SetActive(true);
    }

    public void PressSubmitButton ()
    {
        Form.SetActive(false);
    }

}
