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

    private void Start()
    {
        Root = new Root();
        Root = JsonUtility.FromJson<Root>(jsonData.text);
    }

    public void GenerateStarSystemName()
    {
        NameBuilder starNames = Root.GetStarNamesFor(Language.OJIBWE);
        Debug.Log(starNames.GenerateName(rdm));
    }
}
