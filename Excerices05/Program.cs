using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace Excerices05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int ordre =0;
            Console.Write("Entrez le reste du numéro d'exercice 5.");
            int choixExercice = int.Parse(Console.ReadLine());
            switch (choixExercice)
            {
                case 1 : E51(); break;
                case 2 : E52(); break;
                case 3 : E53(); break;
                case 4 : E54(); break;
                case 5 : E55(); break; 
                case 6 : E55(); break;
                case 7 : E57(); break;
                case 8 : E58(); break;
                case 9 : E59(); break;
                case 10 : E510(); break;
                
                default: Console.WriteLine("Nope...");  break;
            }
        }

        public static void E51()
        {
            int somme = 0, entrees = 0;
            
            do
            {
                Console.Write("Entrez un nombre :");
                int nombreAAjouter = int.Parse(Console.ReadLine());
                somme = Accumulator(somme, nombreAAjouter);
                entrees++;
            } while (entrees < 5);
            Console.WriteLine("La somme est de " + somme);
        }        
        public static int Accumulator( int chiffreCourant, int chiffreAAjouter)
        {
            return chiffreCourant+chiffreAAjouter;
        }
        public static void E52()
        {
            double [] nombresEntres = new double[5];
            int entrees = 0;
            
            do
            {
                Console.Write("Entrez un nombre :");
                double nombreAAjouter = double.Parse(Console.ReadLine());
                nombresEntres[entrees] = nombreAAjouter;
                entrees++;
            } while (entrees < 5);
            Console.WriteLine("La somme est de " + Sum(nombresEntres));
        }
        public static double Sum(double[] tableauAAdditionner)
        {
            double somme = 0;
            for (int i = 0; i < tableauAAdditionner.Length; i++)
            {
                somme += tableauAAdditionner[i];
            }
            return somme;
        }
        public static void E53()
        {
            double x1, x2, y1, y2;
            Console.Write("Entrez x1 : ");
            x1 = double.Parse(Console.ReadLine());
            Console.Write("Entrez y1 : ");
            y1 = double.Parse(Console.ReadLine());
            Console.Write("Entrez x2 : ");
            x2 = double.Parse(Console.ReadLine());
            Console.Write("Entrez y2 : ");
            y2 = double.Parse(Console.ReadLine());
            double dist = Distance(x1, x2, y1, y2);
            Console.WriteLine("La distance entre les points est de " + dist);
        }
        public static double Distance(double x1, double x2, double y1, double y2)
        {
            return Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)),2);
        }
        public static void E54()
        {
            int choix = 0;
            do
            {
                Console.WriteLine("Entrez une quantité de nombre : ");
                choix = int.Parse(Console.ReadLine());
            } while (choix < 0);

            int[] resultat = RandomNumbers(choix);
            for (int i = 0; i < resultat.Length; i++)
            {
                Console.Write(resultat[i]+((i<resultat.Length-1)?", ":""));
            }
        }
        public static int[] RandomNumbers(int nombreDeChiffres)
        {
            Random randomNumber = new Random();
            int[] tableauDeRandoms = new int[nombreDeChiffres];
            for (int i = 0; i < tableauDeRandoms.Length; i++)
            {
                tableauDeRandoms[i] = randomNumber.Next(0, 100);
            }

            return tableauDeRandoms;
        }
        public static void E55()
        {
            //string choix = "";
        
            //while (choix != "N" && choix != "n")
            //{
                while (AnotherPower())
                //Console.Write("Entrer un calcul (O/N) ?");
                //choix = Console.ReadLine();
                //if (choix == "O" || choix == "o")
                {
                    Console.Write("Entrer un nombre : ");
                    int number = int.Parse(Console.ReadLine());
                    Console.Write("Entrer une puissance : ");
                    int power = int.Parse(Console.ReadLine());
                    Console.WriteLine("Résultat = " + Power(number,power));
                }

            //}
        }
        public static int Power(int nombre, int exposant)
        {
            int reponse = nombre;
            for (int i = 0; i < exposant-1; i++)
            {
                reponse = reponse * nombre;
            }
            return reponse;
        }
        public static bool AnotherPower()
        {
            string choix = "";
            // doit saisir le choix et verifier s'il est valide
            // si le choix est o (ou O) retourner vrai
            // si le choix est n (ou N) retourer faux
            // si le choix est quoi que ce soit d'autre : on redemande
            bool choixValide = false;
            while (!choixValide)
            {
                Console.Write("Entrer un calcul (O/N) ?");
                choix = Console.ReadLine();

                if (choix == "O" || choix == "o")
                {
                    choixValide = true;
                    return true;

                }

                if (choix == "n" || choix == "N")
                {
                    choixValide = true;
                    return false;
                }
            }

            return false;

        }
        public static void E57()
        {
            Console.Write("Entrez un nombre entier : ");
            int nombre = int.Parse(Console.ReadLine());
            Console.Write("La factorielle de " + nombre + " est " +factorielleRecursive(nombre));
        }
        public static int factorielleRecursive(int nombreAFactorialiser)
        {
            if (nombreAFactorialiser == 0)
                return 1;
            else
            {
                return nombreAFactorialiser * factorielleRecursive(nombreAFactorialiser - 1);
            }
            
        }
        public static void E58()
        {
            Console.Write("Entrez un nombre : ");
            int entree = int.Parse(Console.ReadLine());
            bool isPrime = Prime(entree);
            if (isPrime)
                Console.WriteLine("Le nombre "+ entree + " est un nombre premier");
            else
                Console.WriteLine("Le nombre "+ entree + " est divisible");
        }
        public static bool Prime(int chiffreAVerifier)
        {
            // pour calculer la valeur on doit diviser le chiffre par des chiffres plus petits que lui
            // si on atteint 1, le chiffre est un ombre premier, si on n<atteint pas 1, il est 
            // donc divisible
            // tant que.. chiffreaverifier%diviseur
            // faire division par modulo, si reste = 0 arreter
            // si se rend a i=1 et que modulo = 0 = nombre premier
            int valeur = 0;
            for (int i = chiffreAVerifier-1; i < chiffreAVerifier; i--)
            {
                Console.WriteLine("chiffre a verifier est " + chiffreAVerifier + "diviseur est " + i);
                valeur = chiffreAVerifier % i;
                Console.WriteLine("Valeur du modulo = " + valeur);
                if (valeur == 0 && i == 1)
                    return true;
                if (valeur == 0)
                    return false;
            }
            return true;
        }

        public static void E59()
        {
            //Écrire un programme C# qui demande un nombre x et affiche les x premiers nombre de cette série [1,
            //  1, 2, 3, 5, 8, 13, ...] (suite de Fibonacci) en mode récursif.
            Console.Write("Entrez la position de Fibonnaci : ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("Le nombre #" +position+ " de la suite de Fibonnaci = " + FibonnaChie(position));
        }
        public static int FibonnaChie(int chiffre)
        {
            Console.Write("Appel avec " + chiffre + "\n");
            // doit ajouter le chiffre au dernier chiffre passe dans la fonction
            // si chiffre est plus petit ou egal a 1, retourner 1
            // sinon retourner fibonnachie (chiffre - 1) + fibonnachie (chiffre - 2)
            if (chiffre <= 2)
            {
                Console.WriteLine("****** La fonction a retourné un 1");
                return 1;
            }
            else
            {
                Console.WriteLine("Retour recursif avec " + (chiffre-1) + " et " + (chiffre-2));
                //Console.WriteLine("On retourne " + (FibonnaChie(chiffre-1) + FibonnaChie(chiffre - 2))+" a la fonction");
                return FibonnaChie(chiffre-1) + FibonnaChie(chiffre - 2);
            }
        }
        public static void E510()
        {
            Console.WriteLine("Ce programme transforme votre clavier QWERTY en piano");
            
            int dureeNotes = 200;
            int octave = 0;
            AfficherInstructions(dureeNotes,octave);
            bool isRunning = true;
            while (isRunning)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.V:
                        AfficherInstructions();
                        break;
                    case ConsoleKey.OemComma:
                        dureeNotes += 100;
                        Console.WriteLine("Nouvelle duree : " + dureeNotes);
                        break;
                    case ConsoleKey.OemPeriod:
                        if (dureeNotes - 100 > 0)
                        {
                            dureeNotes -= 100;
                            Console.WriteLine("Nouvelle duree : " + dureeNotes);
                        }
                        else
                        {
                            Console.WriteLine("Nouvelle duree invalide");

                        }
                        break;
                    case ConsoleKey.OemPlus:
                        octave++;
                        Console.WriteLine("Nouvel octave : " + octave);
                        break;
                    case ConsoleKey.OemMinus:
                        if (octave - 1 > -5)
                        {
                            octave--;
                            Console.WriteLine("Nouvel octave : " + octave);
                        }
                        else
                        {
                            Console.WriteLine("Nouvel octave invalide");

                        }
                        break;
                    case ConsoleKey.Q:
                        //Console.WriteLine("La touche Q !"); // do
                        
                        Console.Beep(523, dureeNotes);
                        //JouerNote(523,dureeNotes);
                        break;
                    case ConsoleKey.D2:
                        //Console.WriteLine("La touche 2 !");
                        Console.Beep(554, dureeNotes);
                        break;

                    case ConsoleKey.W:
                        Console.Beep(587, dureeNotes);
                        break;
                    case ConsoleKey.D3:
                        //Console.WriteLine("La touche 3 !");
                        Console.Beep(622, dureeNotes);
                        break;

                    case ConsoleKey.E:
                        Console.Beep(659,dureeNotes);
                        break;
                    case ConsoleKey.R:
                        Console.Beep(698,dureeNotes);
                        break;
                    case ConsoleKey.D5:
                        //Console.WriteLine("La touche 5 !");
                        Console.Beep(740, dureeNotes);
                        break;

                    case ConsoleKey.T:
                        Console.Beep(783,dureeNotes);
                        break;
                    case ConsoleKey.D6:
                        //Console.WriteLine("La touche 6 !");
                        Console.Beep(831, dureeNotes);
                        break;

                    case ConsoleKey.Y:
                        Console.Beep(880,dureeNotes);
                        break;
                    case ConsoleKey.D7:
                        //Console.WriteLine("La touche 7 !");
                        Console.Beep(932, dureeNotes);
                        break;
                   
                    case ConsoleKey.U:
                        Console.Beep(987,dureeNotes);
                        break;
                    case ConsoleKey.I:
                        Console.Beep(1046,dureeNotes);
                        break;
                    case ConsoleKey.X:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Erien");
                        break;
                }
            }
        }

        public static void JouerNote(int hauteur, int duree)
        {
           
            
        }
        public static void AfficherInstructions(int duree=200, int octave=0)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("* Configuration du clavier *");
            Console.WriteLine("****************************");

            Console.WriteLine("Durée des notes " + duree + " octave de reférence " + octave +"\n");
            Console.WriteLine("2 = Do# / 3 = Re# / 5 = Fa# / 6 = Sol# / 7 = La#");
            Console.WriteLine("Q = Do / W = Re / E = Mi / R = Fa / T = Sol / Y = La / U = Si / I = Do ");
            Console.WriteLine("Appuyer sur +/- pour augmenter/diminuer l'octave");
            Console.WriteLine("Appuyer sur ,/. pour augmenter/diminuer la durée");
            Console.WriteLine("Appuyer V pour afficher les instructions");

            Console.WriteLine("Appuyer sur X pour quitter");
        }
        
        
    }
}