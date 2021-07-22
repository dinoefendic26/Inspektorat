using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TenderManager : MonoBehaviour
{
    public Tender[] tenderi;
    public GameObject tenderParent;
    public GameObject tenderPreview;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<3; i++){
            Tender tender = tenderi[i];
            tenderParent.transform.GetChild(i).GetComponent<UnityEngine.UI.Button>().onClick.AddListener(
                () => tenderPreview.GetComponent<TenderPreview>().showPreview(tender));
        }
        
    }
}
