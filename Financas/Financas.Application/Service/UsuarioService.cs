﻿using System;
using Financas.Domain;
using Financas.Infrastructure.DependencyInjection;
using Financas.Domain.Interface;

namespace Financas.Application.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository = CompositionRoot.Resolve<IUsuarioRepository>();

        public void Adicionar(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
        }
    }
}
