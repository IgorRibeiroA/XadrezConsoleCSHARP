// contem a logica do jogo
namespace tabuleiro {
    class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro (int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        //posição inicial das peças
        public Peca peca(int linha, int coluna) {
            return Pecas[linha, coluna];
        }
        //movimentação da peça
        public Peca peca(Posicao pos) {
            return Pecas[pos.Linha, pos.Coluna];
        }
        //peças só são movidas aonde contem o valor null
        public bool existePeca(Posicao pos) {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        /*caso mova a peça para uma localizade já ocupada temos o tratamentos de exceções
          da classe TabuleiroException*/
        public void colocarPeca(Peca p, Posicao pos) {
            if(existePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
        public Peca retirarPeca(Posicao pos) {
            if(peca(pos) == null) {
                return null;
            }
            Peca aux = peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        //logica basica de endereço para a movimentação de cada peça
        public bool posicaoValida(Posicao pos) {
            if (pos.Linha<0 || pos.Linha>=Linhas || pos.Coluna<0 || pos.Coluna >= Colunas) {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos) {
            if (!posicaoValida(pos)) {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
