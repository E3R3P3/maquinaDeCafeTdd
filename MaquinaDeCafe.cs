using System;

namespace MaquinaDeCafe
{
    // Clase CAFETERA
    public class Cafetera
    {
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("   ( (");
            Console.WriteLine("    ) )");
            Console.WriteLine("  ........");
            Console.WriteLine("  |      |]");
            Console.WriteLine("  \\      /");
            Console.WriteLine("   `----'");
            Console.WriteLine("☕  Bienvenido(a) a la cafetera digital ☕");
            Vaso.Select();
        }
    }
    
    // Clase VASO
    public class Vaso
    {
        static int vasosPequenos = 5;// 3 OZ
        static int vasosMedianos = 5;// 5 OZ
        static int vasosGrandes = 5;// 7 OZ

       public static void Select()
        {
            Console.WriteLine("\nSeleccione el tamaño del vaso:");
            Console.WriteLine("1. Pequeño (3 OZ)\n2. Mediano (5 OZ)\n3. Grande (7 OZ)");
            Console.Write("Opción: ");

            int opcion = 0;
            string nombreVaso = string.Empty;
            int cantidad = 0;

            try
            {
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        nombreVaso = "Pequeño";
                        cantidad = 3;
                        if (vasosPequenos-- > 0)
                            Cafe.Dispense(cantidad, nombreVaso);
                        else
                            ShowOutOfStockMessage("vasos pequeños");
                        break;

                    case 2:
                        nombreVaso = "Mediano";
                        cantidad = 5;
                        if (vasosMedianos-- > 0)
                            Cafe.Dispense(cantidad, nombreVaso);
                        else
                            ShowOutOfStockMessage("vasos medianos");
                        break;

                    case 3:
                        nombreVaso = "Grande";
                        cantidad = 7;
                        if (vasosGrandes-- > 0)
                            Cafe.Dispense(cantidad, nombreVaso);
                        else
                            ShowOutOfStockMessage("vasos grandes");
                        break;
                    default:
                        Console.WriteLine("\n⚠️ Opción inválida. Intente nuevamente.\n");
                        Select();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("\n❌ Entrada inválida. Solo se permiten números.");
                Select();
            }

        }
        private static void ShowOutOfStockMessage(string tipo)
        {
            Console.WriteLine($"\n🚫 No hay más {tipo}. Por favor, seleccione otra opción.\n");
            Select();
        }
    }
    
    // Clase CAFE
    public class Cafe
    {
        private static int cantidadDisponible = 20;
        
        public static void Dispense(int cantidadRequerida, string nombreVaso)
        {
            if (cantidadDisponible < cantidadRequerida)
            {
                Console.WriteLine("\n🚫 No hay suficiente café para esta operación.\n");
                Vaso.Select();
                return;
            }

            cantidadDisponible -= cantidadRequerida;
            Console.WriteLine($"\n☕ {cantidadRequerida} OZ de café servidos en un vaso {nombreVaso}.");

            Azucar.Add(nombreVaso, cantidadRequerida);
        }

    }
    
    // Clase AZUCAR
    public class Azucar
    {
        private static int azucarDisponible = 15;
        public static void Add(string nombreVaso, int cantidadCafe)
        {
            Console.WriteLine("\n¿Cuántas cucharadas de azúcar desea? (0 a 5): ");
            Console.Write("Opción: ");

            try
            {
                int cucharadas = int.Parse(Console.ReadLine());

                if (cucharadas < 0 || cucharadas > 5)
                {
                    Console.WriteLine("\n⚠️ Solo puede elegir entre 0 y 5 cucharadas.");
                    Add(nombreVaso, cantidadCafe);
                    return;
                }

                if (cucharadas > azucarDisponible)
                {
                    Console.WriteLine($"\n🚫 No hay suficiente azúcar. Solo quedan {azucarDisponible} cucharadas.");
                    Add(nombreVaso, cantidadCafe);
                    return;
                }

                azucarDisponible -= cucharadas;
                ShowSummary(nombreVaso, cantidadCafe, cucharadas);
            }
            catch
            {
                Console.WriteLine("\n❌ Entrada inválida. Intente nuevamente.");
                Add(nombreVaso, cantidadCafe);
            }
        }
        
        private static void ShowSummary(string nombreVaso, int cafe, int azucar)
        {
            Console.WriteLine("\n======================");
            Console.WriteLine("☕ Café preparado con éxito:");
            Console.WriteLine($"- Vaso: {nombreVaso}");
            Console.WriteLine($"- Cantidad de café: {cafe} OZ");
            Console.WriteLine($"- Azúcar: {azucar} cucharada(s)");
            Console.WriteLine("======================");
            Console.Write("\nPresione Enter para preparar otro café...");
            Console.ReadLine();
            Cafetera.Start();
        }
        
    }
}
