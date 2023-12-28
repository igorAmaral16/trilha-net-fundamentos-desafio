namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Implementado!!!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string veiculoParaAdicionar = Console.ReadLine().ToUpper();

            if (veiculoParaAdicionar.Count() == 7)
            {
                string pegar3PrimeirosCaracteres = veiculoParaAdicionar.Substring(0, 3);
                string pegar4UltimosCaracteres = veiculoParaAdicionar.Substring(3, 4);

                if (veiculos.Contains(veiculoParaAdicionar))
                {
                    Console.WriteLine("Veículo já adicionado anteriormente.");
                }
                else if (VerificarLetra(pegar3PrimeirosCaracteres) == false
                        || VerificarNumero(pegar4UltimosCaracteres) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Placa: {veiculoParaAdicionar} inválida, por favor, insira uma placa válida.\n");
                    Console.ResetColor();
                }
                else
                {
                    veiculos.Add(veiculoParaAdicionar);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"O veículo {veiculoParaAdicionar.Substring(0, 3)}-{veiculoParaAdicionar.Substring(3, 4)} foi cadastrado com sucesso.\n");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Placa: {veiculoParaAdicionar} inválida, por favor, insira uma placa válida.\n");
                Console.ResetColor();
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                string horasParaConverter = Console.ReadLine();

                bool conversaoComSucesso = int.TryParse(horasParaConverter, out int horas);
                decimal valorTotal = 0.0M;

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                if (conversaoComSucesso)
                {
                    valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa);

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"O veículo: {placa.Substring(0, 3)}-{placa.Substring(3, 4)} foi removido com sucesso. Valor total a ser pago: {valorTotal:C}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O valor '{horasParaConverter}' não é válido, por favor, digite uma quantidade válida.");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Console.ResetColor();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine("\t      _______       ");
                    Console.WriteLine("\t    /_|_____|_\\    ");
                    Console.WriteLine("\t o-(   o   o   )-o  ");
                    Console.WriteLine("\t    `-._____,-'     ");
                    Console.WriteLine($"\t   | {veiculo.Substring(0, 3)}-{veiculo.Substring(3, 4)} |   ");
                    Console.WriteLine("\t____________________");

                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Não há veículos estacionados.");
                Console.ResetColor();
            }
        }
        public static bool VerificarLetra(string texto)
        {
            foreach (char letra in texto)
            {
                if (!char.IsLetter(letra))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool VerificarNumero(string texto)
        {
            foreach (char letra in texto)
            {
                if (!char.IsDigit(letra))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
