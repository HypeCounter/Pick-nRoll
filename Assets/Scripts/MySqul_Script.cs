using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using UnityEngine.UI;
public class MySqul_Script : MonoBehaviour {


    private string linhaConn;
    private MySqlConnection conn;

    [SerializeField]  private InputField idInp, nomeInp, idadeInp;
    private int id, idade;
    private string nome;

    [SerializeField] private Text dadosTxt;
    // Use this for initialization

    void Start () {
        linhaConn = "Server=localhost;"+ "Database=unity;"+"User ID=root;"+"Password=;"+"Pooling=false";
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void ConnDataBase(string lConn)
    {
        conn = new MySqlConnection(lConn);
        conn.Open();
        print("Conectado");
    }
    public void InserirDados()
    {
        ConnDataBase(linhaConn);
        id = int.Parse(idInp.text);
        nome = nomeInp.text;
        idade = int.Parse(idadeInp.text);

        string sql = "INSERT INTO personagem(ID,NOME,IDADE)VALUES('" + id + "','" + nome + "','" + idade + "');";
        MySqlCommand command = new MySqlCommand(sql, conn);
        command.ExecuteNonQuery();
        command.Dispose();
        conn.Close();
    }

    public void AtualizarDataBase()

    {
        ConnDataBase(linhaConn);
        string sql = "UPDATE personagem SET NOME = @NOME,IDADE = @IDADE WHERE ID=@ID;";
        MySqlCommand command = new MySqlCommand (sql,conn);
        command.Parameters.AddWithValue("@ID", idInp.text);
        command.Parameters.AddWithValue("@NOME", nomeInp.text);
        command.Parameters.AddWithValue("@IDADE", idadeInp.text);
        command.ExecuteNonQuery();
        conn.Close();


    }

    public void PesquisarTodosDados()
    {
        ConnDataBase(linhaConn);
        string sql = "SELECT * FROM personagem;";
        MySqlCommand command = new MySqlCommand(sql, conn);
        MySqlDataReader dados = command.ExecuteReader();
        if (dados.HasRows)
        {
            while(dados.Read())
            {
                string idString = dados["ID"].ToString();
                string nomeString = dados["Nome"].ToString();
                string idadeString = dados["Idade"].ToString();
                dadosTxt.text += idString + nomeString + idadeString + "\n";
            }
        }
        dados.Close();
        command.Dispose();
        conn.Close();

    }
    public void DeletarDadosPorID()
    {
        ConnDataBase(linhaConn);
        id = int.Parse(idInp.text);
        string sql = "DELETE FROM personagem WHERE ID = '" + id + "';";
        MySqlCommand command = new MySqlCommand(sql, conn);
        command.ExecuteNonQuery();
        command.Dispose();
        conn.Close();


    }

}
