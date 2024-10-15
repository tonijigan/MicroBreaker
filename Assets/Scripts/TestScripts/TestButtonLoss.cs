using UnityEngine.SceneManagement;

public class TestButtonLoss : AbstractButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(Enums.ScenesName.ChooseLevel.ToString());
    }
}