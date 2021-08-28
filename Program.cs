using System;

namespace PopCine
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorio1 = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoSessao = ObterOpcaoSessao();
            while (opcaoSessao.ToUpper() != "X")
            {
                // **** FILME ****
                if(opcaoSessao == "1")
                {
                    Console.Clear();
                    string opcaoUsuario = ObterOpcaoUsuario();
                    while (opcaoUsuario.ToUpper() != "X")
                    {
                        switch (opcaoUsuario)
                        {
                            case "1":
                                Console.Clear();
                                ListarFilme();
                                break;

                            case "2":
                                Console.Clear();
                                InserirFilme();
                                Console.Clear();
                                break;

                            case "3":
                                Console.Clear();
                                AtualizarFilme();
                                Console.Clear();
                                break;

                            case "4":
                                Console.Clear();
                                ExcluirFilme();
                                Console.Clear();
                                break;

                            case "5":
                                Console.Clear();
                                VisualizarFilme();
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Opção invalida");
                                break;
                        }

                        opcaoUsuario = ObterOpcaoUsuario();
                    }
                }

                // **** SÉRIE ****

                else if(opcaoSessao =="2")
                {
                    Console.Clear();
                    string opcaoUsuario = ObterOpcaoUsuario();
                    while (opcaoUsuario.ToUpper() != "X")
                    {
                        switch (opcaoUsuario)
                        {
                            case "1":
                                Console.Clear();
                                ListarSerie();
                                break;
                            
                            case "2":
                                Console.Clear();
                                InserirSerie();
                                Console.Clear();
                                break;
                            
                            case "3":
                                Console.Clear();
                                AtualizarSerie();
                                Console.Clear();
                                break;
                           
                            case "4":
                                Console.Clear();
                                ExcluirSerie();
                                Console.Clear();
                                break;
                            
                            case "5":
                                Console.Clear();
                                VisualizarSerie();
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Opção invalida");
                                break;

                        }

                        opcaoUsuario = ObterOpcaoUsuario();
                    }
                }
                else
                {
                    Console.WriteLine("Opção invalida");
                }

                Console.Clear();
                opcaoSessao = ObterOpcaoSessao();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();   
        }

        // ** SESSÃO SÉRIES **
        private static void ListarSerie()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine(" *** Inserir nova série ***");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o número de temporadas: ");
            int entradaSeason = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    season: entradaSeason,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine();
            Console.Write("*** Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o número de temporadas: ");
            int entradaSeason = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    season: entradaSeason,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }
        private static void ExcluirSerie() 
        {
            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir? S / N");
            string decidir = Console.ReadLine().ToUpper();
            if(decidir == "S")
            {
                Console.Write("Digite o id da série: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }
        }
       private static void VisualizarSerie()
        {
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine();
            Console.WriteLine(serie);
        }

        // ** FIM SESSÃO SÉRIES **

        // ** SESSÃO FILMES **
        private static void ListarFilme()
        {
            Console.WriteLine("Listar Filmes");
            var lista = repositorio1.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }
            foreach (var filme in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", filme.retornaId(), filme.retornaTitulo());
            }
        }
        private static void InserirFilme()
        {
            Console.WriteLine();
            Console.WriteLine(" *** Inserir novo filme ***");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorio1.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio1.Insere(novoFilme);
        }
        private static void AtualizarFilme()
        {
            Console.WriteLine();
            Console.Write("*** Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
            repositorio1.Atualiza(indiceFilme, atualizaFilme);
        }
        private static void ExcluirFilme()
        {
            Console.WriteLine();
            Console.WriteLine("Deseja realmente excluir? S / N");
            string decidir = Console.ReadLine().ToUpper();
            if (decidir == "S")
            {
                Console.Write("Digite o id do filme: ");
                int indiceFilme = int.Parse(Console.ReadLine());

                repositorio1.Exclui(indiceFilme);
            }
        }
        private static void VisualizarFilme()
        {
            Console.WriteLine();
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio1.RetornaPorId(indiceFilme);
            Console.WriteLine();
            Console.WriteLine(filme);
        }

        // ** FIM SESSÃO FILMES **

        // ** OPÇÕES DO USUARIO **
        private static string ObterOpcaoSessao()
        {
            Console.WriteLine();
            Console.WriteLine("*** Bem vindo ao PopCine ***");
            Console.WriteLine();
            Console.WriteLine("Qual das Sessões você deseja:");
            Console.WriteLine();
            Console.WriteLine("1- FILMES");
            Console.WriteLine("2- SÉRIES");
            Console.WriteLine();
            Console.WriteLine("X- Sair");

            string opcaoSessao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoSessao;
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" *** Informe a opção desejada: ***");

            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inserir");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Visualisar");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        // ** FIM OPÇÕES DO USUARIO **
    }
}
