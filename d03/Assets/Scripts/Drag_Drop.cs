using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Drag_Drop : MonoBehaviour {
	public GameObject turret;
    private bool dragging = false;
    private float distance;
	public GameObject canvas;
	private GameObject img;
	private GameObject[] empty;
	public GameObject overlay;
	public GameObject overlayTrue;

	void Start(){
		empty = GameObject.FindGameObjectsWithTag("empty"); 
	}
     void OnMouseDown()
    {
		if (gameManager.gm.playerEnergy >= turret.GetComponent<towerScript>().energy)
		{
			img = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
			img.gameObject.GetComponent<BoxCollider2D>().enabled = false;
			distance = Vector3.Distance(transform.position, Camera.main.transform.position);
			dragging = true;
		}
    }
 
    void OnMouseUp()
    {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit)
		{
			if (hit.collider.tag == "empty")
			{
				if (gameManager.gm.playerEnergy >= turret.GetComponent<towerScript>().energy)
				{
					gameManager.gm.playerEnergy -= turret.GetComponent<towerScript>().energy;
					img.transform.position = hit.collider.gameObject.transform.position;
					GameObject tower =  GameObject.Instantiate(turret, img.transform.position, img.transform.rotation);
					MenuUpgrade upgrade = GameObject.Instantiate(overlay, img.transform.position, img.transform.rotation, turret.transform.parent).GetComponent<MenuUpgrade>();
					upgrade.transform.position -= new Vector3(0, 0, 1);
					upgrade.tower = tower.GetComponent<towerScript>();
					GameObject overlayTrue_g = Instantiate(overlayTrue, img.transform.position, img.transform.rotation, canvas.transform);
					// overlayTrueClone.GetComponent<RectTransform>().off = upgrade.tower.GetComponent<RectTransform>();
					// overlayTrueClone.GetComponent<RectTransform>().position = upgrade.tower.transform.position;
					overlayTrue_g.GetComponent<RectTransform>().position = upgrade.tower.transform.position;
					overlayTrue_g.SetActive(false);
					overlayTrue_g.GetComponent<Overlay>().turret = tower;
					upgrade.overlay = overlayTrue_g;
					overlayTrue_g.GetComponent<Overlay>().overlayHitBox = upgrade.gameObject;
				}
			}
		}
		Destroy(img.gameObject);
        dragging = false;
    }
 
    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            img.transform.position = rayPoint;
        }
    }
}
