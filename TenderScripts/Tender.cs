using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tender", menuName = "lovemetender/Tender", order = 0)]
public class Tender : ScriptableObject {
    
    public string agencija;
    public string obavještenjeONabavci;
    public string brojNabavke;
    public string datumObjaveObavještenja;
    public string ugovorniOrgan;
    public string idUo;
    [TextArea(5,30)]
    public string opisPredmetaNabavke;
    public string količina;
    public string vrijednostNabavkeSaPdv;
    public string rokImplementacije;
    public string datumObjavljivanjaGodišnjegPlanaNabavki;
    public string procjenjenaVrijednost = "ured za javnu nabavku";
    [TextArea(5,30)]
    public string izvodIzTenderskeSpecifikacijeZaUslovePonuđača;
    public bool legit = true;

    bool completed = false;

    public bool getCompleted(){
        return this.completed;
    }

    public void setCompleted(bool completed){
        this.completed = completed;
    }
}
