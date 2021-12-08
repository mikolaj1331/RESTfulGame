using UnityEngine;
using System.Net;
using System.IO;

/*
public static class APIHelper
{
    public static Spell GetNewSpell(int id)
    {
        string newURL = "https://ffxivcollect.com/api/spells/" + id.ToString();
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newURL);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string json = reader.ReadToEnd();
        return JsonUtility.FromJson<Spell>(json);
    }
}
*/

public static class APIHelper
{
    public static Spell GetNewSpell(int id)
    {
        string newURL = "https://ffxivcollect.com/api/spells/" + id.ToString();
        string json = "";
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            json = reader.ReadToEnd();
        }
        catch(WebException e)
        {
            if(e.Status == WebExceptionStatus.ProtocolError)
            {
                return null;
            }
        }
        return JsonUtility.FromJson<Spell>(json);
    }
}