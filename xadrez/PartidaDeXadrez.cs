using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro Tab { get; set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool terminada { get; private set; }
    
        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            terminada = false;

            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
        }
        private void colocarPecas() {
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 1).toPosicao());
        }
    }
}
