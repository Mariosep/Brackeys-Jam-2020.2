using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public int fallen_height = 0;
    public bool falling = false;

    private Jumper targetJumper;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Height_Trigger"))
        {
            print("wqw");
            /*    if (targetJumper == null)
                {
                    targetJumper = collision.gameObject.GetComponent<Jumper>();
                    fallen_height++;
                }
                else if(targetJumper == collision.gameObject.GetComponent<Jumper>())
                {
                    fallen_height++;
                }
                else if (targetJumper != collision.gameObject.GetComponent<Jumper>())
                {
                    targetJumper = collision.gameObject.GetComponent<Jumper>();
                    fallen_height = 1;
                }
            }*/
        }
    }
}
