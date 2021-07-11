using System;
using System.Collections.Generic;
using System.Text;

namespace Aisoftware.Tracker.Models
{
    public static class Constantes
    {
        #region Validações
        public const string msgUsuarioSenhaErrado = "Login ou senha inválidos.";
        public const string msgAcessoNegado = "Ops, este usuário não possui autorização para acessar essa tela.";
        #endregion

        #region Errors de Sistema
        public const string msgErroGeral = "Ops, tivemos um problema, já avisamos nossos técnicos, por favor, espere um pouco e tente mais tarde!!";
        #endregion

        #region CRUD
        public const string msgSucessoCadastro = "Cadastro realizado com sucesso!";
        public const string msgErroCadastro = "Ops, ocorreu um erro ao tentar realizar o cadastro. Tente novamente.";
        public const string msgSucessoAtualizacao = "Atualização realizada com sucesso!";
        public const string msgErroAtualizacao = "Ops, ocorreu um erro ao tentar realizar a atualização. Tente novamente.";
        public const string msgSucessoExclusao = "Exclusão realizada com sucesso!";
        public const string msgErroExclusao = "Ops, ocorreu um erro ao tentar realizar a exclusão. Tente novamente.";
        #endregion
    }
}
