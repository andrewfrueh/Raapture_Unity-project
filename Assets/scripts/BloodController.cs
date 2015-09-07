using UnityEngine;
using System.Collections;

public class BloodController : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

	public void Reset(){
		//GetComponent<Animator> ().SetBool ("active", false);

	}

	public void KillMe(){
		Destroy (gameObject);
	}


}

