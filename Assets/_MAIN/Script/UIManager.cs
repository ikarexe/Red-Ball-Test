using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager i;
    public Button jumpButton;

    void Awake()
    {
        i = this;
    }

    void Start()
    {
        jumpButton.onClick.AddListener(PlayerController.i.Jump);
    }
}
