using UnityEngine;

public class ActivateTrigger : MonoBehaviour {
	public enum Mode {
		Trigger   = 0, // Just broadcast the action on to the target
		Replace   = 1, // replace target with source
		Activate  = 2, // Activate the target GameObject
		Enable    = 3, // Enable a component
		Animate   = 4, // Start animation on target
		Deactivate= 5, // Decativate target GameObject
		ContaPonto= 6 // Controla trilha de fogos

	}
	
	/// The action to accomplish
	public Mode action = Mode.Activate;
	
	/// The game object to affect. If none, the trigger work on this game object
	public Object target;
	public GameObject source;
	public int triggerCount = 0;///
	public bool repeatTrigger = false;
	private GameObject Pont;

	public AudioSource[] sounds;
	public AudioSource noise1;
	public AudioSource noise2;

	void Start()
	{
		sounds = GetComponents<AudioSource>();
		noise1 = sounds[0];
		noise2 = sounds[1];



	}


	
	void DoActivateTrigger () {

		triggerCount++;
		
		if (triggerCount == 1 || repeatTrigger) {
			Object currentTarget = target != null ? target : gameObject;
			Behaviour targetBehaviour = currentTarget as Behaviour;
			GameObject targetGameObject = currentTarget as GameObject;
			if (targetBehaviour != null)
				targetGameObject = targetBehaviour.gameObject;
			GUIText texto = (GUIText)FindObjectOfType(typeof(GUIText));//Busca um objeto na tela 
			switch (action) {
			case Mode.Trigger:
				targetGameObject.BroadcastMessage ("DoActivateTrigger");
				break;
			case Mode.Replace:
				if (source != null) {
					Object.Instantiate (source, targetGameObject.transform.position, targetGameObject.transform.rotation);
					DestroyObject (targetGameObject);
				}
				break;
			case Mode.Activate:
				targetGameObject.SetActive(true);
				break;
			case Mode.Enable:
				if (targetBehaviour != null)
					targetBehaviour.enabled = true;
				break;	
			case Mode.Animate:
				targetGameObject.GetComponent<Animation>().Play ();
				break;	
			case Mode.Deactivate:
				targetGameObject.SetActive(false);
				break;
			case Mode.ContaPonto:
				if(texto != null && targetGameObject.GetComponent<Renderer>().enabled) // Verifica se o GuiText esta vazio e se o objeto esta na tela
				{					
					//PONTUAÇAO
					string pontuacaoaux = texto.text;//pontuacaoaux recebe texto.text
					pontuacaoaux = pontuacaoaux.Replace("Pontos:",string.Empty); //pontuacaaux recebe ela mesma, com o que vai aparecer na tela e atribui a ela a pontuaçao
					int auxpontuacao = int.Parse (pontuacaoaux);//Separa a Pontuaçao do inteiro que vai ficar incrementando.
					auxpontuacao ++;//soma mais um a pontuaçao
					texto.text = "Pontos:" + auxpontuacao.ToString();//Coloca o texto "Pontos" de volta, junto ao numero de pontos
					
					//FOGUEIRA
					string nomeDaFogueiraAtual = targetGameObject.name; // nomeDoCuboAtual recebe o nome do target  
					string prefixo = nomeDaFogueiraAtual.Substring(6,1);
					nomeDaFogueiraAtual = nomeDaFogueiraAtual.Substring(7,1);// nomeDaFogueiraAtual vai ser substituido por apenas o nome do fogo e um espaço vazio 
					int ordemFogueira = int.Parse (nomeDaFogueiraAtual);//ordemCubo recebe o valor do cubo
					ordemFogueira ++;// incrementa o valor do cubo
					targetGameObject.GetComponent<Renderer>().enabled = false; //desativa o target
					
					
					if(ordemFogueira == 6)// se a fogueira for igual a "6"
					{
						GameObject primeiraFogueira = GameObject.Find("Faisca"+prefixo+"1");// captura o fogoX1, transformando-o em GameObject
						primeiraFogueira.GetComponent<Renderer>().enabled = true;// ativa o o fogo X1
					}
					else
					{
						string nomeDaProximaFogueira = "Faisca"+ prefixo + ordemFogueira.ToString();//nomeDoProximoCubo recebe a string "Faisca" mais o valor dele
						GameObject proxfogo = GameObject.Find(nomeDaProximaFogueira); // proxfogo recebe o nome da proxima fogueira
						proxfogo.GetComponent<Renderer>().enabled=true;//ativa proxfogo
					}
					noise1.Play();

					//if(proxfogo.enabled )
					
				}
				break;
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {
		DoActivateTrigger ();
	}
} 
