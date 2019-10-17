using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fun
{
    class Iso
    {
        private string path;
        private string[] Atoms;
        private string[] Isotops_split;
        private A_C[] name;

        public Iso()
        {
            path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Atom_container.txt");
            Atoms = File.ReadAllLines(path);
            Atoms[0] = "";
            Isotops_split = null;
            name = new A_C[Atoms.Length];
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
                name[iso] = new A_C();
                name[iso].SetName(Isotops_split[0]);
                name[iso].SetSName(Isotops_split[1]);
                name[iso].SetK_num(Int32.Parse(Isotops_split[2]));
                name[iso].SetP_num(Int32.Parse(Isotops_split[3]));
                name[iso].SetN_num(Int32.Parse(Isotops_split[4]));
                name[iso].SetRad(Isotops_split[5]);
            }
            
        }


        //Find
        public void Load_2(string Atom_)
        {
            string[] K_num_s = Atom_.Split('-');
            int K_num = Int32.Parse(K_num_s[1]);            
            for(int e = 1; e < name.Length; e++)
            {
                if ((name[e].GetK_num() == K_num) && ((K_num_s[0] == name[e].GetSName()) || (K_num_s[0] == name[e].GetName())))
                {
                    Console.WriteLine("Navn: " + name[e].GetName());
                    Console.WriteLine("Kernetal: " + name[e].GetK_num());
                    Console.WriteLine("Protoner: " + name[e].GetP_num());
                    Console.WriteLine("Neutroner: " + name[e].GetN_num());
                    Console.WriteLine("Radioaktivitet: " + name[e].GetRad());
                    break;
                }
            }
        }

        //all
        public void Load_3()
        {
            int Count = 0;
            for(int e = 1; e < name.Length; e++)
            {
                Count++;
                Console.WriteLine();
                Console.WriteLine("Navn: " + name[e].GetName());
                Console.Write("Kernetal: " + name[e].GetK_num());
                Console.Write(" | Protoner: " + name[e].GetP_num());
                Console.Write(" | Neutroner: " + name[e].GetN_num());
                Console.WriteLine(" | Radioaktivitet: " + name[e].GetRad());
                if(Count >= 10)
                {
                    Count = 0;
                    Console.WriteLine();
                    Console.WriteLine("Press for next 10...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Isotopes");
                }
            }
        }

        //henfald
        public void Load_4(string Atom_)
        {
            string[] K_num_s = Atom_.Split('-');
            int K_num = Int32.Parse(K_num_s[1]);
            string[] Temp_container = new string[5];
            bool First = false;
            int ab = 0;
            for (int e = 1; e < name.Length; e++)
            {
                if ((name[e].GetK_num() == K_num) && ((K_num_s[0] == name[e].GetSName()) || (K_num_s[0] == name[e].GetName())))
                {
                TOP:;
                    if (First == false)
                    {
                        First = true;
                        Temp_container[0] = name[e].GetSName();
                        Temp_container[1] = name[e].GetK_num().ToString();
                        Temp_container[2] = name[e].GetRad();
                        Temp_container[3] = name[e].GetP_num().ToString();
                        Temp_container[4] = name[e].GetN_num().ToString();
                        Console.WriteLine();
                        Console.WriteLine(name[e].GetK_num() + "|" + name[e].GetP_num() + " " + name[e].GetSName() + " (Radioakvitet: " + name[e].GetRad() + ")");
                        if (name[e].GetRad() == "B-")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) + 1;
                            int Temp_n = Int32.Parse(Temp_container[4]) - 1;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName() + " + e-");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else if (name[e].GetRad() == "B+")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) - 1;
                            int Temp_n = Int32.Parse(Temp_container[4]) + 1;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName()+ " + p+");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else if (name[e].GetRad() == "A")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) - 2;
                            int Temp_n = Int32.Parse(Temp_container[4]) - 2;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName()+ " + 4|2 He");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("_________________________");
                            break;
                        }
                    }
                    else
                    {
                        Temp_container[0] = name[ab].GetSName();
                        Temp_container[1] = name[ab].GetK_num().ToString();
                        Temp_container[2] = name[ab].GetRad();
                        Temp_container[3] = name[ab].GetP_num().ToString();
                        Temp_container[4] = name[ab].GetN_num().ToString();
                        Console.WriteLine();
                        Console.WriteLine(name[ab].GetK_num() + "|" + name[ab].GetP_num() + " " + name[ab].GetSName() + " (Radioakvitet: " + name[ab].GetRad() + ")");
                        if (name[ab].GetRad() == "B-")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) + 1;
                            int Temp_n = Int32.Parse(Temp_container[4]) - 1;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName() + " + e-");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else if (name[ab].GetRad() == "B+")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) - 1;
                            int Temp_n = Int32.Parse(Temp_container[4]) + 1;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName() + " + p+");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else if (name[ab].GetRad() == "A")
                        {
                            int Temp_p = Int32.Parse(Temp_container[3]) - 2;
                            int Temp_n = Int32.Parse(Temp_container[4]) - 2;
                            for (int a = 1; a < name.Length; a++)
                            {
                                if ((name[a].GetN_num() == Temp_n) && (name[a].GetP_num() == Temp_p))
                                {
                                    Temp_container[0] = name[a].GetSName();
                                    Temp_container[1] = name[a].GetK_num().ToString();
                                    Temp_container[2] = name[a].GetRad();
                                    Temp_container[3] = name[a].GetP_num().ToString();
                                    Temp_container[4] = name[a].GetN_num().ToString();
                                    Console.WriteLine("     =");
                                    Console.WriteLine(name[a].GetK_num() + "|" + name[a].GetP_num() + " " + name[a].GetSName() + " + 4|2 He");
                                    Console.WriteLine("_________________________");
                                    ab = a;
                                    goto TOP;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("_________________________");
                            break;
                        }
                    }//end of if
                }
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