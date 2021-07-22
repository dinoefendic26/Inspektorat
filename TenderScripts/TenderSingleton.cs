
using UnityEngine;

public class TenderSingleton : MonoBehaviour {

    private static TenderSingleton _instance;
    public int currentTenderNum; 
    public bool[] tenderCompleted = new bool[18];

    public static TenderSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<TenderSingleton>();
                if(_instance == null) _instance = new GameObject().AddComponent<TenderSingleton>();
            }

            return _instance;
        }        
    }

    public int getCurrentTender() => currentTenderNum;

    public void setCurrentTender(int tenderNum) => currentTenderNum = tenderNum;

    public void completeTender(int tenderNum) => tenderCompleted[tenderNum] = true;

    public bool isSolved() {
        return tenderCompleted[currentTenderNum];
    }
}