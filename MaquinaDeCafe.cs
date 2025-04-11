using System;

namespace MaquinaDeCafe
{
    public class Cafetera
    {
        public static void IniciarCafetera()
        {
            Console.WriteLine("\n\n||||||||||||  CAFETERA ||||||||||||");
            Vaso.GetVaso();
        }
    }
    public class Vaso
    {

        static int vasosPequenos = 5;// 3 OZ
        static int vasosMedianos = 5;// 5 OZ
        static int vasosGrandes = 5;// 7 OZ
        

       public static void GetVaso()
        {

            Console.WriteLine("\n Tipo de Vaso: ");
            Console.WriteLine("\n1. Vaso Pequeño 3 OZ");
            Console.WriteLine("\n2. Vaso Mediano 5 OZ");
            Console.WriteLine("\n3. Vaso Grande 7 OZ");
            Console.Write(":>");
            int tipoVaso = 0;
            string nameVaso = "";

            try
            {
                tipoVaso = int.Parse(Console.ReadLine());
                switch (tipoVaso)
                {
                    case 1:
                        {
                            Console.WriteLine("\nSeleccionaste el vaso Pequeno");//
                            nameVaso = "Vaso Pequeño";
                            if (vasosPequenos > 0)
                            {
                                vasosPequenos -= 1;
                                Cafe.GetCafe(tipoVaso, nameVaso);
                            }
                            else
                            {
                                Console.WriteLine("Ya no quedan mas vasos Pequenos, Por favor seleccione otra opcion");
                                GetVaso();
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Seleccionaste el Vaso Mediano");//
                            nameVaso = "Vaso Mediano";
                            if (vasosMedianos > 0)
                            {
                                vasosMedianos -= 1;
                                Cafe.GetCafe(tipoVaso, nameVaso);
                            }
                            else
                            {
                                Console.WriteLine("Ya no quedan mas vasos Medianos, Por favor seleccione otra opcion");
                                GetVaso();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("\nSeleccionaste el Vaso Grande");//
                            nameVaso = "Vaso Grande";
                            if(vasosGrandes > 0)
                            {
                                vasosGrandes -= 1;
                                Cafe.GetCafe(tipoVaso, nameVaso);
                            }
                            else
                            {
                                Console.WriteLine("Ya no quedan mas vasos grandes, Por favor seleccione otra opcion!");
                                GetVaso();
                            }
                            
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nSolo puede seleccionar un numero del 1 al 3");
                            GetVaso();
                            break;
                        }

                }
            }
            catch
            {
                Console.WriteLine("\nError Solo Se Permiten numeros enteros\n");
                GetVaso();
            }

        }

    }

    public class Cafe
    {
        static int cafe = 10;
        public static void GetCafe(int tipoVaso, string nameVaso)
        {
            
            if(cafe < 3)
            {
                Console.WriteLine("\nNo hay cafe\n");
            }
            else
            {
                Console.WriteLine("\nCantidad de Cafe Que Quiere en su vaso:");
                
                if (tipoVaso >= 1)
                {
                    Console.WriteLine("\n1. 3 OZ");
                }
                if (tipoVaso >= 2)
                {
                    Console.WriteLine("\n2. 5 OZ");
                }
                if (tipoVaso >= 3)
                {
                    Console.WriteLine("\n3. 7 OZ");
                }

                int opcionCafe = 0;
                int cantidadCafe = 0;
                Console.Write(":>");
                try
                {
                    opcionCafe = int.Parse(Console.ReadLine());

                    switch (opcionCafe)
                    {
                        case 1:
                            {
                                if (tipoVaso == 1 || tipoVaso == 2 || tipoVaso == 3)
                                {
                                    cantidadCafe = 3;
                                    if (cantidadCafe <= cafe)
                                    {
                                        cafe = cafe - cantidadCafe;
                                        Azucar.GetAzucar(nameVaso, cantidadCafe);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nNo hay cafe suficiente, solo queda: " + cafe + " OZ");
                                        GetCafe(tipoVaso, nameVaso);
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\nPor Favor Seleccione una de las opciones en pantalla");
                                    GetCafe(tipoVaso, nameVaso);
                                }
                                break;
                            }
                        case 2:
                            {
                                if (tipoVaso == 2 || tipoVaso == 3)
                                {
                                    cantidadCafe = 5;
                                    if (cantidadCafe <= cafe)
                                    {
                                        cafe = cafe - cantidadCafe;
                                        Azucar.GetAzucar(nameVaso, cantidadCafe);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nNo hay cafe suficiente, solo queda: " + cafe + " OZ");
                                        GetCafe(tipoVaso, nameVaso);

                                    }

                                }
                                else
                                {
                                    Console.WriteLine("\nPor Favor Seleccione una de las opciones en pantalla");
                                    GetCafe(tipoVaso, nameVaso);
                                }


                                break;
                            }
                        case 3:
                            {
                                if (tipoVaso == 3)
                                {
                                    cantidadCafe = 7;
                                    if (cantidadCafe <= cafe)
                                    {
                                        cafe = cafe - cantidadCafe;
                                        Azucar.GetAzucar(nameVaso, cantidadCafe);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nNo hay cafe suficiente, solo queda: " + cafe + " OZ");
                                        GetCafe(tipoVaso, nameVaso);

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPor Favor Seleccione una de las opciones en pantalla");
                                    GetCafe(tipoVaso, nameVaso);
                                }



                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nSolo puede seleccionar un numero del 1 al 3, usted selecciono: " + opcionCafe);
                                GetCafe(tipoVaso, nameVaso);
                                break;
                            }

                    }
                }
                catch
                {
                    Console.WriteLine("\nError Solo Se Permiten numeros enteros");
                    GetCafe(tipoVaso, nameVaso);
                }
            }


        }

    }

    public class Azucar
    {
        static int azucar = 15;
        public static void GetAzucar(string nameVaso, int cantidadCafe)
        {

            Console.WriteLine("\n|||||||||||| cucharadas de azucar que quiere en su cafe:\n");
            Console.WriteLine("\n0. Sin Azucar");
            Console.WriteLine("\n1. Una Cucharada");
            Console.WriteLine("\n2. Dos Cucharada");
            Console.WriteLine("\n3. Tres Cucharada");
            Console.WriteLine("\n4. Cuatro Cucharada");
            Console.WriteLine("\n5. Cinco Cucharada");
            Console.Write(":>");
            int opcionAzucar = 0;

            try
            {
                opcionAzucar = int.Parse(Console.ReadLine());

                if(opcionAzucar >= 0 && opcionAzucar <= 5)
                {
                    if(opcionAzucar <= azucar)
                    {
                        Console.WriteLine("\n||||||||||||CAFE ESTA COMPLETO||||||||||||");
                        Console.WriteLine("\nVaso:  " + nameVaso);
                        Console.WriteLine("\nCantidad: " + cantidadCafe + " OZ de CAFE");
                        Console.WriteLine("\nAzucar :"+ opcionAzucar + " cucharadas");
                        Console.Write("\n\nPresione enter para pedir otro cafe");
                        Console.ReadLine();
                        Cafetera.IniciarCafetera();
                    }
                    else
                    {
                        Console.WriteLine("\nNo queda suficiente azucar, solo quedan " + azucar + " cucharadas");
                    }

                }
                else
                {
                    Console.WriteLine("\nDebe ser una opcion del 1 al 5, usted selecciono: " + opcionAzucar);
                    GetAzucar(nameVaso, cantidadCafe);
                }

            }
            catch
            {
                Console.WriteLine("\nError Solo Se Permiten numeros enteros");
                GetAzucar(nameVaso, cantidadCafe);
            }

        }

    }

}
