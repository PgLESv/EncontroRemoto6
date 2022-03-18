using System;
using System.Threading;


namespace ENCONTROREMOTO6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
=============================================
|    Bem vindo ao sistema de cadastro       |
|    de pessoa física e pessoa jurídica     |
=============================================
");
            BarraCarregamento("Iniciando");

            string? opcao;

            do
            {
                Console.WriteLine(@$"
============================================
| Escolha uma das opções abaixo:           |
| 1 - Pessoa Física                        |  
| 2 - Pessoa Jurídica                      |
| 3 - Calcula Imposto Pf
| 4 - Calcula Imposto Pj                   |
| 0 - Sair                                 |
|                                          |
============================================        
");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Endereco endPf = new Endereco();

                    endPf.logradouro = "Rua Y";
                    endPf.numero = 120;
                    endPf.complemento = "Próximo ao Mercado";
                    endPf.enderecoComercial = false;

                    PessoaFisica novapf = new PessoaFisica();

                    novapf.endereco = endPf;
                    novapf.cpf = "12345678999";
                    novapf.rendimento = 5000;
                    novapf.dataNascimento = new DateTime(1999, 01, 10);
                    novapf.nome = "Pedro";

                    PessoaFisica pf = new PessoaFisica();
                    pf.ValidarDataNascimento(novapf.dataNascimento);

                    Console.WriteLine(pf.PagarImposto(novapf.rendimento).ToString("N2"));
                    bool idadeValida = pf.ValidarDataNascimento(novapf.dataNascimento);

                    if (idadeValida == true)
                    {
                        Console.WriteLine($"Cadastro Aprovado");
                    }
                    else
                    {
                        Console.WriteLine($"Cadastro Não Aprovado");
                    }

                    // Console.WriteLine(pf.ValidarDataNascimento(novapf.dataNascimento));

                    Console.WriteLine("Rua: " + novapf.endereco.logradouro + ", " + novapf.endereco.numero);
                    break;

                case "2":
                    PessoaJuridica pj = new PessoaJuridica();

                    PessoaJuridica novapj = new PessoaJuridica();

                    Endereco endPj = new Endereco();

                    endPj.logradouro = "Rua Y";
                    endPj.numero = 120;
                    endPj.complemento = "Próximo ao Mercado";
                    endPj.enderecoComercial = false;

                    novapj.endereco = endPj;
                    novapj.cnpj = "01234567890123";
                    novapj.rendimento = 8000;
                    novapj.razaoSocial = "Pessoa Jurídica";

                    Console.WriteLine(pj.PagarImposto(novapj.rendimento).ToString("N2"));
                    

                    if (pj.ValidarCNPJ(novapj.cnpj))
                    {
                        Console.WriteLine("CNPJ Válido");
                    }
                    else
                    {
                        Console.WriteLine("CNPJ Inválido");
                    }
                    break;
                
                case "3":

                    PessoaFisica Rendpf = new PessoaFisica();
                    PessoaFisica Pgpf = new PessoaFisica();
                    Rendpf.rendimento = 4500;

                    double DescontoPf = Pgpf.PagarImposto(Rendpf.rendimento);

                    Console.WriteLine(Pgpf.PagarImposto(Rendpf.rendimento));

                    break;


                case "4":

                    PessoaJuridica Rendpj = new PessoaJuridica();
                    PessoaJuridica Pgpj = new PessoaJuridica();
                    Rendpj.rendimento = 15000;

                    double DescontoPj = Pgpj.PagarImposto(Rendpj.rendimento);

                    Console.WriteLine(Pgpj.PagarImposto(Rendpj.rendimento));

                    break;
                
                case "0":
                    Console.WriteLine($"Obrigado por utilizar o nosso sistema");
                    BarraCarregamento("Finalizando");
                    break;
                
                default:
                    Console.WriteLine($"Opção inválida, digite uma opção válida");
                    break;
            }
                
            } while (opcao != "0");
            
            static void BarraCarregamento(string textoCarregamento)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(textoCarregamento);
                Thread.Sleep(500);

                for (var contador = 0; contador < 10; contador++)
                {
                    Console.Write($".");
                    Thread.Sleep(500); 
                }
                Console.ResetColor();
            }
        }
    }
}