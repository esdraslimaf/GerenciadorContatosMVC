# Gerenciador de Contatos - README
Bem-vindo ao Gerenciador de Contatos, um projeto desenvolvido utilizando C#, ASP.NET Core MVC e Entity Framework. Este sistema permite o gerenciamento de contatos, com recursos de autenticação, criação de contas, adição de contatos(Também operações como: Editar, remover, atualizar) e funcionalidades diferenciadas para contas administradoras e contas comuns.

# Início Rápido
1. Clone este repositório para sua máquina local.
```bash
# clonar repositório
git clone https://github.com/esdraslimaf/GerenciadorContatosMVC.git
```
2. Configure a conexão com o banco de dados no arquivo appsettings.json.
4. Configure o SMTP para redefinição de senha no arquivo appsettings.json(O código está comentando com instruções e recomendações de como fazer... Isso é útil, pois ao realizar a redefinição da senha, uma nova senha aleatória será gerada e enviada para o usuário por meio de e-mail para garantir a segurança do acesso).
5. Compile e execute o projeto.
6. Na tela de login, insira suas credenciais ou clique em "Redefinir Senha" se necessário.
Após o login bem-sucedido, explore as funcionalidades disponíveis de acordo com o tipo de conta.

## Instruções - Importante:
#### Primeiro Acesso: 
Ao iniciar o projeto, você será direcionado para a tela de login. Não há um botão de cadastro de contas nesta fase inicial, pois apenas contas administradoras podem criar novas contas de usuário. Recomendamos criar manualmente uma conta administradora primária no banco de dados, a fim de poder efetuar o login e gerenciar outras contas. Lembre-se de armazenar a senha em formato de hash SHA-1 no banco de dados.
Exemplo de Senha em Hash: Se a senha for "abc", o hash SHA-1 equivalente será "a9993e364706816aba3e25717850c26c9cd0d89d". No momento do login, você pode inserir a senha em texto simples ("abc"), e o sistema a converterá automaticamente para o hash SHA-1 para comparação.

![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/38983cb7-7350-4b2f-b2e2-169e3c72a8ae)

![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/ce5f1e79-6960-4838-8497-82c95173296c)

# Recursos
* Autenticação: O sistema possui uma tela de login onde as contas de usuário são autenticadas. Senhas são armazenadas em formato de hash SHA-1 no banco de dados para segurança. A redefinição de senha é suportada através do envio de e-mails com senhas aleatórias.
* Tipos de Conta: Existem dois tipos de contas no sistema: administradoras e comuns. Apenas contas administradoras têm permissão para criar novas contas de usuário.
* Gerenciamento de Contatos: Contas comuns podem adicionar e visualizar seus próprios contatos. Contas administradoras podem adicionar contatos e criar novas contas, se necessário. Cada conta comum só tem acesso aos contatos que ela adicionou.
* Filtros de Sessão: O acesso a páginas específicas é controlado por filtros de sessão que verificam se o login foi bem-sucedido. Contas não autenticadas serão redirecionadas para a tela de login.

# Configurações
* Banco de Dados: A conexão com o banco de dados é configurada no arquivo appsettings.json. Certifique-se de ajustar as configurações para o seu ambiente.
* SMTP para Redefinição de Senha: O SMTP para envio de e-mails de redefinição de senha também é configurado no arquivo appsettings.json. Siga as instruções de configuração para garantir que o recurso de redefinição de senha funcione corretamente.

# Uso
1. Inicie o aplicativo e acesse a tela de login.
2. Faça o login com uma conta administradora ou comum.
3. Explore as funcionalidades de acordo com o tipo de conta.
4. Use a opção de redefinição de senha, se necessário, para recuperar o acesso à conta.

# Demonstração:
### 1. Tela de login
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/7b82b037-46fe-4738-8234-288faa62690a)

### 2. Recuperar conta(Redefinir)
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/83fe8485-75ee-4373-8640-886685a58a24)


### 3. Página usuários - Conta Administradora
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/6de1a69d-ab27-46db-bab1-813a14e554ce)

### 3.2 Página adicionar usuário - Conta Administradora
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/03a6f76e-3115-4361-b2ce-64820dbab035)

### 3.3 Página editar usuário - Conta Administradora
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/7227be49-2cab-49bb-95e7-8ac970f5735a)


### 4. Página Contatos - Conta Comum
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/003f64ec-17ff-4e04-bc50-7b6192997358)

### 4.1 Página adicionar contato - Conta Comum
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/05907c0c-0d34-4d60-bdde-8a73fe8d908e)

### 4.2 Página editar contato - Conta Comum
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/bd9e0896-c28e-489a-a23d-7631cec355a5)

### 4.3 Página excluir contato - Conta Comum
![image](https://github.com/esdraslimaf/GerenciadorContatosMVC/assets/101669187/91fb59f2-2b01-4e13-9601-5736e8c8be4e)



# Notas Adicionais
* O sistema utiliza autenticação de usuário, criptografia de senha e filtros de sessão para garantir a segurança das informações.
* As contas administradoras têm permissões adicionais para criar novas contas e gerenciar usuários.
* O projeto demonstra boas práticas de desenvolvimento e estruturação de código em ASP.NET Core MVC.

# Aviso Legal
Este projeto é fornecido "como está", sem garantias de qualquer tipo. O autor não se responsabiliza por quaisquer danos ou problemas decorrentes do uso deste projeto.

# Tecnologias utilizadas
## Back-end
- C#
- Entity Framework
- Microsoft SQL Server.

## Front-end
- Asp.Net Core MVC

# Autor

### Esdras Lima

https://www.linkedin.com/in/esdrasdev/
