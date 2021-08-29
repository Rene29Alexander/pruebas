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

                case "2":
                    updateData();
                    Console.ReadKey();
                    return true;

                case "3":
                    lectura();
                    return true;

                default:
                    return false;

                case "4":
                    return false;
            }
        }

        private static string getPath()
        {
            string path = @"C:\Ejemplo2\registros.txt";
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

        private static void lectura()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Ejemplo2\registros.txt");
            System.Console.WriteLine("Contenido del archivo: ");
            foreach (string line in lines)
            {

                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("Presione cualquier tecla para regresar al menu.");
            System.Console.ReadKey();
        }

        private static Dictionary<object, object> readFile()
        {

            Dictionary<object, object> listData = new Dictionary<object, object>();


            using (var reader = new StreamReader(getPath()))
            {

                string lines;

                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }


            return listData;
        }

        private static bool search(string product)
        {
            if (readFile().ContainsKey(product))
            {
                return true;
            }
            return false;
        }

        private static void updateData()
        {
            Console.Write("Escriba el nombre del producto que desea actualizar: ");
            var product = Console.ReadLine();

            if (search(product))
            {

                Console.WriteLine("El prducto existe");
                Console.Write("Nuevo precio: ");
                var newPrice = Console.ReadLine();

                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[product] = newPrice;
                Console.WriteLine("El producto ha si actualizado");
                File.Delete(getPath());

                using (StreamWriter sw = File.AppendText(getPath()))
                {
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);

                    }


                }
            }

            else
            {
                Console.WriteLine("El producto no existe");
            }
        }


    }
}
    

