﻿namespace EntityFramework
{
    internal class Compra
    {
        public Compra()
        {

        }

        public int Quantidade { get; internal set; }
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
    }
}