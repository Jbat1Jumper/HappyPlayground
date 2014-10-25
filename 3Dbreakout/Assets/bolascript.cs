using UnityEngine;
using System.Collections;

public class bolascript : MonoBehaviour {

	public bool activa = false;
	public float initialspeed = 7;


	Vector3 OffestDelBumper;

	// Use this for initialization
	void Start () {
		// teoricamente obtengo el bumper y mido en que posision estoy relativo al mismo
		var bumper = GameObject.Find ("bumper");
		OffestDelBumper = bumper.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		// espera a que se presione espacio
		if(Input.GetButton("action") && !activa){
			activa = true;
			ComenzarAMoverme();
		}


		if(activa){
			// Esto es lo importante en un juego de breakout
			MantenerVelocidadContraElJugadorConstante();

			VerificarIndicadorDeChoque ();
		}else{
			// si todavia no comenzo a jugar teoricamente al mover
			//  el bumper moveria la pelota tambien

			var bumper = GameObject.Find ("bumper");
			this.rigidbody.position = bumper.transform.position - OffestDelBumper;
		}
	}

	void ComenzarAMoverme ()
	{
		// wiiiiiiiiiiiii
		rigidbody.velocity = new Vector3(initialspeed, initialspeed, -initialspeed);
	}

	void MantenerVelocidadContraElJugadorConstante ()
	{
		// fijo la velocidad absoluta en el eje z al valor initialspeed
		var zspeed = Mathf.Sign(rigidbody.velocity.z) * initialspeed;
		rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, zspeed);
	}

	// al chocar se le asigna un valor que decrece y cuando llega a cero de 
	//  deja de indicar que choco // si, se puede hacer mejor con animaciones
	int contador_choque = 0;
	public void IndicarQueChoco() {
		contador_choque = 5;
		// muestra un precario objeto por un instante para 
		//  que indique que choco
		var mr = this.transform.FindChild("colision_show").GetComponent<MeshRenderer>().enabled = true;
	}

	void VerificarIndicadorDeChoque ()
	{
		if (contador_choque > 0) {
			contador_choque--;
			if (contador_choque == 0)
				// oculta el objeto que muestra precariamente que choco
				this.transform.FindChild ("colision_show").GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	// Esta funcion es de la api de unity y se 
	//  llama cada vez que ocurre una colision
	void OnCollisionEnter (Collision col)
	{
		// Hay que llamar esto de algun lado
		IndicarQueChoco() ;

		// TODO: Verificar si choco contra un bumper, obtener su ...
		//  ... posision y dependiendo de esta darle ese efecto a la bola
		//  como todos los breakout tienen. Si pega en un costado se va muy
		//  para ese costado.

		// TODO: Añadir un objeto DeadZone detras del bumper y verificar ...
		//  ... que si choca contra ese coso muera, saque una vida, y 
		//  resetee la bola cerca del bumper.

		// TODO: Añadir vidas y algo que las muestre.
	}
}
