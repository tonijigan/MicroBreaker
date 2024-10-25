using UnityEngine.SceneManagement;
using UnityEngine;
using SDK;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TestButtonLoss : MonoBehaviour
{
    [SerializeField] private SDKPromotionalVideo _promotionalVideo;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlayPromo);
        _promotionalVideo.ClosedCallBack += OnClick;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlayPromo);
        _promotionalVideo.ClosedCallBack -= OnClick;
    }

    private void PlayPromo() => _promotionalVideo.ShowInterstitialAd();

    public void OnClick()
    {
        SceneManager.LoadScene(Enums.ScenesName.ChooseLevel.ToString());
    }
}