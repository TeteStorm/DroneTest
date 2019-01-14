using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Drone
{
    public class DroneClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o comando a ser executado  N, S, L, O seguido da posição desejada(ex N123)");
            Console.WriteLine("Caso deseje cancelar a operação digite X");
            Console.WriteLine("Digite exit para encerrar");
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                var result = Evaluate(input.ToUpper());
                Console.WriteLine("({0},{1})", result.Item1, result.Item2);
            }
        }

        //Retorna uma tupla de inteiros correspondente ao eixos x e y respectivamente
        public static Tuple<int, int> Evaluate(string args)
        {
            var x = 0;
            var y = 0;

            //Valida argumentos de entrada 
            if (!ValidateInput(args) || !ValidateStep(args))
                return Tuple.Create(999, 999);

            //Insere uma virgula para separar as operações 
            var formatInput = args.Replace("N", ",N");
            formatInput = formatInput.Replace("S", ",S");
            formatInput = formatInput.Replace("L", ",L");
            formatInput = formatInput.Replace("O", ",O");
            formatInput = formatInput.Replace("X", ",X");

            //Cria uma array com operação de [coordenada + passo] ou [operação de cancelamento]
            var commands = formatInput.Split(',').ToList();

            //Procura as operações de cancelamento e anula a respectiva operação de coordenada subjacente à mesma
            while (commands.FindIndex(c => c == "X") > 0)
            {
                commands.RemoveAt(commands.FindIndex(c => c == "X") - 1);
                commands.RemoveAt(commands.FindIndex(c => c == "X"));
            }

            //Itera sobre os comandos selecionando as operações de coordenada e seus respectivos passos (caso exista, senão considera 1)
            //Acumula o valor no devido eixo  
            commands.ToList().ForEach(c =>
                {
                    //(Norte incrementa eixo y,
                    if (c.StartsWith("N"))
                    {
                        var p = c.Length == 1 ? 1 : GetStep(c);
                        y += p;
                    }
                    //Sul decrementa eixo y
                    if (c.StartsWith("S"))
                    {
                        var p = c.Length == 1 ? 1 : GetStep(c);
                        y -= p;
                    }
                    //Leste incrementa eixo x
                    if (c.StartsWith("L"))
                    {
                        var p = c.Length == 1 ? 1 : GetStep(c);
                        x += p;
                    }
                    //Oeste decrementa eixo x)
                    if (c.StartsWith("O"))
                    {
                        var p = c.Length == 1 ? 1 : GetStep(c);
                        x -= p;
                    }
                }
            );
            return Tuple.Create(x, y);
        }

        //Obtém o inteiro corresponde à string de entrada do passo
        private static int GetStep(string stringStep)
        {
            return int.Parse(stringStep.Substring(1, stringStep.Length - 1));
        }

        //Verifica se dada string representa um dígito numérico
        private static bool IsNumeric(string data)
        {
            return data.Any(x => Char.IsDigit(x));
        }

        //Valida a entrada não permitindo caracteres diferentes de NSLOX ou números
        //e não permitindo passos (números) após X
        private static bool ValidateInput(string input)
        {
            var regex = new Regex(@"[NSLOX\d]", RegexOptions.IgnoreCase);
            var matches = regex.Matches(input);

            if (matches.Count != input.Length)
                return false;

            for (var i = 0; i < matches.Count; i++)
            {
                if (String.Compare(matches[i].ToString(), "X", true) == 0)
                {
                    if (i == 0)
                        //invalida entrada começando com X
                        return false;
                    if (IsNumeric(matches[i].NextMatch().Value))
                    {
                        //invalida passo após X
                        return false;
                    }
                }
            }
            return true;
        }

        //Valida o valor mínimo e máximo de passos compreendido entre 1 e 2147483647
        private static bool ValidateStep(string input)
        {
            var regex = new Regex(@"[^\d]");
            var matches = regex.Split(input);
        
            return !matches.Any( x => x.Length > 0 && int.Parse(x) < 1 && int.Parse(x) > 2147483647);
        }
    }
}
