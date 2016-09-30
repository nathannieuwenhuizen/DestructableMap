using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class DestructibleSprite : MonoBehaviour, ITagCollider{

	private SpriteRenderer sr;
	private float widthWorld, heightWorld;
	private int widthPixel, heightPixel;
	private Color zeroAlphaColor; 

	void Start(){
        zeroAlphaColor = new Color(0f, 0f, 0f, 0f);

        sr = GetComponent<SpriteRenderer>(); 

		Texture2D tex = (Texture2D) Resources.Load("ground");
		Texture2D tex_clone = (Texture2D) Instantiate(tex);
		sr.sprite = Sprite.Create(tex_clone, 
		                          new Rect(0f, 0f, tex.width, tex.height),
		                          new Vector2(0.5f, 0.5f), 100f);
        gameObject.AddComponent<PolygonCollider2D>();
        GetSpriteInfo();
	}


	private void GetSpriteInfo() {
		widthWorld = sr.bounds.size.x;
		heightWorld = sr.bounds.size.y;
		widthPixel = sr.sprite.texture.width;
		heightPixel = sr.sprite.texture.height;
	}

    public void OnCollision( CircleCollider2D cc)
    {
        DestroyGround(cc);
    }

    public void DestroyGround( CircleCollider2D cc ){
		V2int c = World2Pixel(cc.bounds.center.x, cc.bounds.center.y);
		int radius = Mathf.RoundToInt(cc.bounds.size.x*widthPixel/widthWorld);
        Debug.Log(radius);
		int x, y, posX, negativePosX, posY, negativePosY, d;
		
		for (x = 0; x <= radius; x++)
		{
			d = (int)Mathf.RoundToInt(Mathf.Sqrt(radius * radius - x * x));
			
			for (y = 0; y <= d; y++)
			{
				posX = c.x + x;
				negativePosX = c.x - x;
				posY = c.y + y;
				negativePosY = c.y - y;

				sr.sprite.texture.SetPixel(posX, posY, zeroAlphaColor);
				sr.sprite.texture.SetPixel(negativePosX, posY, zeroAlphaColor);
				sr.sprite.texture.SetPixel(posX, negativePosY, zeroAlphaColor);
				sr.sprite.texture.SetPixel(negativePosX, negativePosY, zeroAlphaColor);
			}
		}
		sr.sprite.texture.Apply();
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}

	private V2int World2Pixel(float x, float y) {
		V2int v = new V2int();
		
		float dx = x-transform.position.x;
		v.x = Mathf.RoundToInt(0.5f*widthPixel+ dx*widthPixel/widthWorld);
		
		float dy = y - transform.position.y;
		v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);
		
		return v;
	}
}
