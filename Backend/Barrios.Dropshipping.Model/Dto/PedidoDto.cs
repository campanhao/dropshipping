using Model.Dto;
using System;
using System.Collections.Generic;

namespace Model
{
    public class PedidoDto
    {
        public UsuarioDto Usuario { get; set; }
        public PedidoEntregaDto PedidoEntrega { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public ICollection<PedidoItemDto> PedidoItens { get; set; }
    }
}
