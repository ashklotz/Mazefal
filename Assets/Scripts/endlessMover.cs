using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Trey Klotz
 * Date: 12/13/2020
 * Description: controls movement of individual objects specific for endless mode
 */

public class endlessMover : MonoBehaviour
{
    private float speed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.5f;
        direction.Set(0, 0, -1.0f);
        //set the instantiated position
        this.gameObject.transform.position = new Vector3(0, 0, 12);
        //destroy after a couple seconds to not clog memory
        Destroy(this.gameObject, 25f);
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(direction * Time.deltaTime * speed);
    }
}
