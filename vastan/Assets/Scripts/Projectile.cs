﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

	static float MIN_EXP_RADIUS = .2f;

    public bool alive = true;
    public bool hit_something = false;
    public bool hit_wall = false;
    public List<Color> exp_colors;
    public float decay_time = 0;
    public int fired_by;
    public int hit;
    public float score;


    public void restart_sound(float restart_time) {
        var sound = GetComponent<AudioSource>();
        if (sound && !sound.isPlaying && sound.isActiveAndEnabled) {
            sound.time = restart_time;
            sound.Play();
        }
    }

    public void decay(float decay_max) {
        decay_time += Time.deltaTime;
        if (decay_time > decay_max) {
            peterout();
        }
    }

    public void peterout() {
        alive = false;
    }

    public void asplode() {
        alive = false;
        hit_something = true;
    }

	public static float explosion_scale(float force, Vector3 dist) {
		if (dist.magnitude < Projectile.MIN_EXP_RADIUS)
			return force / Mathf.Pow(Projectile.MIN_EXP_RADIUS, 2f);
		return force / dist.sqrMagnitude;
	}

	public static Vector3 explosion_scale(Vector3 force, Vector3 dist) {
		if (dist.magnitude < Projectile.MIN_EXP_RADIUS)
			return force / Mathf.Pow(Projectile.MIN_EXP_RADIUS, 2f);
		return force / dist.sqrMagnitude;
	}
}
