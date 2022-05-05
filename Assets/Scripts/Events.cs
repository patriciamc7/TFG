using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Events : MonoBehaviour
{
    public Material material;
    public Material materialPink;
    public Material materialGreen;
    public Material materialBlue;

    public Material TrailWhiteLight;
    public Material TrailBlueLight;
    public Material TrailGreenLight;
    public Material TrailPinkLight;

    public Material TrailWhiteDark;
    public Material TrailBlueDark;
    public Material TrailGreenDark;
    public Material TrailPinkDark;

    private ParticleSystem fireflies = null;
    private bool isFlower = false;
    private GameObject flower;

    private Transform mesh;
    private Transform wingLeft;
    private Transform wingRight;
    private Transform Trail;
    private Transform TrailDark;
    private Transform TrailLight;
    private ParticleSystem[] TrailParticle;
    private VisualEffect[] Effects;

    private void Start()
    {
        mesh = this.transform.Find("mesh");
        wingLeft = mesh.Find("wing_left");
        wingRight = mesh.Find("wing_left1");
        Trail = this.transform.Find("Trail");
        TrailDark = Trail.transform.Find("TrailDark");
        TrailLight = Trail.transform.Find("TrailLight");
        TrailParticle = Trail.gameObject.GetComponentsInChildren<ParticleSystem>();
        Effects = Trail.gameObject.GetComponentsInChildren<VisualEffect>();


    }
    void Update()
    {
        if (fireflies!=null)
        {
            fireflies.transform.position = Vector3.Lerp(fireflies.transform.position, this.transform.position, 0.05f);
            Object.Destroy(fireflies.gameObject, 5.0f);
        }
        if(flower != null)
        {
            flower.transform.position = Vector3.Lerp(flower.transform.position, this.transform.position, 0.05f);
        }
       
    }
    public void OnTriggerEnter(Collider other)
    {

        //Chest event
        if (other.gameObject.CompareTag("Chest"))
        {
            ParticleSystem fireflies = other.transform.parent.GetComponentInChildren<ParticleSystem>();

            Transform child = other.transform.Find("Base");
            ParticleSystem light = child.gameObject.GetComponentInChildren<ParticleSystem>();
            if (other != null)
            {
                other.GetComponent<AudioSource>().Play();
                Animator anim = other.GetComponent<Animator>();
                if (anim != null)
                    anim.Play("Animated PBR Chest _Opening_UnCommon");
                if (fireflies != null)
                {
                    fireflies.GetComponent<AudioSource>().Play();
                    fireflies.Play();
                }
                if (light != null)
                    StartCoroutine(DelayedAnimation(light, 0.8f));
            }
        }

        //Fountain event
        if (other.gameObject.CompareTag("fountain"))
        {
            ParticleSystem[] water = other.transform.parent.GetComponentsInChildren<ParticleSystem>();
            if (water != null)
            {
                for (int i = 0; i < water.Length; i++)
                {
                    water[i].Play();
                }
                other.GetComponent<AudioSource>().Play();
            }
        }

        //Crystal event
       
        if (other.gameObject.CompareTag("WhiteCrystal"))
        {
            if (other != null)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
                if (mesh != null)
                    mesh.gameObject.GetComponent<Renderer>().material = material;
                if (wingLeft != null)
                    wingLeft.gameObject.GetComponent<Renderer>().material = material;
                if (wingRight != null)
                    wingRight.gameObject.GetComponent<Renderer>().material = material;
                if(TrailDark != null)
                    TrailDark.gameObject.GetComponent<Renderer>().material = TrailWhiteDark;
                if (TrailLight != null)
                    TrailLight.gameObject.GetComponent<Renderer>().material = TrailWhiteLight;
                if (Trail != null)
                {
                    for (int i = 0; i < TrailParticle.Length; i++)
                    {
                        if (i == 0)
                        {
                            TrailParticle[i].Play();
                            Effects[i].Play();
                        }

                        else
                        {
                            TrailParticle[i].Stop();
                            Effects[i].Stop();
                        }
                    }
                }
                
            }
        }
        if (other.gameObject.CompareTag("PinkCrystal"))
        {
            if (other != null)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
                if (mesh != null)
                    mesh.gameObject.GetComponent<Renderer>().material = materialPink;
                if (wingLeft != null)
                    wingLeft.gameObject.GetComponent<Renderer>().material = materialPink;
                if (wingRight != null)
                    wingRight.gameObject.GetComponent<Renderer>().material = materialPink;
                if (TrailDark != null)
                    TrailDark.gameObject.GetComponent<Renderer>().material = TrailPinkDark;
                if (TrailLight != null)
                    TrailLight.gameObject.GetComponent<Renderer>().material = TrailPinkLight;
                if (Trail != null)
                {
                    for (int i = 0; i < TrailParticle.Length; i++)
                    {
                        if (i == 1)
                        {
                            TrailParticle[i].Play();
                            Effects[i].Play();
                        }
                        else
                        {
                            TrailParticle[i].Stop();
                            Effects[i].Stop();
                        }
                    }
                }


            }
        }
        if (other.gameObject.CompareTag("GreenCrystal"))
        {
            if (other != null)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
                if (mesh != null)
                    mesh.gameObject.GetComponent<Renderer>().material = materialGreen;
                if (wingLeft != null)
                    wingLeft.gameObject.GetComponent<Renderer>().material = materialGreen;
                if (wingRight != null)
                    wingRight.gameObject.GetComponent<Renderer>().material = materialGreen;
                if (TrailDark != null)
                    TrailDark.gameObject.GetComponent<Renderer>().material = TrailGreenDark;
                if (TrailLight != null)
                    TrailLight.gameObject.GetComponent<Renderer>().material = TrailGreenLight;
                if (Trail != null)
                {
                    for (int i = 0; i < TrailParticle.Length; i++)
                    {
                        if (i == 2)
                        {
                            TrailParticle[i].Play();
                            Effects[i].Play();
                        }
                        else
                        {
                            TrailParticle[i].Stop();
                            Effects[i].Stop();
                        }
                    }
                }

            }
        }
        if (other.gameObject.CompareTag("BlueCrystal"))
        {
           if (other != null)
           {
                other.gameObject.GetComponent<AudioSource>().Play();
                if (mesh != null)
                    mesh.gameObject.GetComponent<Renderer>().material = materialBlue;
                if (wingLeft != null)
                    wingLeft.gameObject.GetComponent<Renderer>().material = materialBlue;
                if (wingRight != null)
                    wingRight.gameObject.GetComponent<Renderer>().material = materialBlue;
                if (TrailDark != null)
                    TrailDark.gameObject.GetComponent<Renderer>().material = TrailBlueDark;
                if (TrailLight != null)
                    TrailLight.gameObject.GetComponent<Renderer>().material = TrailBlueLight;
                if (Trail != null)
                {
                    for (int i = 0; i < TrailParticle.Length; i++)
                    {
                        if (i == 3)
                        {
                            TrailParticle[i].Play();
                            Effects[i].Play();
                        }
                        else
                        {
                            TrailParticle[i].Stop();
                            Effects[i].Stop();
                        }
                    }
                }
            }
        }

        //Mushroom event
        if (other.gameObject.CompareTag("Mushroom"))
        {
           Animator anim = other.GetComponent<Animator>();
           if (anim != null)
            anim.Play("Grow");
        }

        //Fountain effects event
        if (other.gameObject.CompareTag("FountainEffect"))
        {
            ParticleSystem water = other.gameObject.GetComponentInChildren<ParticleSystem>();
            water.Play();
            other.GetComponent<AudioSource>().Play();
        }

        //Butterfly event
        if (other.gameObject.CompareTag("Orb"))
        {
            if (isFlower)
            {
                other.GetComponent<AudioSource>().Play();
                ParticleSystem[] orbs = other.gameObject.GetComponentsInChildren<ParticleSystem>();
                for (int i = 0; i < orbs.Length; i++)
                {
                    orbs[i].transform.localScale = new Vector3(2, 2, 2);
                }

                GameObject butterflyInstance = other.transform.parent.Find("Butterfly").gameObject;
                butterflyInstance.SetActive(true);
                Animator anim = butterflyInstance.GetComponent<Animator>();
                if (anim != null)
                    anim.Play("Fly");
                Destroy(flower);
                isFlower = false;
            }
        }

        //Flower grow
        if (other.gameObject.CompareTag("Grow"))
        {
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
                anim.Play("Grow");

        }

        //Frog event
        if (other.gameObject.CompareTag("Frog"))
        {
            Animator anim = other.GetComponent<Animator>();
            if (anim != null)
                anim.Play("Jump");
        }

        //Rabbit event
        if (other.gameObject.CompareTag("Branch"))
        {
           Animator anim = other.GetComponent<Animator>();
            if (anim != null)
                anim.Play("Hide");
        }
    }
    void OnTriggerExit(Collider other)
    {
        //Fireflies event
        if (other.gameObject.CompareTag("Fireflies"))
        {
            fireflies = other.transform.parent.GetComponentInChildren<ParticleSystem>();
        }
        //Flower event
        if (other.gameObject.CompareTag("Flower"))
        {
            if (!isFlower)
            {
                isFlower = true;
                flower = other.gameObject;
            }

        }
    }

    //The delay coroutine
    public IEnumerator DelayedAnimation(ParticleSystem ps, float time)
    {
        yield return new WaitForSeconds(time);
        ps.Play();
    }
}