using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootScript : MonoBehaviour {
    private float forca = 2f;
    private Vector2 startPos;
    private bool tiro = false;
    private bool mirando = false;
    [SerializeField] private GameObject dotsGO;
    private List<GameObject> caminho;
    [SerializeField] private Rigidbody2D myRBody;
    [SerializeField]private Collider2D myCollider;
    private Collider2D toqueCol;
    [SerializeField] private float variavelMultY, variavelMultX;
    [SerializeField] private float vidaBola = 1f;
    [SerializeField] private Color cor;
    [SerializeField] private Renderer bolaRender;
    [SerializeField] private bool tocouChao;

    // Use this for initialization
    void Start ()
    {

        cor = bolaRender.material.GetColor("_Color");

        myRBody.isKinematic = true;
        myCollider.enabled = false;
        startPos = transform.position;
        Caminho();
        for (int x = 0; x < caminho.Count; x++)
        {
            caminho[x].GetComponent<Renderer>().enabled = false;
        }
    }

    private void Caminho()
    {
        caminho = dotsGO.transform.Cast<Transform>().ToList().ConvertAll(t => t.gameObject);
    }

    private void Update()
    {
        if (tocouChao == true)
        {
            MataBola();
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
         Mirando();
    }

    void MostraCaminho()
    {
        for(int x=0; x< caminho.Count;x++)
        {
            caminho[x].GetComponent<Renderer>().enabled = true;

        }
    }
    void EscondeCaminho()
    {
        for(int x=0; x< caminho.Count;x++)
        {
            caminho[x].GetComponent<Renderer>().enabled = false;
        }
    }
    Vector2 PegaForca(Vector2 mouse)
    {
        return (new Vector2(startPos.x + variavelMultX, startPos.y + variavelMultY) - new Vector2(mouse.x, mouse.y)) * forca;
    }
    Vector2 CaminhoPonto (Vector2 posInicial, Vector2 velInicial, float tempo)
    {
        return posInicial + velInicial * tempo + 0.5f * Physics2D.gravity * tempo * tempo;
    }
    
    void CalculoCaminho()
    {
        Vector2 vel = PegaForca(Input.mousePosition) * Time.fixedDeltaTime / myRBody.mass;
        for (int x=0; x< caminho.Count; x++)
        {
            caminho[x].GetComponent<Renderer>().enabled = true;
            float t = x / 20f;
            Vector3 point = CaminhoPonto(transform.position, vel, t);
            point.z = 1f;
            caminho[x].transform.position = point;
        }
    }

    void Mirando()
    {
        if (tiro == true)
            return;
        if (Input.GetMouseButton(0))
        {
            if (mirando == false)
            {
                mirando = true;
                startPos = Input.mousePosition;
                CalculoCaminho();
                MostraCaminho();
                toqueCol = GameObject.FindGameObjectWithTag("toque").GetComponentInChildren<Collider2D>();
            }
            else
            {
                CalculoCaminho();
            }

        }else if(mirando && tiro == false){
            myRBody.isKinematic = false;
            myCollider.enabled = true;
            tiro = true;
            mirando = false;
            myRBody.AddForce(PegaForca(Input.mousePosition));
            myRBody.AddTorque(25f);
            toqueCol.enabled = false;
            EscondeCaminho();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))

        {
            tocouChao = true;
        }
    }
    void MataBola()
    {
        if (vidaBola > 0)
        {
            vidaBola -= Time.deltaTime;
            bolaRender.material.SetColor("_Color", new Color(cor.r, cor.g, cor.b, vidaBola));
        }
        if(vidaBola<=0)
        {
            Destroy(gameObject);
        }
    }
}
