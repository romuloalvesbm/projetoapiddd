﻿using Projeto.Domain.Aggregates.Usuarios.Contracts.Repositories;
using Projeto.Domain.Aggregates.Usuarios.Models;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        private readonly DataContext dataContext;

        public PerfilRepository(DataContext dataContext)
            : base(dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
