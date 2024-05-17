using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text;
using UnityEngine.Networking;
using System;

public class Login_API : MonoBehaviour
{
    public InputField edtUser;
    public InputField edtPass;
    public TMP_InputField edtError;

    public Selectable first;
    public EventSystem eventSystem;
    public Button btnLogin;
    public LoginReponse loginReponse;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        first.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            btnLogin.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eventSystem
                .currentSelectedGameObject
                .GetComponent<Selectable>()
                .FindSelectableOnDown();
            if (next != null) { next.Select(); }
        }
    }
    public void Playbtn()
    {
        SceneManager.LoadScene(3);
    }

    public void CheckLogin()
    {

        /*var email = edtUser.textComponent.text;
        var pass = edtPass.textComponent.text;

        UserModel userModel = new UserModel(email, pass);
        StartCoroutine(Login(userModel));*/
        StartCoroutine(Login());
    }

    public void CheckRegister()
    {

        var user = edtUser.text;
        var pass = edtPass.text;

        UserModel userModel = new UserModel(user, pass);
        StartCoroutine(Register(userModel));
        Register(userModel);
    }
    IEnumerator Login(/*UserModel userModel*/)
    {
        //…
        /*var request = new UnityWebRequest("http://teoth.online/API_game/user/login.php", "POST");
        string jsonStringRequest = JsonUtility.ToJson(userModel);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.chunkedTransfer = false;
        yield return request.SendWebRequest();*/

        WWWForm form = new WWWForm();
        form.AddField("email", edtUser.text);
        form.AddField("password", edtPass.text);

        UnityWebRequest request = UnityWebRequest.Post("http://teoth.online/API_game/user/login.php", form);
        
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            loginReponse = JsonUtility.FromJson<LoginReponse>(jsonString);
            if (jsonString.Contains("Dang nhap thanh cong"))
            {
                 Debug.Log(jsonString);
                 Debug.Log(loginReponse.message);
                    SceneManager.LoadScene(3);
            }
            else
            {
               /* SceneManager.LoadScene(3);*/
                    
                Debug.Log(loginReponse.status);
            }
        }
    }

    IEnumerator Register(UserModel userModel)
    {
        //…
        string jsonStringRequest = JsonUtility.ToJson(userModel, true);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/register", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            loginReponse = JsonUtility.FromJson<LoginReponse>(jsonString);
            if (loginReponse.status == 0)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log(loginReponse.message);
            }
        }
    }

}
