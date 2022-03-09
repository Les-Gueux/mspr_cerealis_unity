using System;
using System.Web;
using System.Text;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScanScript : MonoBehaviour
{
    public GameObject Form;
    public Text inputName;
    public Text inputMail;
    
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
        httpRequestUnity(inputName.text, inputMail.text);
        inputName.text = "";
        inputMail.text = "";

        Form.SetActive(false);
    }

    private async void httpRequestUnity(string lastname, string email){
        using (var httpClient = new HttpClient())
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://cerealis.with4.dolicloud.com/api/index.php/contacts"))
            {
                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                request.Headers.TryAddWithoutValidation("DOLAPIKEY", "J8TaA0q5asF94oc7o5hlYD6VQkM7KW5z"); 

                request.Content = new StringContent("{\"lastname\":\""+lastname+"\",\"email\":\""+email+"\"}");
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json"); 

                var response = await httpClient.SendAsync(request);
                Debug.Log(response);
            }
        }
    }
}
