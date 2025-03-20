﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class VendaInformation
    {
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private DateTime _data;
        public DateTime Data
        {
            get { return _data; }
            set { _data = Data; }
        }
        private int _quantidade;
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        private byte _faturado;
        public byte Faturado
        {
            get { return _faturado; }
            set { _faturado = value; }
        }
        private int _codigoCliente;
        public int CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        private string _codigoProduto;
        public string _CodigoProduto
        {
            get { return _codigoProduto; }
            set { _codigoProduto = value; }
        }
    }
}
