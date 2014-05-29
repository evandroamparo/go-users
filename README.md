go-users
========

[![Build status](https://ci.appveyor.com/api/projects/status/upcp502hnlgg2ls9)](https://ci.appveyor.com/project/evandroamparo/go-users)

Gerenciador de arquivos de senhas para o Go - http://www.go.cd/

Arquivo de senhas:
[username]:[password hashed with SHA1 and encoded with base 64]

Teste de criptografia: badger => ThmbShxAtJepX80c2JY1FzOEmUk= (extraído da documentatação do Go)

Criar usuário "admin" antes de qualquer outro usuário.
Somente admin e usuários delegados por ele podem pode gerenciar usuários.
Manter permissões de administrador no arquivo admin.index

- Incluir/alterar/excluir usuários
- Alterar senhas (somente usuário admin)
