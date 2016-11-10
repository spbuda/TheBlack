using UnityEngine;
using System.Collections;

public class SparkBullet : MonoBehaviour {

    private Rigidbody gunRB; //empty rigidbody variable that will hold the gun's rigidbody info

    void Start()
    {
        gunRB = GetComponent<Rigidbody>(); //grab the gun's rigidbody info
    }

    public GameObject shot; //variable to call the projectile to shoot. it gets the reference material by dragging the projectile prefab onto the PlayerController script (the way textures and materials are dragged onto meshes)
    public Transform shotSpawn; //location and rotation that the projectile is spawned
    public float fireRate = 0.5f; //how much time to add to nextFire to determine when you can next shoot your weapon in game time

    private float nextFire = 0.0f; //used to store in game time the next time you can fire your weapon

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) //checks that the fire button is being pressed, and then if enough time has passed since the last shot was fired
        {
            nextFire = Time.time + fireRate; //sets the next available time that a shot can be fired

            /*mouseLoc = Input.mousePosition;
            //mouseLoc.z = mouseLoc.y;
            //mouseLoc.y = 0.0f;
            //Debug.Log(mouseLoc); //making sure the game is getting the mouse position
            mouseLoc = Camera.main.ScreenToWorldPoint(mouseLoc);
            mouseLoc.y = 0.0f;
            //Debug.Log(mouseLoc); //making sure the game is getting the mouse position
            relMouseLoc = mouseLoc - gunRB.worldCenterOfMass;
            //Debug.Log(gunRB.worldCenterOfMass); //location of the shotSpawn
            Instantiate(shot, gunRB.position, Quaternion.LookRotation(relMouseLoc)); //we can use this instead of the code in the line above since we don't need to do anything with the shot after it is created, it will interact with the world on it's own
            */
            Instantiate(shot, gunRB.position, gunRB.rotation);
            //audioSource.Play();
            //Debug.Log(Quaternion.LookRotation(relMouseLoc));
            //GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject; //creates and assigns a new shot as a GameObject to clone so that it can be manipulated through the clone variable
        }
    }

}
