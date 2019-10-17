using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Diagnostics;
//using System.ComponentModel;

namespace Fun
{
    class Program
    {
        static string Input ="";
        static string[] Commands = { "Encrypt (Types: Hexadecimal[1], Binary[2] )", "Decrypt (Types: Hexadecimal[1], Binary[2])", "Iso" };
        static int Max_string = 301989888;
        
        static void Main(string[] args)
        {            
            #region Setings
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        #endregion

        Start_top:; // first part of the program
            Console.Clear();                    
            Console.WriteLine("Hello what can i do for you?");
            Input = Console.ReadLine();

            #region Help_input
            if ((Input == "?") || (Input == "help") || (Input == "Help") || (Input == "hElp") || (Input == "heLp") || (Input == "helP") || (Input == "HElp"))
            {
                Console.WriteLine();
                Help();
                Console.ReadKey();
            }
            #endregion

            else
            {
                #region Encrypt/Decrypt
                if (Input == "Encrypt")
                {
                Crypt_point:;
                    Console.Clear();
                    Console.WriteLine("Encrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: ");
                    string Crypt = Console.ReadLine();
                Type_point:;
                    Console.Clear();
                    Console.WriteLine("Encrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: ");
                    string Type_string = Console.ReadLine();
                Level_point:;
                    Console.Clear();
                    Console.WriteLine("Encrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: " + Type_string);
                    Console.WriteLine("Level: ");
                    string Level_string = Console.ReadLine();

                    int Crypt_type;
                    int Crypt_level;
                    if (Type_string == null)
                    {
                        goto Type_point;
                    }
                    if (Level_string == null)
                    {
                        goto Level_point;
                    }
                    if (Int32.TryParse(Type_string, out Crypt_type))
                    {
                        if (Int32.TryParse(Level_string, out Crypt_level))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Error: Try again");
                            Console.ReadKey();
                            goto Level_point;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Try again");
                        Console.ReadKey();
                        goto Type_point;
                    }

                    int Counter = Crypt.Length;
                    for (int i = 0; i < Crypt_level + 1; i++)
                    {
                        if(Crypt_type == 1)
                        {
                            Counter = Counter * 2;
                        }else if(Crypt_type == 2)
                        {
                            Counter = Counter * 8;
                        }

                        if(Counter >= Max_string)
                        {
                            Console.WriteLine("Error: Too much text. Try again");
                            Console.ReadKey();
                            goto Crypt_point;
                        }
                    }

                    if(Crypt_type == 1)
                    {
                        Counter += Counter / 2;
                    }else if(Crypt_type == 2)
                    {

                    }
                    
                    if(Counter >= Max_string)
                    {
                        Console.WriteLine("Error: Too much text. Try again");
                        Console.ReadKey();
                        goto Crypt_point;
                    }               

                    string Encrypted_text = Encrypt(Crypt, Crypt_type, Crypt_level);
                    Console.Clear();
                    Console.WriteLine("Encrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: " + Type_string);
                    Console.WriteLine("Level: " + Level_string);
                    Console.WriteLine();
                    Console.WriteLine("Result:");
                    Console.WriteLine(Encrypted_text);
                    string Exit = Console.ReadLine();
                    if(Exit == "Exit")
                    {
                        goto Start_top;
                    }
                    goto Crypt_point;
                }
                else if(Input == "Decrypt")
                {
                Crypt_Top:;
                    Console.Clear();
                    Console.WriteLine("Decrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: ");
                    string Crypt = Console.ReadLine();
                Type_point:;
                    Console.Clear();
                    Console.WriteLine("Decrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: ");
                    string Type_string = Console.ReadLine();
                Level_point:;
                    Console.Clear();
                    Console.WriteLine("Decrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: " + Type_string);
                    Console.WriteLine("Level: ");
                    string Level_string = Console.ReadLine();

                    int Crypt_type;
                    int Crypt_level;
                    if(Type_string == null)
                    {
                        goto Type_point;
                    }
                    if(Level_string == null)
                    {
                        goto Level_point;
                    }
                    if (Int32.TryParse(Type_string, out Crypt_type))
                    {
                        if (Int32.TryParse(Level_string, out Crypt_level))
                        {
                        }
                        else
                        {
                            Console.WriteLine("Error: Try again");
                            Console.ReadKey();
                            goto Level_point;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Try again");
                        Console.ReadKey();
                        goto Type_point;
                    }

                    string Decrypted_text = Decrypt(Crypt, Crypt_type, Crypt_level);
                    Console.Clear();
                    Console.WriteLine("Decrypting");
                    Console.WriteLine();
                    Console.WriteLine("Text: " + Crypt);
                    Console.WriteLine("Type: " + Type_string);
                    Console.WriteLine("Level: " + Level_string);
                    Console.WriteLine();
                    Console.WriteLine("Result:");
                    Console.WriteLine(Decrypted_text);
                    Console.WriteLine();
                    string Exit = Console.ReadLine();
                    if (Exit == "Exit")
                    {
                        goto Start_top;
                    }
                    goto Crypt_Top;
                }
                #endregion
                #region Iso
                else if (Input == "Iso")
                {
                    Iso Iso_loader = new Iso();
                    Iso_loader.Load_1();
                Top_Iso:;
                    Console.Clear();
                    Console.WriteLine("Isotopes  (Actions: Find, All, Decay)");
                    Console.WriteLine();
                    string input_iso = Console.ReadLine();

                    if(input_iso == "Find")
                    {
                        Console.Clear();
                        Console.WriteLine("Isotop: (Example: H-1)");
                        string find_s = Console.ReadLine();
                        Console.WriteLine();
                        Iso_loader.Load_2(find_s);
                        Console.WriteLine();
                        string Exit = Console.ReadLine();
                        if (Exit == "Exit")
                        {
                            goto Start_top;
                        }
                        goto Top_Iso;
                    }
                    else if (input_iso == "All")
                    {
                        Console.Clear();
                        Console.WriteLine("Isotopes: ");
                        Iso_loader.Load_3();
                        string Exit = Console.ReadLine();
                        if (Exit == "Exit")
                        {
                            goto Start_top;
                        }
                        goto Top_Iso;
                    }else if(input_iso == "Decay")
                    {
                        Console.Clear();
                        Console.WriteLine("Isotop:");
                        string Iso_read = Console.ReadLine();
                        Console.WriteLine();
                        Iso_loader.Load_4(Iso_read);
                        string Exit = Console.ReadLine();
                        if (Exit == "Exit")
                        {
                            goto Start_top;
                        }
                        goto Top_Iso;
                    }
                }
                #endregion
                #region Exit
                else if (Input == "Exit")
                {
                    goto END_END;
                }
                #endregion
                else if(Input == "A thing")
                {

                }
            }
                        
            goto Start_top; //goes to start
        END_END:; //ends the program
        }

        static void Help()
        {
            for (int n = 0; n < Commands.Length; n++)
            {
                Console.WriteLine(n + ": " + Commands[n]);
            }
        }
        #region Encrypt/Decrypt
        static string Encrypt(string Text, int type, int Level)
        {
            string Encrypt_text = "";

            if (type == 1)
            {
                var hexString = Text;
                for (int i = 0; i < Level; i++)
                {
                    //Make the text into a Hexadecimal form.
                    byte[] ba = Encoding.ASCII.GetBytes(hexString);
                    hexString = BitConverter.ToString(ba);
                    hexString = hexString.Replace("-", "");
                }
                Encrypt_text = hexString;
            }
            else if (type == 2)
            {
                for (int i = 0; i < Level; i++)
                {
                    //Make the text into a binary form.
                    Encrypt_text = ToBinary(ConvertToByteArray(Text, Encoding.ASCII));
                    Encrypt_text = Encrypt_text.Replace(" ", "");
                    Text = Encrypt_text;
                }                
            }
            return Encrypt_text;
        }
        static string Decrypt(string Text, int type, int Level)
        {
            string Decrypt_text = "";

            if (type == 1)
            {
                //Convert Hexadecimal to readable text
                var Text_bytes = ConvertToByteArray(Text, Encoding.ASCII);
                Decrypt_text = HexAsciiConvert(Text_bytes);
            }
            else if (type == 2)
            {
                byte[] binary_data;

                //Make the bytes into Hexadecimal values
                binary_data = BinaryAsciiConvert(Text);
                
                //Convert Hexadecimal to readable text
                Decrypt_text = Encoding.ASCII.GetString(binary_data);
            }
            return Decrypt_text;
        }
        static string HexAsciiConvert(byte[] hex)
        {
            //Convert Hexadecimal to readable text
            return Encoding.ASCII.GetString(hex);
        }

        static Byte[] BinaryAsciiConvert(string binary)
        {
            //Takes every 8 binary numbers and puts them into a byte format (Hexadecimal value).
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length - 1; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }

        public static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            //Convert the string to bytes (Hexadecimal values).
            return encoding.GetBytes(str);
        }

        public static String ToBinary(Byte[] data)
        {
            //Takes the bytes (Hexadecimal numbers) and puts them into a binary format
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
        #endregion

    }
}
