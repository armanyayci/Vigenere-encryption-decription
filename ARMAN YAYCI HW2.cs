//*************************************************
//****              ARMAN YAYCI                ****
//****               B201202050                ****
//*************************************************
using System;
using System.Text;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------");
            Crypt zorman = new Crypt();                         
            zorman.printEncryptedMsg();                                 //calling the methods.
            zorman.printDecryptedMsg();
            Console.Readline();

        }

    interface ICrypt                                //declaring interface for inheritance
        {
            string pwd { set;get;}                    //declaring properties and methods in interface to inherit the class
            string msg { set;get;}
            string encrypt();                         
            string decrypt();
            void printEncryptedMsg();
            void printDecryptedMsg();
        }

        class Crypt : ICrypt                //inheriting class by interface
        {
            object input;

            public Crypt()              // defining constructor in order to input msg and password and print them to screen.
            {
                Console.Write("ENTER A PASSWORD........:");
                input = Console.ReadLine();
                pwd = Convert.ToString(input);
                pwd = pwd.ToUpper();                            //transforming inputs to uppercase if it is lower
                Console.Write("ENTER A MESSAGE.........:");
                input = Console.ReadLine();
                msg = Convert.ToString(input);
                msg = msg.ToUpper();
                Console.WriteLine("---------------------------");
                Console.WriteLine("PASSWORD                :"+pwd);
                Console.WriteLine("MESSAGE                 :"+msg);
                Console.WriteLine("---------------------------");
            }
            private string _pwd;                        //declaring fields with proper access modifier
            private string _msg;
            public string pwd                           //declaring properties for the fields.
            {
                set
                {
                    _pwd = value;
                }
                get
                {
                    return _pwd;
                }
            }
            public string msg
            {
                set
                {
                    _msg = value;
                }
                get
                {
                    return _msg;
                }
            }


            public string encrypt()                 //defining method to encrypt the message
            {
                int c = 0;                          //c is the int variable which is assigned for repeated pwd index
                char aa;
                string qq = null;                   //qq is the encrypted message.

                for (int i = 0; i < msg.Length; i++)
                {
                    if (c == pwd.Length)           //when the variable c is equal to lenght of pwd, it will go back to initial index.
                        c = 0;
                    if (msg[i] == ' ')          //if the message has a space it will add to encrypted message.
                    {
                        qq += " ";
                        continue;
                    }
                    aa = (char)((msg[i] +pwd[c]) % 26 + 'A');    //encrypting message formula according to ascii table.
                    qq += aa;
                    c += 1;
                }
                msg = qq;
                return qq;
            }

            public string decrypt()              //defining method to decrypt the encrypted message
            {
                int c = 0;                      //c is the int variable which is assigned for repeated pwd index
                char bb;                        
                string ww = null;               //ww is the message which is transformed from the encrypted.
                for (int i = 0; i < msg.Length; i++)
                {
                    if (c == pwd.Length)        //when the variable c is equal to lenght of pwd, it will go back to initial index.
                        c = 0;
                    if (msg[i] == ' ')          //if the encrypted message has a space it will add to decrypted message.
                    { 
                        ww += " ";
                        continue;
                    }
                    bb= (char)((msg[i] -pwd[c] +26) % 26 + 'A');    //decrypting message formula according to ascii table.
                    ww += bb;
                    c += 1;
                }
                pwd = ww;
                return ww;
            }

            public void printEncryptedMsg()
            {
                Console.WriteLine("ENCRYPTED MESSAGE       :"+encrypt());           //printing the encrypted message
            }

            public void printDecryptedMsg()
            {
                Console.WriteLine("DECRYPTED MESSAGE       :"+decrypt());           //printing the decrypted message
            }
        }
    }   
}
//this code written by ARMAN YAYCI