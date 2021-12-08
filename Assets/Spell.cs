[System.Serializable]
public class Spell
{
    public int id;
    public string name;
    public string description;
    public string tooltip;
    public int rank;
    public float owned;
    public string icon;
    public Type type;
    public Aspect aspect;
    public Source[] sources;
}

[System.Serializable]
public class Type
{
    public int id;
    public string name;
}

[System.Serializable]
public class Aspect
{
    public int id;
    public string name;
}

[System.Serializable]
public class Source
{
    public string type;
    public string text;
    public string related_type;
    public int related_id;
}