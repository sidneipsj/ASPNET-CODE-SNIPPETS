# ASPNET-CODE-SNIPPETS
Este repositório irá conter diversos trechos de códigos úteis para o dia-a-dia

Neste repositório especificamente, os snippets adicionados são especificamente para ASP.NET seja MVC, SPA, Entity Framework e etc. 

- Strings de Conexão
- Construtores
- Sobrecargas de métodos 

São códigos que muitas vezes não acresenta muito decorá-los e que vale a pena dar  famoso Ctrl + e fazer a mágica acontecer com o Ctrl + V

Abaixo segue exemplo de snippets encontrados neste repositório:

Removendo pluralização automática do entity framework code-first
protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        modelBuilder.Entity<Item>().ToTable("Items");
    }
    
String de conexão



