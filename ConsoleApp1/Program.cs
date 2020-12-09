using System;

namespace ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            string titulo = "\n" +
                        "    PROGRAMA DE CONSOLA CALCULADORA \n" +
                        "    ================================\n" + "\n" +
                        "    Para realizar una operación primero introduzca un número, \n" +
                        "    luego elija una operación entre las disponibles '+,-,*,/' \n" +
                        "    y finalmente introduzca un segundo número para obtener un resultado.";

            string pedirNumero = "    introduzca un número (se admiten decimales y negativos pero no letras).";

            string pedirOperación = "    introduzca una operación entre las disponibles: +, -, *, /";

            string operacionNoValida = "    no es una operación válida, pulse una tecla para reiniciar.";

            bool salir = false;

            string[] operacionesPermitidas = { "+", "-", "*", "/" };

            try
            {
                while (!salir)
                {
                    double primerNumero = 0;
                    double segundoNumero = 0;
                    double resultado = 0;
                    string numeroInsertado = "";
                    string operacionInsertada = "";

                    Console.WriteLine(titulo);
                    Console.WriteLine(pedirNumero);
                    numeroInsertado = Console.ReadLine();
                    numeroInsertado = numeroInsertado.Replace(".", ",");
                    if (ComprobarNumero(numeroInsertado))
                    {
                        primerNumero = Convert.ToDouble(numeroInsertado);
                    }
                    else
                    {
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }

                    Console.WriteLine(pedirOperación);
                    operacionInsertada = Console.ReadLine();

                    //comrpobación de que el signo insertado pertenece a las operaciones soportadas por el array operacionesPermitidas
                    if (Array.Exists(operacionesPermitidas, element => element == operacionInsertada))
                    {
                        Console.WriteLine(pedirNumero);
                        numeroInsertado = Console.ReadLine();

                        if (ComprobarNumero(numeroInsertado))
                        {
                            segundoNumero = Convert.ToDouble(numeroInsertado);
                        }
                        else
                        {
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        switch (operacionInsertada)
                        {
                            case "+": resultado = primerNumero + segundoNumero; break;
                            case "-": resultado = primerNumero - segundoNumero; break;
                            case "*": resultado = primerNumero * segundoNumero; break;
                            case "/": resultado = primerNumero / segundoNumero; break;
                            default: break;
                        }

                        if (Double.IsInfinity(resultado))
                        {
                            string dividirEntreCero =
                                " En matemáticas, la división entre cero es una división en la que el divisor es igual a cero, \n" +
                                " y que no tiene un resultado bien definido.En aritmética y álgebra, es considerada una «indefinición», \n" +
                                " y su mal uso puede dar lugar a aparentes paradojas matemáticas.Wikipedia \n";

                            Console.WriteLine(dividirEntreCero + "¿Quieres realizar otra operación (s/n)?");
                            string respuesta = Console.ReadLine();

                            if (respuesta.ToUpper() == "S")
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("    Gracias por usar esta aplicación.");
                                Console.WriteLine("    cerrando en 3..");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("    2...");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("    1...");
                                System.Threading.Thread.Sleep(1000);
                                salir = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("    El resultado de la operación es {0} ¿Quieres realizar otra operación (s/n)?", resultado);
                            string respuesta = Console.ReadLine();

                            if (respuesta.ToUpper() == "S")
                            {
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("    Gracias por usar esta aplicación.");
                                Console.WriteLine("    cerrando en 3..");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("    2...");
                                System.Threading.Thread.Sleep(1000);
                                Console.WriteLine("    1...");
                                System.Threading.Thread.Sleep(1000);
                                salir = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(operacionNoValida);
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Ha ocurrido un error inesperado. Por favor, contacte con soporte. " + error.Message);
                Console.ReadKey();
            }

        }

        /// <summary>
        /// escribe mensaje error en caso de recibir un string no valido como numero
        /// </summary>
        /// <param name="numeroInsertado"></param>
        /// <returns>true si es numero y false si no lo es</returns>
        private static bool ComprobarNumero(string numeroInsertado)
        {
            string numeroNoValido = "    no es un número válido, pulse una tecla para reiniciar.";
            try
            {
                double numero = Convert.ToDouble(numeroInsertado);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(numeroNoValido);
                return false;
            }
        }
    }
}
