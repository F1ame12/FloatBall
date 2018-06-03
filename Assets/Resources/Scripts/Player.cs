using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FloatBall
{
    public class Player : MonoBehaviour
    {
        int lifeCount;
        float speed = 5f;
        DataRecorder datarecorder;
        
        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value < 0f)
                {
                    this.speed = 0f;
                }
                this.speed = value;
            }
        }

        public int LifeCount
        {
            get
            {
                return lifeCount;
            }
            set
            {
                lifeCount = value;
            }
        }

        private void Start()
        {
            lifeCount = 10;
            datarecorder = GameObject.Find("Main Camera").GetComponent<DataRecorder>();
            datarecorder.LifeCount = lifeCount;
        }

        public void OnMyTrigger(string type, Collider2D collider)
        {
            if (type != null && type.Equals("Touched"))
            {
                CircleCollider2D other = collider as CircleCollider2D;
                if (other.gameObject.tag.Equals("Bullet"))
                {
                    if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                    {
                        Debug.Log("Player:  Get Hurt!");
                        Destroy(other.gameObject);
                        if (lifeCount-1 == 0)
                        {
                            datarecorder.OpenData = false;

                            //Time.timeScale = 0;
                            Cursor.SetCursor(null, new Vector2(0f, 0f), CursorMode.Auto);
                            GameObject.Find("FailMenu").GetComponent<FailMenuScript>().ShowFailMenu();
                        }
                        else
                        {
                            lifeCount--;
                            datarecorder.LifeCount--;
                        }
                        
                    }
                }
            }
        }

    }

}

