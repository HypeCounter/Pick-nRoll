using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    public static GameManager instance;
    public bool bolaEmCena;
    public GameObject bolaPrefab;
    [SerializeField]private Transform pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10;
    [SerializeField] private Transform pos11, pos12, pos13, pos14, pos15, pos16, pos17, pos18, pos19, pos20, pos21, pos22, pos23, pos24;

    // Use this for initialization

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    void Carrega (Scene cena, LoadSceneMode modo)
    {

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
