using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OjibweNameBuilder: NameBuilder
{
    public override string GenerateName(System.Random rdm)
    {
        string name = MakeName(rdm);

        while (createdNames.Contains(name))
        {
            name = MakeName(rdm);
        }

        createdNames.Add(name);
        return name;
    }

    private string MakeName(System.Random rdm)
    {

        int rdmIdx = LehmerRNG.Next(0, RootList.Count);
        RootList rootName = RootList[rdmIdx];

        if (rootName.Category != "Noun")
        {
            return rootName.Name;
        }
    
        rdmIdx = rdm.Next(0, PrefixList.Count);
        PrefixList prefix = PrefixList[rdmIdx];

        rdmIdx = rdm.Next(0, SuffixList.Count);
        SuffixList suffix = SuffixList[rdmIdx];

        return $"{prefix.Name} {rootName.Name} {suffix.Name}";
    }
}
