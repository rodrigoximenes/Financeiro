using Financas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financas.Application.Service
{
    public interface IMovimentacaoService
    {
        void Adicionar(Movimentacao movimentacao);

        ICollection<Movimentacao> ListarTodas();
    }
}
