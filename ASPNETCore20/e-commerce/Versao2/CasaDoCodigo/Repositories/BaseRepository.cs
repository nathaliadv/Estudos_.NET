using CasaDoCodigo_v2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo_v2.Repositories
{
    //Uma classe especializada em ler, gravar, fazer alterações e manipular dados da entidade - Repositories;

    //

    //Classe base que ajudará na eliminação de duplicações de código, para todos os repositórios a serem utilizados. 
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet; 

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>(); 
        }
    }
}
