using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRay : MonoBehaviour
{
    public bool WallJudge = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.gameObject.transform.position, this.gameObject.transform.forward); ;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20.0f))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                //Debug.Log(hit.collider.gameObject.layer);
                WallJudge = true;
            }
            else if (hit.collider.gameObject.layer != 8)
            {
                WallJudge = false;
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red, 0.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !WallJudge)
        {
            Debug.Log("Found!");
        }
    }


}
