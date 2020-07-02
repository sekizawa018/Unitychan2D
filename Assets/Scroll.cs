using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
	public float speed = 1.0f;
	public float startPosition;
	public float endPosition;
	public float maxX;
	public float minX;
	

    private void Start()
    {
	
    }


    void Update()
	{

		transform.Translate(0,speed * Time.deltaTime,0);


		if (transform.position.y >= endPosition) ScrollEnd();

       
	}

	void ScrollEnd()
	{

		transform.Translate(0,(endPosition - startPosition), 0);

        if (gameObject.tag == "DamageObject")
        {
			float ranX = Random.Range(minX, maxX);
			Vector3 pos = transform.localPosition;
			pos.x = ranX;
			pos.y += Random.Range(-1.0f, 1.0f);
			transform.localPosition = pos;
		}


		
	}
}