using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    public Text IDtext;
    public Button connetBtn;

    public void Connect()
    {
        if (IDtext.text == string.Empty) return;
        IDtext.text.Replace(" ", string.Empty);
        PhotonNetwork.LocalPlayer.NickName = IDtext.text;
        SceneManager.LoadScene(1);
    }
}
