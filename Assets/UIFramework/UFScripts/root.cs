using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class root : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        PanelMgr.instance.OpenPanel<TitlePanel>("");
        //DataManager.Instance.SaveDBKey("we", "laji");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
