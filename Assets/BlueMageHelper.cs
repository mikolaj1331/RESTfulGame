using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BlueMageHelper : MonoBehaviour
{
    public GameObject inputField;

    public RawImage icon;
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI typeTMP;
    public TextMeshProUGUI aspectTMP;
    public TextMeshProUGUI rankTMP;
    public TextMeshProUGUI ownedTMP;
    public TextMeshProUGUI tooltipTMP;
    public TextMeshProUGUI descriptionTMP;
    public TextMeshProUGUI howtoobtainTMP;

    private void Start()
    {
        icon.texture = Texture2D.blackTexture;
    }

    public void NewSpell()
    {
        _ = int.TryParse(inputField.GetComponent<TMP_InputField>().text, out int id);
        Spell sp = APIHelper.GetNewSpell(id);
        if(sp == null)
        {
            ResetWindow();
            return;
        }
        StartCoroutine(GetTexture(sp.icon,icon));
        nameTMP.text = sp.name;
        typeTMP.text = sp.type.name;
        aspectTMP.text = sp.aspect.name;
        rankTMP.text = sp.rank.ToString();
        ownedTMP.text = sp.owned + "%";
        tooltipTMP.text = sp.tooltip;
        descriptionTMP.text = sp.description;
        
        for(int i = 0; i < sp.sources.Length; i++)
        {
            howtoobtainTMP.text += sp.sources[i].text + "\n";
        }
    }

    private void ResetWindow()
    {
        icon.texture = Texture2D.blackTexture;
        nameTMP.text = "";
        typeTMP.text = "";
        aspectTMP.text = "";
        rankTMP.text = "";
        ownedTMP.text = "";
        tooltipTMP.text = "";
        descriptionTMP.text = "Non-existing spell id.";
        howtoobtainTMP.text = "";
    }

    public IEnumerator GetTexture(string iconURL, RawImage icon)
    {
        UnityWebRequest spriteRequest = UnityWebRequestTexture.GetTexture(iconURL);
        yield return spriteRequest.SendWebRequest();

        if(spriteRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(spriteRequest.error);
            yield break;
        }
        icon.texture = DownloadHandlerTexture.GetContent(spriteRequest);
        icon.texture.filterMode = FilterMode.Point;
    }
}
