using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalNameGenerator : MonoBehaviour
{
    [SerializeField] private TextAsset jsonData;
    [SerializeField] private Root Root;

    private HashSet<string> usedNames = new HashSet<string>();

    // For Debug. use LehmerRNG later.
    private System.Random rdm = new System.Random();

    private void Awake()
    {
        Root = new Root();
        Root = JsonUtility.FromJson<Root>(jsonData.text);
    }

    public string GenerateStarSystemNameFor(Language language)
    {
        NameBuilder starNames = Root.GetStarNamesFor(language);
        return starNames.GenerateName(rdm);
    }
}
