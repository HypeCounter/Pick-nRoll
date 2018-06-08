using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Json : MonoBehaviour {

    private string dataP;
    Hero hero;
	void Start () {
        hero = new Hero();
       // hero.nome = "Felipe";
        //hero.idade = 20;

        dataP = Path.Combine(Application.dataPath, "Heroi.json");
        Load();
        print(hero.nome + ":" + hero.idade);
      
	}

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(hero);
        File.WriteAllText(dataP, jsonString);
    }

    public void Load()
    {
        string jsonString = File.ReadAllText(dataP);
        JsonUtility.FromJsonOverwrite(jsonString, hero);
    }

	public class Hero
    {
        public string nome;
        public int idade;
    }
}
