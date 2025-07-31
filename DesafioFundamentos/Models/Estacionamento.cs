namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; set; }
        public decimal PrecoPorHora { get; set; }

        public List<Veiculo> VeiculosEstacionados { get; set; }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.PrecoInicial = precoInicial;
            this.PrecoPorHora = precoPorHora;
            this.VeiculosEstacionados = new List<Veiculo>();
        }

        public void EstacionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();
            Veiculo veiculoParaEstacionar = new(placa);
            VeiculosEstacionados.Add(veiculoParaEstacionar);
        }

        public void RemoverVeiculoDoEstacionamento()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (VeiculoEstacionadoExistente(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                decimal quantidadeDeHorasEstacionado = int.Parse(Console.ReadLine());
                decimal valorTotalPorTempoEstacionado = PrecoInicial + PrecoPorHora * quantidadeDeHorasEstacionado;

                Veiculo veiculoParaRemover = VeiculosEstacionados.FirstOrDefault(veiculoAEncontrar => veiculoAEncontrar.Placa == placa);
                VeiculosEstacionados.Remove(veiculoParaRemover);

                Console.WriteLine($"O veículo de placa {placa} foi removido e o preço total foi de: R$ {valorTotalPorTempoEstacionado}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculosEstacionados()
        {
            if (ExistemVeiculosEstacionados())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (Veiculo veiculo in VeiculosEstacionados)
                    Console.WriteLine(veiculo.Placa);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool VeiculoEstacionadoExistente(string placa)
            => VeiculosEstacionados.Any(x => x.Placa.ToUpper() == placa.ToUpper());

        private bool ExistemVeiculosEstacionados()
            => VeiculosEstacionados.Any();
    }
}