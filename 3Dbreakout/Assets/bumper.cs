using UnityEngine;
using System.Collections;

public class bumper : MonoBehaviour {

	public float speed = 2;
	public float th = 0f;
	// Use this for initialization
	void Start () {
		// verifico que el threshold este dentro del rango
		if(th >1)
			th = 1;
		else if(th<0)
			th = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// obtengo los ejes del joystick, son valores que
		//  van de -1 a 1
		var h = Input.GetAxis("horizontal");
		var v = Input.GetAxis("vertical");
		// me creo un vector vacio para acumular el movimiento
		var dir = new Vector3(0,0,0);

		// si el valor absoluto del eje horizon supera el threshold 
		if( Mathf.Abs(h) > th ){
			// sumo* ese valor por la velocidad, le da un toque como fluido
			//  debido a que si tiene analogicos puede mover la cosa despacio
			//  y en la pc tiene inercia
			//  *(1) actualmente resto porque esta girado en un eje
			dir.x -= 0.1f * speed * h;
		}

		// lo mismo para el eje vertical
		if( Mathf.Abs(v) > th ){
			dir.y += 0.1f * speed * v;
		}

		// ahora lo que hago es realmente mover al bumper hacia ese dir que fui acumulando
		// TODO: utilizar Time Delta para que la velocidad no dependa de los cuadros por segundo
		this.transform.position += dir;
	}
}
