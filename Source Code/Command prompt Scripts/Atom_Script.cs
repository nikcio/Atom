using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class Atom_Script : MonoBehaviour
{

    private string[] Atoms;
    private string[] Isotops_split;
    private A_C[] name_A_C;
    public TextAsset Atom;
    public Text typer_1;
    public Text typer_2;
    public Text typer_3;
    public Text typer_4;
    public Text single_typer;
    public GameObject Next_button;
    public GameObject Next_button_2;

    void Awake()
    {
        string temp_atom = Atom.text;
        Atoms = temp_atom.Split('\n');
        Atoms[0] = "";
        Isotops_split = null;
        name_A_C = new A_C[Atoms.Length];
        Load_1();
    }

    private static int Active_gameobj = 1;
    public Text Searhbar;
    private static string Searhbar_s;

    public void Search(int Object_)
    {
        Searhbar_s = Searhbar.text;
        if (Object_ == 1)
        {
            Active_gameobj = 1;
        }
        else if (Object_ == 2)
        {
            Active_gameobj = 2;
        }
        else if (Object_ == 3)
        {
            if ((Searhbar_s == "") || !(Searhbar_s.Contains("-")))
            {
                goto END;
            }
            if (Active_gameobj == 1)
            {
                Load_2(Searhbar_s);
            }
            else if (Active_gameobj == 2)
            {
                Load_4(Searhbar_s);
            }
        }
    END:;
    }


    //loading
    public void Load_1()
    {
        List<string> Splitter = new List<string>();
        for (int iso = 1; iso < Atoms.Length; iso++)
        {
            Splitter = new List<string>();
            string[] Temp = this.Atoms[iso].Split(' ');
            for (int num = 0; num < Temp.Length; num++)
            {
                Splitter.Add(Temp[num]);
            }
            Isotops_split = Splitter.ToArray();
            name_A_C[iso] = new A_C();
            name_A_C[iso].SetName(Isotops_split[0]);
            name_A_C[iso].SetSName(Isotops_split[1]);
            name_A_C[iso].SetK_num(Int32.Parse(Isotops_split[2]));
            name_A_C[iso].SetP_num(Int32.Parse(Isotops_split[3]));
            name_A_C[iso].SetN_num(Int32.Parse(Isotops_split[4]));
            name_A_C[iso].SetRad(Isotops_split[5]);
        }

    }


    //Find
    public void Load_2(string Atom_)
    {
        OnStart = false;
        typer_1.text = "";
        typer_2.text = "";
        typer_3.text = "";
        typer_4.text = "";
        single_typer.text = "";
        Next_button.SetActive(false);
        Next_button_2.SetActive(false);
        string[] K_num_s = Atom_.Split('-');
        int K_num = Int32.Parse(K_num_s[1]);
        for (int e = 1; e < name_A_C.Length; e++)
        {
            if ((name_A_C[e].GetK_num() == K_num) && ((K_num_s[0] == name_A_C[e].GetSName()) || (K_num_s[0] == name_A_C[e].GetName())))
            {
                single_typer.text = '\n' + "Navn: " + name_A_C[e].GetName() + '\n' + "Kernetal: " + name_A_C[e].GetK_num() + '\n' + "Protoner: " + name_A_C[e].GetP_num() + '\n' + "Neutroner: " + name_A_C[e].GetN_num() + '\n'
                    + "Radioaktivitet: " + name_A_C[e].GetRad();
                break;
            }
        }
    }

    static int Temp_e;
    static bool Waiting = false;
    static bool OnStart = false;

    //all
    public void Load_3(bool waiting_off)
    {
        if (waiting_off == true)
        {
            Waiting = true;
        }
        typer_1.text = "";
        typer_2.text = "";
        typer_3.text = "";
        typer_4.text = "";
        single_typer.text = "";
        Next_button.SetActive(true);
        Next_button_2.SetActive(false);
        int Count = 0;
        int typer_count = 0;
        for (int e = 1; e < name_A_C.Length; e++)
        {
        Next_point:;
            if ((Waiting == false) && (OnStart == true))
            {
                Temp_e = e;
                break;
            }
            if (OnStart == true)
            {
                if (Waiting == true)
                {
                    OnStart = false;
                    e = Temp_e;
                }
                typer_count = 0;
            }
            Count++;
            if (typer_count == 0)
            {
                typer_1.text += "Navn: " + name_A_C[e].GetName() + '\n' + "Kernetal: " + name_A_C[e].GetK_num() + '\n' + "Protoner: " + name_A_C[e].GetP_num() + '\n' + "Neutroner: " + name_A_C[e].GetN_num() + '\n'
                    + "Radioaktivitet: " + name_A_C[e].GetRad() + '\n' + '\n';
            }
            else if (typer_count == 1)
            {
                typer_2.text += "Navn: " + name_A_C[e].GetName() + '\n' + "Kernetal: " + name_A_C[e].GetK_num() + '\n' + "Protoner: " + name_A_C[e].GetP_num() + '\n' + "Neutroner: " + name_A_C[e].GetN_num() + '\n'
                    + "Radioaktivitet: " + name_A_C[e].GetRad() + '\n' + '\n';
            }
            else if (typer_count == 2)
            {
                typer_3.text += "Navn: " + name_A_C[e].GetName() + '\n' + "Kernetal: " + name_A_C[e].GetK_num() + '\n' + "Protoner: " + name_A_C[e].GetP_num() + '\n' + "Neutroner: " + name_A_C[e].GetN_num() + '\n'
                    + "Radioaktivitet: " + name_A_C[e].GetRad() + '\n' + '\n';
            }
            else if (typer_count == 3)
            {
                typer_4.text += "Navn: " + name_A_C[e].GetName() + '\n' + "Kernetal: " + name_A_C[e].GetK_num() + '\n' + "Protoner: " + name_A_C[e].GetP_num() + '\n' + "Neutroner: " + name_A_C[e].GetN_num() + '\n'
                    + "Radioaktivitet: " + name_A_C[e].GetRad() + '\n' + '\n';
            }

            if (Count >= 4)
            {
                Count = 0;
                if (typer_count >= 4)
                {
                    Waiting = false;
                    OnStart = true;
                    goto Next_point;
                }
                typer_count++;
            }
        }
    }

    static int temp_1;
    static string temp_2;
    static bool temp_tester;

    //henfald
    public void Load_4(string Atom_)
    {
        OnStart = false;
        typer_1.text = "";
        typer_2.text = "";
        typer_3.text = "";
        typer_4.text = "";
        single_typer.text = "";
        Next_button.SetActive(false);
        int Count = 0;
        int typer_count = 0;
        string[] K_num_s = Atom_.Split('-');
        int K_num = Int32.Parse(K_num_s[1]);
        string[] Temp_container = new string[5];
        bool First = false;
        int ab = 0;
        if (temp_tester == true)
        {
            K_num_s[0] = temp_2;
            K_num = temp_1;
        }
        for (int e = 1; e < name_A_C.Length; e++)
        {
            if ((name_A_C[e].GetK_num() == K_num) && ((K_num_s[0] == name_A_C[e].GetSName()) || (K_num_s[0] == name_A_C[e].GetName())))
            {
            TOP:;
                if (Count >= 7)
                {
                    Count = 0;
                    if (typer_count >= 4)
                    {
                        if (name_A_C[ab].GetRad() != "S\r")
                        {
                            temp_1 = name_A_C[ab].GetK_num();
                            temp_2 = name_A_C[ab].GetSName();
                            temp_tester = true;
                            Next_button_2.SetActive(true);
                        }
                        break;
                    }
                    typer_count++;
                }
                if (First == false)
                {
                    First = true;
                    Temp_container[0] = name_A_C[e].GetSName();
                    Temp_container[1] = name_A_C[e].GetK_num().ToString();
                    Temp_container[2] = name_A_C[e].GetRad();
                    Temp_container[3] = name_A_C[e].GetP_num().ToString();
                    Temp_container[4] = name_A_C[e].GetN_num().ToString();
                    if (typer_count == 0)
                    {
                        typer_1.text += '\n' + (name_A_C[e].GetK_num() - 10) + "|" + name_A_C[e].GetP_num() + " " + name_A_C[e].GetSName() + '\n' + " (Radioakvitet: " + name_A_C[e].GetRad() + ")";
                    }
                    if (name_A_C[e].GetRad() == "B-\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) + 1;
                        int Temp_n = Int32.Parse(Temp_container[4]) - 1;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + e-" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else if (name_A_C[e].GetRad() == "B+\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) - 1;
                        int Temp_n = Int32.Parse(Temp_container[4]) + 1;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + p+" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else if (name_A_C[e].GetRad() == "A\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) - 2;
                        int Temp_n = Int32.Parse(Temp_container[4]) - 2;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + 4|2 He" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else
                    {
                        if (typer_count == 0)
                        {
                            typer_1.text += '\n' + "________________";
                        }
                        Count++;
                        break;
                    }
                }
                else
                {
                    Temp_container[0] = name_A_C[ab].GetSName();
                    Temp_container[1] = name_A_C[ab].GetK_num().ToString();
                    Temp_container[2] = name_A_C[ab].GetRad();
                    Temp_container[3] = name_A_C[ab].GetP_num().ToString();
                    Temp_container[4] = name_A_C[ab].GetN_num().ToString();
                    if (typer_count == 0)
                    {
                        typer_1.text += '\n' + (name_A_C[ab].GetK_num() - 10) + "|" + name_A_C[ab].GetP_num() + " " + name_A_C[ab].GetSName() + '\n' + " (Radioakvitet: " + name_A_C[ab].GetRad() + ")";
                    }
                    else if (typer_count == 1)
                    {
                        typer_2.text += '\n' + (name_A_C[ab].GetK_num() - 10) + "|" + name_A_C[ab].GetP_num() + " " + name_A_C[ab].GetSName() + '\n' + " (Radioakvitet: " + name_A_C[ab].GetRad() + ")";
                    }
                    else if (typer_count == 2)
                    {
                        typer_3.text += '\n' + (name_A_C[ab].GetK_num() - 10) + "|" + name_A_C[ab].GetP_num() + " " + name_A_C[ab].GetSName() + '\n' + " (Radioakvitet: " + name_A_C[ab].GetRad() + ")";
                    }
                    else if (typer_count == 3)
                    {
                        typer_4.text += '\n' + (name_A_C[ab].GetK_num() - 10) + "|" + name_A_C[ab].GetP_num() + " " + name_A_C[ab].GetSName() + '\n' + " (Radioakvitet: " + name_A_C[ab].GetRad() + ")";
                    }
                    Count++;
                    if (name_A_C[ab].GetRad() == "B-\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) + 1;
                        int Temp_n = Int32.Parse(Temp_container[4]) - 1;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + e-" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 1)
                                {
                                    typer_2.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + e-" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 2)
                                {
                                    typer_3.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + e-" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 3)
                                {
                                    typer_4.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + e-" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else if (name_A_C[ab].GetRad() == "B+\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) - 1;
                        int Temp_n = Int32.Parse(Temp_container[4]) + 1;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + p+" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 1)
                                {
                                    typer_2.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + p+" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 2)
                                {
                                    typer_3.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + p+" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 3)
                                {
                                    typer_4.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + p+" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else if (name_A_C[ab].GetRad() == "A\r")
                    {
                        int Temp_p = Int32.Parse(Temp_container[3]) - 2;
                        int Temp_n = Int32.Parse(Temp_container[4]) - 2;
                        for (int a = 1; a < name_A_C.Length; a++)
                        {
                            if ((name_A_C[a].GetN_num() == Temp_n) && (name_A_C[a].GetP_num() == Temp_p))
                            {
                                Temp_container[0] = name_A_C[a].GetSName();
                                Temp_container[1] = name_A_C[a].GetK_num().ToString();
                                Temp_container[2] = name_A_C[a].GetRad();
                                Temp_container[3] = name_A_C[a].GetP_num().ToString();
                                Temp_container[4] = name_A_C[a].GetN_num().ToString();
                                if (typer_count == 0)
                                {
                                    typer_1.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + 4|2 He" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 1)
                                {
                                    typer_2.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + 4|2 He" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 2)
                                {
                                    typer_3.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + 4|2 He" + '\n' + "________________" + '\n';
                                }
                                else if (typer_count == 3)
                                {
                                    typer_4.text += '\n' + "=" + '\n' + name_A_C[a].GetK_num() + "|" + name_A_C[a].GetP_num() + " " + name_A_C[a].GetSName() + " + 4|2 He" + '\n' + "________________" + '\n';
                                }
                                Count++;
                                ab = a;
                                goto TOP;
                            }
                        }
                    }
                    else
                    {
                        if (typer_count == 0)
                        {
                            typer_1.text += '\n' + "________________" + '\n';
                        }
                        else if (typer_count == 1)
                        {
                            typer_2.text += '\n' + "________________" + '\n';
                        }
                        else if (typer_count == 2)
                        {
                            typer_3.text += '\n' + "________________" + '\n';
                        }
                        else if (typer_count == 3)
                        {
                            typer_4.text += '\n' + "________________" + '\n';
                        }
                        Count++;
                        break;
                    }
                }//end of if
            }
        }
    }

    class A_C
    {
        private string Name;
        private string S_Name;
        private int Atomkerne_num;
        private int Proton_num;
        private int Neutron_num;
        private string Radiation;

        public A_C()
        {

        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetSName(string name)
        {
            this.S_Name = name;
        }
        public string GetSName()
        {
            return S_Name;
        }
        public void SetK_num(int Num)
        {
            this.Atomkerne_num = Num;
        }
        public int GetK_num()
        {
            return Atomkerne_num;
        }
        public void SetP_num(int Num)
        {
            this.Proton_num = Num;
        }
        public int GetP_num()
        {
            return Proton_num;
        }
        public void SetN_num(int Num)
        {
            this.Neutron_num = Num;
        }
        public int GetN_num()
        {
            return Neutron_num;
        }
        public void SetRad(string Rad)
        {
            this.Radiation = Rad;
        }
        public string GetRad()
        {
            return Radiation;
        }
    }
}