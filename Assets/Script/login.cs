using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class login : MonoBehaviour
{

    public TMP_InputField UsernameInput;
    public TMP_InputField PasswordInput;
    public TextMeshProUGUI Message;

    public void Signin()
    {
        if (UsernameInput.text == "keanen" && PasswordInput.text == "123")
        {
            Message.text = "Success";
            Debug.Log("Next Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Message.text = "Error";
            Debug.Log("Error");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
