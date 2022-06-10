using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NameBuilder
{
    public List<PrefixList> PrefixList = new List<PrefixList>();
    public List<RootList> RootList = new List<RootList>();
    public List<SuffixList> SuffixList = new List<SuffixList>();

    protected HashSet<string> createdNames = new HashSet<string>(); 

    public abstract string GenerateName(System.Random rdm);
}
