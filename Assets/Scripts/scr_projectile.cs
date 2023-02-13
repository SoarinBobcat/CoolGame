using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_projectile : MonoBehaviour
{
	int spd = 12;
	float lifetime = 1.5f;
	Vector3 scale = Vector3.zero;
	
	public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		scale = new Vector3(lifetime,lifetime,lifetime);
		
        transform.Translate(Vector3.back*spd*Time.deltaTime);
		transform.localScale = scale;
		lifetime -= Time.deltaTime;
		
		if (lifetime <= 0)
			Destroy(this.gameObject);
    }
	
	void OnDestroy()
	{
		Instantiate(explosion,transform.position,transform.rotation);
	}
}
