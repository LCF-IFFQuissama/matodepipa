using UnityEngine;
using System.Collections;

public class IniciaChamas : MonoBehaviour {
	
	public enum Trilha {
		A   = 0,
		B   = 1,
		C   = 2,
		D   = 3,
		E   = 4
	}
	// Use this for initialization
	void Start () {

		int aleatorio = Random.Range(1,6);
		GameObject fogueira = GameObject.Find("FaiscaA"+aleatorio);
		fogueira.GetComponent<Renderer>().enabled = true;

		aleatorio = Random.Range(1,6);
		fogueira = GameObject.Find("FaiscaB"+aleatorio);
		fogueira.GetComponent<Renderer>().enabled = true;

		aleatorio = Random.Range(1,6);
		fogueira = GameObject.Find("FaiscaC"+aleatorio);
		fogueira.GetComponent<Renderer>().enabled = true;

		aleatorio = Random.Range(1,6);
		fogueira = GameObject.Find("FaiscaD"+aleatorio);
		fogueira.GetComponent<Renderer>().enabled = true;

		aleatorio = Random.Range(1,6);
		fogueira = GameObject.Find("FaiscaE"+aleatorio);
		fogueira.GetComponent<Renderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
