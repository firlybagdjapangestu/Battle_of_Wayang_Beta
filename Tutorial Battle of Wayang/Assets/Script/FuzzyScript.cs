using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyScript : MonoBehaviour
{
    [SerializeField] private int[] penandaOperator;
    [SerializeField] private bool[] penandaPrilaku;

    //inputan hp
    [SerializeField] public float[] fuzifikasiHP;
    [SerializeField] private float bawahHP, atasHP;

    //inputan jarak
    [SerializeField] public float[] fuzifikasiJarak;
    [SerializeField] private float jauh;

    //
    [SerializeField] public float[] a;
    [SerializeField] public float[] z;

    //output
    [SerializeField] public float prilaku;
    // Start is called before the first frame update
    void Start()
    {
        a = new float[fuzifikasiHP.Length * fuzifikasiJarak.Length];
        z = new float[a.Length];
        penandaOperator = new int[a.Length];
        penandaPrilaku = new bool[a.Length];
    }


    public float Fuzzy(float hp, float jarak)
    {
        // ======== proses fuzzifikasi ==========
        //fuzifiasi hp
        //sedikit
        if (hp <= bawahHP)
        {
            //menurun
            fuzifikasiHP[0] = 1; // sedikit
            fuzifikasiHP[1] = 0;
            fuzifikasiHP[2] = 0;
        }
        // sedang
        else if (hp>bawahHP && hp<atasHP)
        {
            // naik
            if(hp>bawahHP && hp < ( (atasHP+bawahHP)/2) )
            {
                fuzifikasiHP[0] = ((atasHP + bawahHP)/2 - hp) / (45 - bawahHP); 
                fuzifikasiHP[1] = (hp - bawahHP) / ((atasHP + bawahHP) / 2 - bawahHP);
                fuzifikasiHP[2] = 0;
            }
            // turun
            else if (hp>((atasHP + bawahHP) / 2) && hp < atasHP)
            {
                fuzifikasiHP[0] = 0;
                fuzifikasiHP[1] = (atasHP - hp) / (atasHP - (atasHP + bawahHP) / 2); 
                fuzifikasiHP[2] = (hp - (atasHP + bawahHP) / 2) / (atasHP - (atasHP + bawahHP) / 2); 
            }
        }
        // banyak
        else
        {
            // naik
            fuzifikasiHP[0] = 0;
            fuzifikasiHP[1] = 0;
            fuzifikasiHP[2] = 1;
        }


        //fuzifikasi jarak
        if (jarak >= jauh)
        {
            //jauh
            fuzifikasiJarak[0] = 0;
            fuzifikasiJarak[1] = 1; // jauh
        }
        else
        {
            //dekat
            fuzifikasiJarak[0] = 1;
            fuzifikasiJarak[1] = 0;
        }


        // ======== proses inferensi ==========
        int i = a.Length - 1;
        while (i > 0)
        {
            for (int j = 0; j < fuzifikasiHP.Length; j++)
            {
                for (int k = 0; k < fuzifikasiJarak.Length; k++)
                {
                    if(penandaOperator[i] == 0)
                    {
                        //and
                        a[i] = Mathf.Min(fuzifikasiHP[j], fuzifikasiJarak[k]);
                        i--;
                    }
                    else if(penandaOperator[i] == 1)
                    {
                        //or
                        a[i] = Mathf.Max(fuzifikasiHP[j], fuzifikasiJarak[k]);
                        i--;
                    }
                    else if (penandaOperator[i] == 2)
                    {
                        //not
                        a[i] = 1 - Mathf.Max(fuzifikasiHP[j], fuzifikasiJarak[k]);
                        i--;
                    }
                    
                }
            }
        }
       
        for (i = 0; i < a.Length; i++)
        {
            // Agresif
            if (penandaPrilaku[i])
            {
                if (a[i] >= 1)
                {
                    z[i] = 100;

                }
                else if (a[i] <= 0)
                {
                    z[i] = 50;
                }
                else
                {
                    z[i] = 50 + ((100 - 50) * a[i]);
                }
            }
            else
            {
                if (a[i] >= 1)
                {
                    z[i] = 50;

                }
                else if (a[i] <= 0)
                {
                    z[i] = 100;
                }
                else
                {
                    z[i] = 100 - ((100 - 50) * a[i]);
                }
            }
            

        }


        // ======== proses defuzzifikasi ==========
        float pembagi = 0;
        float penyebut = 0;
        foreach (float sumA in a)
        {           
            pembagi += sumA;            
        }
        for (int x = 0; x < a.Length; x++)
        {
            penyebut += a[x] * z[x];
        }

        prilaku = penyebut / pembagi;

        return prilaku;
    }
}
