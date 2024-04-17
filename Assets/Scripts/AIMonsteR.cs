using UnityEngine;
using System.Collections;

public class AIMonsteR : MonoBehaviour {

	public float seeDistance = 5f;
	public float attackDistance =2f;
	public float speed;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (Vector3.Distance (transform.position, target.transform.position) < seeDistance)
		{
			if (Vector3.Distance (transform.position, target.transform.position) > attackDistance)
			{
				transform.LookAt (target.transform);
				transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
				//gameObject.GetComponent<Animator>().SetTrigger("Move");
			}
		} else {

		}
	}
}