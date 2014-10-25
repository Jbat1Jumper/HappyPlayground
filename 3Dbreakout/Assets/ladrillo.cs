using UnityEngine;
using System.Collections;

public class ladrillo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision col)
	{
		// hum hum hum
		if(col.gameObject.name == "bola")
		{
			// no hace falta explicar nada
			Destroy(this.gameObject);

			// TODO: añadir variable publica de puntos del bloque
			// TODO: añadir que cuando muera de puntos
			// TODO: añadir algo que reciba y muestre esos puntos
		}
	}
}
