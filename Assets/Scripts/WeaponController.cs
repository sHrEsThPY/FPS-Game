using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    [Header("Ammo Settings")]
    public int magSize = 30;
    public int currentMag;
    public int totalAmmo = 90;
    public float reloadTime = 1.5f;
    private bool isReloading = false;

    [Header("General Settings")]
    public float damage = 10f; 
    public float range = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    [Header("UI & Effects")]
    public Text ammoText;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GameObject bulletHole;
    public AudioClip fireSound;
    public AudioClip reloadSound;

    [Header("Setup")]
    public Camera weaponCam;

    private AudioSource Source;

    void Start()
    {
        currentMag = magSize;
        Source = GetComponent<AudioSource>();
        if (Source == null) Source = gameObject.AddComponent<AudioSource>();
        UpdateUI();
    }

    void Update()
    {
        if (isReloading) return;

        if (currentMag <= 0 && totalAmmo > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentMag < magSize && totalAmmo > 0)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentMag > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        currentMag--;
        UpdateUI();

        if (muzzleFlash != null)
        {
            muzzleFlash.Stop();
            muzzleFlash.Play(true);
        }

        if (fireSound != null && Source != null)
            Source.PlayOneShot(fireSound);

        RaycastHit hit;
        if (weaponCam != null && Physics.Raycast(weaponCam.transform.position, weaponCam.transform.forward, out hit, range))
        {
            // Target Detection Logic
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (bulletHole != null)
            {
                GameObject hole = Instantiate(bulletHole, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
                Destroy(hole, 5f);
            }

            if (impactEffect != null)
            {
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        if (reloadSound != null && Source != null) Source.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime);
        int bulletsNeeded = magSize - currentMag;
        int bulletsToSubtract = Mathf.Min(totalAmmo, bulletsNeeded);
        totalAmmo -= bulletsToSubtract;
        currentMag += bulletsToSubtract;
        isReloading = false;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (ammoText != null) ammoText.text = currentMag + " / " + totalAmmo;
    }
}