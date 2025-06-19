using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BePago
    {
        private int IdPago;
        private decimal Pago;
        private int IdDetalle;
        private string Metodo;

        public int IdPago1 { get => IdPago; set => IdPago = value; }
        public decimal Pago1 { get => Pago; set => Pago = value; }
        public int IdDetalle1 { get => IdDetalle; set => IdDetalle = value; }
        public string Metodo1 { get => Metodo; set => Metodo = value; }
    }
}
