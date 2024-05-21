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
using System.Net.NetworkInformation;

public class Login_API : MonoBehaviour
{
    public InputField edtUser;
    public InputField edtPass;
    public TMP_InputField edtError;

    public InputField edtreEmail;
    public InputField edtrePass;
    public InputField edtreUsername;
    public InputField edtreName;


    public Selectable first;
    public EventSystem eventSystem;
    public Button btnLogin;
    static public LoginReponse loginReponse;
    static public UserModel userModel;
    static public Getchardata getchardata;
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

        /*var user = edtUser.text;
        var pass = edtPass.text;

        UserModel userModel = new UserModel(user, pass);*/
        StartCoroutine(Register());
        /*Register(userModel);*/
    }
    IEnumerator Login(/*UserModel userModel*/)
    {
        /*//…
        *//*var request = new UnityWebRequest("http://teoth.online/API_game/user/login.php", "POST");
        string jsonStringRequest = JsonUtility.ToJson(userModel);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.chunkedTransfer = false;
        yield return request.SendWebRequest();*/


         /* gởi thông tin lên server */
        WWWForm form = new WWWForm();
        form.AddField("email", edtUser.text);
        form.AddField("password", edtPass.text);

        /* gọi API đăng nhập */
        UnityWebRequest request = UnityWebRequest.Post("http://teoth.online/API_game/user/login.php", form);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            /* lấy thông tin đăng nhập server trả về và chuyển nó thành class LoginRespone */
            var jsonString = request.downloadHandler.text.ToString();
            loginReponse = JsonUtility.FromJson<LoginReponse>(jsonString);

            /* kiểm tra status của class LoginRespone */
            if (loginReponse.status==1)
            {
                /* lấy thông tin của character server trả về và chuyển nó thành class Getchardata */
                UnityWebRequest charrequest = UnityWebRequest.Get("http://teoth.online/API_game/character/get.php?userID="+loginReponse.userID);
                yield return charrequest.SendWebRequest();

                if (charrequest.isNetworkError || charrequest.isHttpError)
                {
                    Debug.Log(charrequest.error);
                }
                else
                {
                    Debug.Log(charrequest.downloadHandler.data); 
                }

                var jsonChar = charrequest.downloadHandler.text.ToString();
                getchardata = JsonUtility.FromJson<Getchardata>(jsonChar);
                Debug.Log(loginReponse.message);
                Debug.Log(getchardata.characterID);
                SceneManager.LoadScene(1);
            }
            else
            {
                /* SceneManager.LoadScene(3);*/
                Debug.Log(jsonString);
                Debug.Log(loginReponse.status);
            }
        }
    }

    IEnumerator Register()
    {
        //…
        UserModel userModel = new UserModel();
        userModel.email = edtreEmail.text;
        userModel.password = edtrePass.text;
        userModel.username = edtreUsername.text;
        userModel.name = edtreName.text;
        userModel.balance = 0;
        userModel.available = 1;


        string rejsonStringRequest = JsonUtility.ToJson(userModel);

        var request = new UnityWebRequest("http://teoth.online/API_game/user/register.php", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(rejsonStringRequest);
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
            /* Tao con nhan vat */
            UserRespone userRespone= new UserRespone();
            userRespone.name = edtreName.text;

            string charjsonStringRequest = JsonUtility.ToJson(userRespone);

            var charrequest = new UnityWebRequest("http://teoth.online/API_game/character/insert.php", "POST");
            byte[] bodyRawre = Encoding.UTF8.GetBytes(charjsonStringRequest);
            charrequest.uploadHandler = new UploadHandlerRaw(bodyRawre);
            charrequest.downloadHandler = new DownloadHandlerBuffer();
            charrequest.SetRequestHeader("Content-Type", "application/json");
            yield return charrequest.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
        }
    }

}
