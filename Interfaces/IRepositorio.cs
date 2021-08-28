using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCine.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T Objeto);
        void Exclui(int id);
        void Atualiza(int id, T Objeto);
        int ProximoId();
    }
}
