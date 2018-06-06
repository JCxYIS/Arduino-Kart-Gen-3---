using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUpBubbleManager : MonoBehaviour {
    public string title, dia;
    Animator ani;
    public Text titleLB, DiaLB;
    public Button ok, cancel;
    public enum AniStat { NotStarted, Starting, Stay, Closing };
    public AniStat aniStat = AniStat.NotStarted;
    bool isInGame;
    public InputField InputField;

    void Start() {
        ani = transform.GetChild(0).GetComponent<Animator>();
        aniStat = AniStat.NotStarted;
        //TargetScale = GetComponent<RectTransform>().localScale;
        GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    void FixedUpdate() {
        Ani();
        titleLB.text = title;
        DiaLB.text = dia;
        //Dia.GetComponent<RectTransform>().sizeDelta // = height/width
        if (DiaLB.preferredHeight >= 275)
        {
            DiaLB.GetComponent<RectTransform>().sizeDelta = new Vector2(
                DiaLB.GetComponent<RectTransform>().sizeDelta.x,
                DiaLB.preferredHeight
                );
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(
                this.GetComponent<RectTransform>().sizeDelta.x,
                DiaLB.preferredHeight + 325
                );
        }
    }
    void Ani()
    {
        switch (aniStat)
        {
            case AniStat.NotStarted:
                aniStat = AniStat.Starting;
                break;
            case AniStat.Starting:
                ani.Play("pop up");
                break;
            case AniStat.Closing:             
                ani.Play("pop down");
                if (ani.gameObject.GetComponent<RectTransform>().localScale.x <= 0)
                    Destroy(gameObject);
                break;
        }
    }
    ///<summary>
    ///Close this pop up window
    ///</summary>
    public void Close()
    {
        aniStat = AniStat.Closing;
        if(isInGame) GameObject.Find("Canvas/AntiOverFlow/Finger").GetComponent<BoxCollider2D>().enabled = true;
    }

    public InputField GetInputField()//get input kwon if possible
    {
        return InputField;
    }

    ///<summary>
    ///Make a pop up window.
    ///</summary>
    ///<param name="customType">can be "Normal","InGameMenu","TextInput","DotInput"</param>
    static public PopUpBubbleManager CreatePop(string Title, string Dialogue, UnityEngine.Events.UnityAction OKdo = null, 
        bool showCancel = true, UnityEngine.Events.UnityAction cancelDo = null)
    {
        GameObject pop;
        pop = Instantiate(Resources.Load<GameObject>("Prefabs/Pop-Up Bubble"));
               
        Debug.Log("Making pop up window.");
        PopUpBubbleManager pbm = pop.GetComponent<PopUpBubbleManager>();
        pbm.title = Title;
        pbm.dia = Dialogue;

       
        
        if (OKdo != null) 
            pbm.ok.onClick.AddListener(OKdo);
        if(cancelDo != null)
            pbm.cancel.onClick.AddListener(cancelDo);
        if (!showCancel) 
            pbm.cancel.gameObject.SetActive(false); 
        
        return pbm;
    }
}
