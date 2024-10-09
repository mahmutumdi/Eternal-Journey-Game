using UnityEngine;

namespace UI.Localization
{
    [CreateAssetMenu(fileName = "LanguageData", menuName = "Localization/LanguageData")]
    public class LanguageScriptableObject : ScriptableObject
    {
        public string languageName;
        public string[] keys;
        public string[] values;

        public string GetTranslation(string key)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key)
                {
                    return values[i];
                }
            }
            return null;
        }
    }
}