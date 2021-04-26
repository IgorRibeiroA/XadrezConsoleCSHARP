//classe para o tratamento de exceções/erros
using System;
namespace tabuleiro {
    class TabuleiroException : Exception {
        public TabuleiroException(string msg) : base(msg) {

        }
    }
}
