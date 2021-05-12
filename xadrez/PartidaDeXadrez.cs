﻿using System;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
    
        public PartidaDeXadrez() {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;

            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = Tab.retirarPeca(destino);
            Tab.colocarPeca(p, destino);
        }
        public void realizaJogada(Posicao origem, Posicao destino) {
            executaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if(Tab.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(JogadorAtual != Tab.peca(pos).Cor) {
                throw new TabuleiroException("A peça de origem escohida não é a sua!");
            }
            if (!Tab.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não a movimentos possiveis para a peça de origem escolhida!");
            }
        }
        
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!Tab.peca(origem).podeMoverPara(destino)){
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador() {
            if(JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }
        }
        private void colocarPecas() {
            Tab.colocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('c', 1).toPosicao());
            Tab.colocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('c', 4).toPosicao());
        }
    }
}
