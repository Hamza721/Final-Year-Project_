using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropening : MonoBehaviour {
    private Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
		
	}
    private void OnTriggerEnter(Collider other)
    {
        print(" ----------------------------------enteredd");
        if (other.tag == "boy")
        {
            _animator.SetBool("start", true);
        }
        if (other.tag == "theif")
        {
            _animator.SetBool("start", true); 
        }
        if (other.tag == "housewife")
        {
            _animator.SetBool("start", true);
        }
        if (other.tag == "gentleman")
        {
            _animator.SetBool("start", true);
        }
    }
   private void OnTriggerExit(Collider other)
    {
        if (other.tag == "boy")
        {
            _animator.SetBool("start", false);
        }
        if (other.tag == "theif")
        {
            _animator.SetBool("start", false);
        }
        if (other.tag == "housewife")
        {
            _animator.SetBool("start", false);
        }
        if (other.tag == "gentleman")
        {
            _animator.SetBool("start", false);
        }
    }

    // Update is called once per frame
    void Update () {
        //_animator.SetBool("start", true);

    }
}
