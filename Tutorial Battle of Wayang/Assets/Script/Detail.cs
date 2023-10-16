using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detail : MonoBehaviour
{
    public Text hasil;
    public Text a;
    public Text z;
    public Text jarak;
    public Text hp;

    public fuzzy enemy;
    public FuzzyScript fuzzy;
    void Update()
    {
        hasil.text = "hasil : " + fuzzy.prilaku;

        a.text   = "Alpa Predikat" + Environment.NewLine
                 + "a1 : " + fuzzy.a[0] + Environment.NewLine
                 + "a2 : " + fuzzy.a[1] + Environment.NewLine
                 + "a3 : " + fuzzy.a[2] + Environment.NewLine
                 + "a4 : " + fuzzy.a[3] + Environment.NewLine
                 + "a5 : " + fuzzy.a[4] + Environment.NewLine
                 + "a6 : " + fuzzy.a[5] + Environment.NewLine;

        z.text   = "z Hasil" + Environment.NewLine
                 + "z1 : " + fuzzy.z[0] + Environment.NewLine
                 + "z2 : " + fuzzy.z[1] + Environment.NewLine
                 + "z3 : " + fuzzy.z[2] + Environment.NewLine
                 + "z4 : " + fuzzy.z[3] + Environment.NewLine
                 + "z5 : " + fuzzy.z[4] + Environment.NewLine
                 + "z6 : " + fuzzy.z[5] + Environment.NewLine;

        hp.text = "Health" + Environment.NewLine
                + "sedikit : " + fuzzy.fuzifikasiHP[0] + Environment.NewLine
                + "sedang  : " + fuzzy.fuzifikasiHP[1] + Environment.NewLine
                + "Banyak  : " + fuzzy.fuzifikasiHP[2] + Environment.NewLine;

        jarak.text = "Jarak" + Environment.NewLine
                   + "jauh   : " + fuzzy.fuzifikasiJarak[1] + Environment.NewLine
                   + "dekat  : " + fuzzy.fuzifikasiJarak[0] + Environment.NewLine;
    }
}
