static void Main(string[] args)
{

    string CMD = "perl -e \" binmode *STDOUT; print pack 'H*','8C65E00F2D0B62C7702530CA0FBEB455C41525A31BFF15F132648D82674F121678648DBE13994FA0E3C569162B30B518CFB9F5E1FA02BEF11C49D5C4F61C60DC0A4C3900D671BD2F1EA34E77C2C6B94C771213556A06E79426514231D0C397BB0352368635672EDDC4595835E3E771E03DE99F668677C65028F204F7C9CB55B4B2EA44AE77C22BCF17DFCD9D9B1B597A9F24C6DAD52F088B2CFF27C7056E2E7360EE7D98ED32EF058B5636BCC80DF5ADF9972FCC42E40FB2B90F0F294ABC273BFD546B7921C447025004CF3AE9EE03D6FA7EB2DC32E358882543B73D0FC3D520D209687F25936D0D8997097BCC6B3339279124803D21F618A8BBB71AFAAD7EBB';\" | openssl rsautl -decrypt -oaep -inkey \"C:\\temp\\TESTE_CRIPTO\\RSA\\myPrivkey.pem";              // O comando a executar

    string salvarComo = "c:\\temp\\meuArquivo1.txt";  // Nome do arquivo a ser salvo a saída
    string saida = ExecutarComandoCMD(CMD); // Executa o comando

    if (!File.Exists(salvarComo))
    {         // Se o arquivo NÃO existir
        File.Create(salvarComo).Dispose();
        using (TextWriter tw = new StreamWriter(salvarComo))
        {
            tw.WriteLine(saida);
        }
    }
    Console.WriteLine(string.Format("O comando {0} foi executado e a saída foi salva no arquivo {1}", CMD, salvarComo));
    Console.ReadLine();
}




public static string ExecutarComandoNoCMD(string ComandoCMD)
{
    using (Process processo = new Process())
    {
        processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

        // Formata a string para passar como argumento para o cmd.exe
        processo.StartInfo.Arguments = string.Format("/c {0}", ComandoCMD);

        // Define a área de trabalho como diretório atual de trabalho
        processo.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Para redirecionar a saída para uma string ou StreamReader 
        processo.StartInfo.RedirectStandardOutput = true;

        // Para redirecionar a saída de um processo
        processo.StartInfo.UseShellExecute = false;

        // Para não criar a janela do cmd.exe
        processo.StartInfo.CreateNoWindow = true;

        // Inicia o cmd.exe
        processo.Start();

        // Aguarda o término
        processo.WaitForExit();

        // Lê a saída do processo, aqui poderia ser usado também um StreamReader
        string saida = processo.StandardOutput.ReadToEnd();
        return saida;
    }
}