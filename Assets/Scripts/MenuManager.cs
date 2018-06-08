using UnityEngine;
using DFTGames.Localization;

public class MenuManager : MonoBehaviour
{
    #region Public Methods

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
    }

    public void SetPortuguese()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Portuguese);
        LocalizeImage.SetCurrentLanguage();
    }

    public void SetChinese()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Chinese);
        LocalizeImage.SetCurrentLanguage();
    }

    #endregion Public Methods
}
