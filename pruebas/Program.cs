using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace manejoArchivos
{
    class Archivos
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu();
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
           
            Console.Clear(); 
            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevo producto");
            Console.WriteLine("2. Actualizar datos de producto");
            Console.WriteLine("3. Mostrar listado de productos");
            Console.WriteLine("4. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    registro();
                    return true;
            
                default:
                    return false;
            }
        }

        private static string getPath()
        {
            string path = @"C:\Users\HP\Desktop\U\programacion computacional 1\tarea\registros.txt";
            return path;
        }

 
        private static void registro()
        {
            Console.WriteLine("ingrese el nuevo producto");
            Console.Write("nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("precio: ");
            double precio = Convert.ToDouble(Console.ReadLine());


            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; ${1}", nombre, precio);
                sw.Close();
            }
        }


     
            }
        }
    

