using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona a entidade
        /// </summary>
        void Add(TEntity obj);
        /// <summary>
        /// Adiciona uma lista de entidade
        /// </summary>
        void AddList(IEnumerable<TEntity> lstObj);
        /// <summary>
        /// Exclui a entidade
        /// </summary>
        void Remove(TEntity obj);
        /// <summary>
        /// Edita a entidade
        /// </summary>
        void Update(TEntity obj);
        /// <summary>
        /// Obtém a entidade por Id
        /// </summary>
        TEntity Get(int id);
        /// <summary>
        /// Obtem a entidade pelo expressão do where informada
        /// </summary>
        TEntity Get(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        IEnumerable<TEntity> GetList();
        /// <summary>
        /// Obtem a lista da entidade pelo expressão do where informada
        /// </summary>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where);
        /// <summary>
        /// Verifica se a entidade existe com o where informado
        /// </summary>
        bool Exists(Expression<Func<TEntity, bool>> where);
    }
}
