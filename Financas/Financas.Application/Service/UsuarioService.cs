using System;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Domain.Interface;
using System.Collections.Generic;

namespace Financas.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = CompositionRoot.Resolve<IUsuarioRepository>();

        public void Adicionar(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }

        public ICollection<Usuario> ListarTodos()
        {
            return _usuarioRepository.FindAll();
        }
    }
}
