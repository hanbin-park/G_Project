using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBoom : MonoBehaviour
{
    public ParticleSystem particleObject1;
    public ParticleSystem particleObject2;
    public ParticleSystem particleObject3;
    public ParticleSystem particleObject4;
    public ParticleSystem particleObject5;

    public void Boom()
    {
        Invoke("SoundPlay1",0.1f);
        Invoke("SoundPlay2",0.1f);
        Invoke("SoundPlay3",0.1f);
        Invoke("SoundPlay4",0.1f);
        Invoke("SoundPlay5",0.1f);
    }

    void SoundPlay1()
    {
        particleObject1.Play();
    }
    void SoundPlay2()
    {
        particleObject1.Play();
    }
    void SoundPlay3()
    {
        particleObject1.Play();
    }
    void SoundPlay4()
    {
        particleObject1.Play();
    }
    void SoundPlay5()
    {
        particleObject1.Play();
    }

}
