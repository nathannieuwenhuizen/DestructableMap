using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// This script is responsible for calculating and substracting the sprites 
/// alpha with the circlecollider and updates the polygoncollider.
/// </summary>
public class DestructibleSprite : MonoBehaviour, ITagCollider{

    
	private SpriteRenderer spriteRenderer;
	private float widthWorld, heightWorld;
	private int widthPixel, heightPixel;
	private Color zeroAlphaColor; 
    [SerializeField]
    private Texture2D texture;
	void Start(){
        //declares the variables needed for the next functions.
        zeroAlphaColor = new Color(0f, 0f, 0f, 0f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //makes a copy of the texture and uses the clone for editing the sprite when it is updated.
        //Making sure the sprite will be back to normal when reloading.
        Texture2D tex = texture;
		Texture2D tex_clone = (Texture2D) Instantiate(tex);
		spriteRenderer.sprite = Sprite.Create(tex_clone, 
		                          new Rect(0f, 0f, tex.width, tex.height),
		                          new Vector2(0.5f, 0.5f), 100f);

        GetSpriteInfo();
        SubstractSpritesAlpha(GetComponent<CircleCollider2D>());
        UpdateSpriteCollider();
    }

    //declared the widths and heights of the sprites texture and bounds.
    private void GetSpriteInfo() {
		widthWorld = spriteRenderer.bounds.size.x;
		heightWorld = spriteRenderer.bounds.size.y;
		widthPixel = spriteRenderer.sprite.texture.width;
		heightPixel = spriteRenderer.sprite.texture.height;
	}

    //interface of ITagCollider 
    public void OnCollision( CircleCollider2D cc)
    {
        //calls the SubstractSpriteAlpha function.
        SubstractSpritesAlpha(cc);
    }

    //Here will all the pixel coordinates be calculated and made the alpha of the pixel zero.
    public void SubstractSpritesAlpha( CircleCollider2D cc ){

        //declares the positions of the pixel from the worldposition where the cc collides. (if collides)
		V2int c = World2Pixel(cc.bounds.center.x, cc.bounds.center.y);

        //the radius of the irlce is declared.
		int radius = Mathf.RoundToInt(cc.bounds.size.x*widthPixel/widthWorld);
		int x, y, posX, negativePosX, posY, negativePosY, d;
		

        // in these two for loops every pixel coordinate is calculated and made transparent.
		for (x = 0; x <= radius; x++)
		{
			d = (int)Mathf.RoundToInt(Mathf.Sqrt(radius * radius - x * x));
			
			for (y = 0; y <= d; y++)
			{
				posX = c.x + x;
				negativePosX = c.x - x;
				posY = c.y + y;
				negativePosY = c.y - y;

				spriteRenderer.sprite.texture.SetPixel(posX, posY, zeroAlphaColor);
				spriteRenderer.sprite.texture.SetPixel(negativePosX, posY, zeroAlphaColor);
				spriteRenderer.sprite.texture.SetPixel(posX, negativePosY, zeroAlphaColor);
				spriteRenderer.sprite.texture.SetPixel(negativePosX, negativePosY, zeroAlphaColor);
			}
		}

        //sprite renderer is applied.
		spriteRenderer.sprite.texture.Apply();

        //updates the collider.
        UpdateSpriteCollider();
	}

    void UpdateSpriteCollider()
    {
        //Polygon collider is updated.
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    //World2Pixel calculates the worldpositions into the pixel coordinates.
	private V2int World2Pixel(float x, float y) {
		V2int v = new V2int();
		
		float dx = x-transform.position.x;
		v.x = Mathf.RoundToInt(0.5f*widthPixel+ dx*widthPixel/widthWorld);
		
		float dy = y - transform.position.y;
		v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);
		
		return v;
	}
}
